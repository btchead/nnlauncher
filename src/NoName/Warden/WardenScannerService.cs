using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

public class WardenScannerService
{
	public WardenScannerService(ProcessMemoryHandler gclass14_1, MessageHandler messageHandler)
	{
		this.gclass14_0 = gclass14_1;
		this.messageHandler = messageHandler;
	}

	public void StartWardenScanning()
	{
		List<IntPtr> memoryRegions = new List<IntPtr>();
		bool isFirstScan = true;

		while (scanningEnabled)
		{
			ulong memoryAddress = 0UL;
			int scanInterval = 4500;
			TimeSpan processLifetime = TimeSpan.FromSeconds(180.0);
			TimeSpan elapsedProcessTime = DateTime.Now - this.gclass14_0.process.StartTime;

			// Check if the process has been running for more than the process lifetime.
			if (elapsedProcessTime < processLifetime)
			{
				Thread.Sleep(processLifetime - elapsedProcessTime);
			}

			// Query the process to find any memory regions.
			int queryResult;
			do
			{
				// Check if the process has exited.
				if (gclass14_0.process.HasExited)
				{
					Process.GetCurrentProcess().Kill();
				}

				// Get the next memory region and check if it contains a possible warden module.
				IntPtr memoryPointer = (IntPtr)((long)memoryAddress);
				MemoryBasicInformation memoryInformation;
				queryResult = KernelAPI.VirtualQueryEx(gclass14_0.processHandle, memoryPointer, out memoryInformation, Marshal.SizeOf(typeof(MemoryBasicInformation)));
				memoryAddress += memoryInformation.RegionSize;

				// Check for errors.
				if (memoryAddress == 0UL)
				{
					Logger.Error("Fatal error, ending the scan!");
					return;
				}

				// Check if the memory region is greater than 1kb and if it is not already scanned.
				if (memoryInformation.Protect == 64U && memoryInformation.RegionSize > 1024UL && !memoryRegions.Contains(memoryPointer))
				{
					if (!isFirstScan)
					{
						Logger.Error("Possible warden module detected, exiting!");
						byte[] memoryContents = new byte[memoryInformation.RegionSize];
						IntPtr bytesRead;
						KernelAPI.ReadProcessMemory(gclass14_0.processHandle, memoryPointer, memoryContents, memoryContents.Length, out bytesRead);
						if ((long)bytesRead == (long)memoryInformation.RegionSize)
						{
							messageHandler.SendWardenUploadMessage(memoryContents);
						}
						Thread.Sleep(1500);
						Process.GetCurrentProcess().Kill();
					}
					memoryRegions.Add(memoryPointer);
				}
			}
			while (queryResult != 0);

			isFirstScan = false;
			Thread.Sleep(scanInterval);
		}
	}

	public void DisableScanning()
	{
		scanningEnabled = false;
	}

	private ProcessMemoryHandler gclass14_0;

	private MessageHandler messageHandler;

	private bool scanningEnabled = true;
}
