using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.Win32;

public class WardenController
{
    public WardenController(ProcessMemoryHandler gclass14_1, Server server = null)
    {
        gclass14_0 = gclass14_1;
        networkStreamWriter = new NetworkStreamWriter(server);
        gclass4_0 = new MemoryHandlerCommunicator(gclass14_1, networkStreamWriter);
        wardenScanner = new WardenScannerService(gclass14_1, networkStreamWriter);
        networkStreamWriter.Action_0 = new Action(method_3);
    }

    public void method_0(Action action_1)
    {
        string fileVersion = gclass14_0.process.MainModule.FileVersionInfo.FileVersion;
        networkStreamWriter.SendClientRequestToolOffsetsMessage(fileVersion, action_1);
    }

    public void method_1(string punaniString, Action callback)
    {
        action_0 = callback;
        string fileVersion = gclass14_0.process.MainModule.FileVersionInfo.FileVersion;
        allocatedMemory = (ulong)gclass14_0.AllocateMemory(16384, MemoryProtectionFlags.PAGE_READWRITE, ProcessMemoryHandler.MemoryAllocationType.MEM_COMMIT, -1L).ToInt64();
        networkStreamWriter.SendClientRequestPayloadMessage(fileVersion, (ulong)gclass14_0.GetMainModuleBaseAddress(), allocatedMemory, punaniString, Directory.GetCurrentDirectory() + "\\", new Action(method_2));
    }

    public void method_2()
    {
        if (networkStreamWriter.List_0 != null && networkStreamWriter.AuthPayload != null)
        {
            action_0();
        }
    }

    public void method_3()
    {
        string fileVersion = gclass14_0.process.MainModule.FileVersionInfo.FileVersion;
        byte[] moduleBytes = gclass14_0.method_5(gclass14_0.process.MainModule.BaseAddress, gclass14_0.process.MainModule.ModuleMemorySize);
        int num = 65536;
        for (int i = 0; i < moduleBytes.Length; i += num)
        {
            int num2 = num;
            if (i + num2 > moduleBytes.Length)
            {
                num2 = moduleBytes.Length - i;
            }
            byte[] chunk = new byte[num2];
            Array.Copy(moduleBytes, i, chunk, 0, num2);
            networkStreamWriter.WriteMemoryStreamToServer(MessageFactory.CreateClientUploadGameModuleMessageStream(fileVersion, chunk, moduleBytes.Length, i));
        }
    }

    public void method_4()
    {
        MemoryHandlerCommunicator gclass = new MemoryHandlerCommunicator(gclass14_0, networkStreamWriter);
        gclass.method_0(Crypto.MachineGUID);
    }

    public void method_5()
    {
        GClass5 gclass = new GClass5(gclass14_0, networkStreamWriter);
        gclass.method_1();
        gclass.method_0(allocatedMemory);
        for (int i = 0; i < networkStreamWriter.LuaPayload.Length; i++)
        {
            networkStreamWriter.LuaPayload[i] = 0;
        }
        for (int j = 0; j < networkStreamWriter.AuthPayload.Length; j++)
        {
            networkStreamWriter.AuthPayload[j] = 0;
        }
    }

    public void StartWardenScanningThread()
    {
        Thread wardenThread = new Thread(new ThreadStart(wardenScanner.StartWardenScanning));
        wardenThread.Start();
    }

    public void DisableWardenScanning()
    {
        wardenScanner.DisableScanning();
    }

    public string method_9()
    {
        return gclass14_0.method_9((IntPtr)(gclass14_0.GetMainModuleBaseAddress() + (long)networkStreamWriter.List_0[46]), 32);
    }

    public void SuspendProcess()
    {
        KernelAPI.NtSuspendProcess(gclass14_0.processHandle);
    }

    public void ResumeProcess()
    {
        KernelAPI.NtResumeProcess(gclass14_0.processHandle);
    }

    public ProcessMemoryHandler gclass14_0;

    private MemoryHandlerCommunicator gclass4_0;

    private WardenScannerService wardenScanner;

    private NetworkStreamWriter networkStreamWriter;

    private ulong allocatedMemory;

    private Action action_0;
}
