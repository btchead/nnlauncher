using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.Win32;

// Token: 0x02000002 RID: 2
public class WardenController
{
    // Token: 0x06000001 RID: 1 RVA: 0x00002AAC File Offset: 0x00000CAC
    public WardenController(ProcessMemoryHandler gclass14_1, Server server = null)
    {
        this.gclass14_0 = gclass14_1;
        this.messageHandler = new MessageHandler(server);
        this.gclass4_0 = new MemoryHandlerCommunicator(gclass14_1, this.messageHandler);
        this.wardenScanner = new WardenScanner(gclass14_1, this.messageHandler);
        this.messageHandler.Action_0 = new Action(this.method_3);
    }

    // Token: 0x06000002 RID: 2 RVA: 0x00002B10 File Offset: 0x00000D10
    public void method_0(Action action_1)
    {
        string fileVersion = this.gclass14_0.process.MainModule.FileVersionInfo.FileVersion;
        this.messageHandler.method_7(fileVersion, action_1);
    }

    public void method_1(string punaniString, Action callback)
    {
        action_0 = callback;
        string fileVersion = gclass14_0.process.MainModule.FileVersionInfo.FileVersion;
        allocatedMemory = (ulong)gclass14_0.AllocateMemory(16384, MemoryProtectionFlags.PAGE_READWRITE, ProcessMemoryHandler.MemoryAllocationType.MEM_COMMIT, -1L).ToInt64();
        messageHandler.method_8(fileVersion, (ulong)gclass14_0.GetMainModuleBaseAddress(), allocatedMemory, punaniString, Directory.GetCurrentDirectory() + "\\", new Action(method_2));
    }

    // Token: 0x06000004 RID: 4 RVA: 0x000020EC File Offset: 0x000002EC
    public void method_2()
    {
        if (this.messageHandler.List_0 != null && this.messageHandler.Byte_0 != null)
        {
            this.action_0();
        }
    }

    // Token: 0x06000005 RID: 5 RVA: 0x00002BE0 File Offset: 0x00000DE0
    public void method_3()
    {
        string fileVersion = this.gclass14_0.process.MainModule.FileVersionInfo.FileVersion;
        byte[] array = this.gclass14_0.method_5(this.gclass14_0.process.MainModule.BaseAddress, this.gclass14_0.process.MainModule.ModuleMemorySize);
        int num = 65536;
        for (int i = 0; i < array.Length; i += num)
        {
            int num2 = num;
            if (i + num2 > array.Length)
            {
                num2 = array.Length - i;
            }
            byte[] array2 = new byte[num2];
            Array.Copy(array, i, array2, 0, num2);
            this.messageHandler.WriteMemoryStreamToServer(MessageFactory.CreateClientUploadGameModuleMsg(fileVersion, array2, array.Length, i));
        }
    }

    // Token: 0x06000006 RID: 6 RVA: 0x00002C94 File Offset: 0x00000E94
    public void method_4()
    {
        MemoryHandlerCommunicator gclass = new MemoryHandlerCommunicator(this.gclass14_0, this.messageHandler);
        gclass.method_0(this.GetMachineGUID());
    }

    // Token: 0x06000007 RID: 7 RVA: 0x00002CC0 File Offset: 0x00000EC0
    public void method_5()
    {
        GClass5 gclass = new GClass5(this.gclass14_0, this.messageHandler);
        gclass.method_1();
        gclass.method_0(this.allocatedMemory);
        for (int i = 0; i < this.messageHandler.Byte_1.Length; i++)
        {
            this.messageHandler.Byte_1[i] = 0;
        }
        for (int j = 0; j < this.messageHandler.Byte_0.Length; j++)
        {
            this.messageHandler.Byte_0[j] = 0;
        }
    }

    // Token: 0x06000008 RID: 8 RVA: 0x00002113 File Offset: 0x00000313
    public void StartWardenScanningThread()
    {
        Thread wardenThread = new Thread(new ThreadStart(wardenScanner.StartWardenScanning));
        wardenThread.Start();
    }

    // Token: 0x06000009 RID: 9 RVA: 0x00002130 File Offset: 0x00000330
    public void DisableWardenScanning()
    {
        wardenScanner.DisableScanning();
    }

    // Token: 0x0600000B RID: 11 RVA: 0x0000213F File Offset: 0x0000033F
    public string method_9()
    {
        return this.gclass14_0.method_9((IntPtr)(this.gclass14_0.GetMainModuleBaseAddress() + (long)this.messageHandler.List_0[46]), 32);
    }

    // Token: 0x0600000C RID: 12 RVA: 0x00002171 File Offset: 0x00000371
    public void SuspendProcess()
    {
        KernelAPI.NtSuspendProcess(this.gclass14_0.processHandle);
    }

    // Token: 0x0600000D RID: 13 RVA: 0x00002183 File Offset: 0x00000383
    public void ResumeProcess()
    {
        KernelAPI.NtResumeProcess(this.gclass14_0.processHandle);
    }

    // Token: 0x0600000E RID: 14 RVA: 0x00002D40 File Offset: 0x00000F40
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

    // Token: 0x04000001 RID: 1
    public ProcessMemoryHandler gclass14_0;

    // Token: 0x04000002 RID: 2
    private MemoryHandlerCommunicator gclass4_0;

    // Token: 0x04000003 RID: 3
    private WardenScanner wardenScanner;

    // Token: 0x04000005 RID: 5
    private MessageHandler messageHandler;

    // Token: 0x04000006 RID: 6
    private ulong allocatedMemory;

    // Token: 0x04000007 RID: 7
    private Action action_0;
}
