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
        messageHandler = new MessageHandler(server);
        gclass4_0 = new MemoryHandlerCommunicator(gclass14_1, messageHandler);
        wardenScanner = new WardenScannerService(gclass14_1, messageHandler);
        messageHandler.Action_0 = new Action(method_3);
    }

    public void method_0(Action action_1)
    {
        string fileVersion = gclass14_0.process.MainModule.FileVersionInfo.FileVersion;
        messageHandler.SendClientRequestToolOffsetsMessage(fileVersion, action_1);
    }

    public void method_1(string punaniString, Action callback)
    {
        action_0 = callback;
        string fileVersion = gclass14_0.process.MainModule.FileVersionInfo.FileVersion;
        allocatedMemory = (ulong)gclass14_0.AllocateMemory(16384, MemoryProtectionFlags.PAGE_READWRITE, ProcessMemoryHandler.MemoryAllocationType.MEM_COMMIT, -1L).ToInt64();
        messageHandler.SendClientRequestPayloadMessage(fileVersion, (ulong)gclass14_0.GetMainModuleBaseAddress(), allocatedMemory, punaniString, Directory.GetCurrentDirectory() + "\\", new Action(method_2));
    }

    public void method_2()
    {
        if (messageHandler.List_0 != null && messageHandler.Byte_0 != null)
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
            messageHandler.WriteMemoryStreamToServer(MessageFactory.CreateClientUploadGameModuleMessageStream(fileVersion, chunk, moduleBytes.Length, i));
        }
    }

    public void method_4()
    {
        MemoryHandlerCommunicator gclass = new MemoryHandlerCommunicator(gclass14_0, messageHandler);
        gclass.method_0(GetMachineGUID());
    }

    public void method_5()
    {
        GClass5 gclass = new GClass5(gclass14_0, messageHandler);
        gclass.method_1();
        gclass.method_0(allocatedMemory);
        for (int i = 0; i < messageHandler.Byte_1.Length; i++)
        {
            messageHandler.Byte_1[i] = 0;
        }
        for (int j = 0; j < messageHandler.Byte_0.Length; j++)
        {
            messageHandler.Byte_0[j] = 0;
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
        return gclass14_0.method_9((IntPtr)(gclass14_0.GetMainModuleBaseAddress() + (long)messageHandler.List_0[46]), 32);
    }

    public void SuspendProcess()
    {
        KernelAPI.NtSuspendProcess(gclass14_0.processHandle);
    }

    public void ResumeProcess()
    {
        KernelAPI.NtResumeProcess(gclass14_0.processHandle);
    }

    private string GetMachineGUID()
    {
        string text = "SOFTWARE\\Microsoft\\Cryptography";
        string text2 = "MachineGuid";
        string text3;
        using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
        {
            using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
            {
                if (registryKey2 == null)
                {
                    throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
                }
                object value = registryKey2.GetValue(text2);
                if (value == null)
                {
                    throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
                }
                text3 = value.ToString();
            }
        }
        return text3;
    }

    public ProcessMemoryHandler gclass14_0;

    private MemoryHandlerCommunicator gclass4_0;

    private WardenScannerService wardenScanner;

    private MessageHandler messageHandler;

    private ulong allocatedMemory;

    private Action action_0;
}
