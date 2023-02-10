using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

public class WardenScanner
{
	public WardenScanner(ProcessMemoryHandler gclass14_1, MessageHandler messageHandler)
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
				GStruct1 memoryInformation;
				queryResult = KernelAPI.VirtualQueryEx(gclass14_0.processHandle, memoryPointer, out memoryInformation, Marshal.SizeOf(typeof(GStruct1)));
				memoryAddress += memoryInformation.ulong_2;

				// Check for errors.
				if (memoryAddress == 0UL)
				{
					Console.WriteLine("Fatal error, ending the scan!");
					return;
				}

				// Check if the memory region is greater than 1kb and if it is not already scanned.
				if (memoryInformation.uint_2 == 64U && memoryInformation.ulong_2 > 1024UL && !memoryRegions.Contains(memoryPointer))
				{
					if (!isFirstScan)
					{
						Console.WriteLine("Possible warden module detected, exiting!", ConsoleColor.Yellow);
						byte[] memoryContents = new byte[memoryInformation.ulong_2];
						IntPtr bytesRead;
						KernelAPI.ReadProcessMemory(gclass14_0.processHandle, memoryPointer, memoryContents, memoryContents.Length, out bytesRead);
						if ((long)bytesRead == (long)memoryInformation.ulong_2)
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
