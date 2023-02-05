using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Microsoft.Win32;

// Token: 0x02000002 RID: 2
public class GClass0
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002AAC File Offset: 0x00000CAC
	public GClass0(GClass14 gclass14_1, GClass12 gclass12_0 = null)
	{
		this.gclass14_0 = gclass14_1;
		this.gclass2_0 = new GClass2(gclass12_0);
		this.gclass4_0 = new GClass4(gclass14_1, this.gclass2_0);
		this.gclass3_0 = new GClass3(gclass14_1, this.gclass2_0);
		this.gclass2_0.Action_0 = new Action(this.method_3);
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002B10 File Offset: 0x00000D10
	public void method_0(Action action_1)
	{
		string fileVersion = this.gclass14_0.Process_0.MainModule.FileVersionInfo.FileVersion;
		this.gclass2_0.method_7(fileVersion, action_1);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002B48 File Offset: 0x00000D48
	public void method_1(string string_0, Action action_1)
	{
		this.action_0 = action_1;
		string fileVersion = this.gclass14_0.Process_0.MainModule.FileVersionInfo.FileVersion;
		this.ulong_0 = (ulong)this.gclass14_0.method_16(16384, GEnum3.PAGE_READWRITE, GClass14.GEnum4.MEM_COMMIT, -1L).ToInt64();
		this.gclass2_0.method_8(fileVersion, (ulong)this.gclass14_0.method_14(), this.ulong_0, string_0, Directory.GetCurrentDirectory() + "\\", new Action(this.method_2));
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000020EC File Offset: 0x000002EC
	public void method_2()
	{
		if (this.gclass2_0.List_0 != null && this.gclass2_0.Byte_0 != null)
		{
			this.action_0();
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002BE0 File Offset: 0x00000DE0
	public void method_3()
	{
		string fileVersion = this.gclass14_0.Process_0.MainModule.FileVersionInfo.FileVersion;
		byte[] array = this.gclass14_0.method_5(this.gclass14_0.Process_0.MainModule.BaseAddress, this.gclass14_0.Process_0.MainModule.ModuleMemorySize);
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
			this.gclass2_0.method_0(GClass7.smethod_5(fileVersion, array2, array.Length, i));
		}
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002C94 File Offset: 0x00000E94
	public void method_4()
	{
		GClass4 gclass = new GClass4(this.gclass14_0, this.gclass2_0);
		gclass.method_0(this.method_12());
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002CC0 File Offset: 0x00000EC0
	public void method_5()
	{
		GClass5 gclass = new GClass5(this.gclass14_0, this.gclass2_0);
		gclass.method_1();
		gclass.method_0(this.ulong_0);
		for (int i = 0; i < this.gclass2_0.Byte_1.Length; i++)
		{
			this.gclass2_0.Byte_1[i] = 0;
		}
		for (int j = 0; j < this.gclass2_0.Byte_0.Length; j++)
		{
			this.gclass2_0.Byte_0[j] = 0;
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002113 File Offset: 0x00000313
	public void method_6()
	{
		new Thread(new ThreadStart(this.gclass3_0.method_0)).Start();
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002130 File Offset: 0x00000330
	public void method_7()
	{
		this.gclass3_0.method_1();
	}

	// Token: 0x0600000A RID: 10 RVA: 0x0000213D File Offset: 0x0000033D
	public void method_8()
	{
	}

	// Token: 0x0600000B RID: 11 RVA: 0x0000213F File Offset: 0x0000033F
	public string method_9()
	{
		return this.gclass14_0.method_9((IntPtr)(this.gclass14_0.method_14() + (long)this.gclass2_0.List_0[46]), 32);
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002171 File Offset: 0x00000371
	public void method_10()
	{
		GClass13.NtSuspendProcess(this.gclass14_0.IntPtr_0);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002183 File Offset: 0x00000383
	public void method_11()
	{
		GClass13.NtResumeProcess(this.gclass14_0.IntPtr_0);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002D40 File Offset: 0x00000F40
	private string method_12()
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

	// Token: 0x0600000F RID: 15 RVA: 0x00002195 File Offset: 0x00000395
	static ProcessModule smethod_0(Process process_0)
	{
		return process_0.MainModule;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x0000219D File Offset: 0x0000039D
	static FileVersionInfo smethod_1(ProcessModule processModule_0)
	{
		return processModule_0.FileVersionInfo;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000021A5 File Offset: 0x000003A5
	static string smethod_2(FileVersionInfo fileVersionInfo_0)
	{
		return fileVersionInfo_0.FileVersion;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000021AD File Offset: 0x000003AD
	static string smethod_3()
	{
		return Directory.GetCurrentDirectory();
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000021B4 File Offset: 0x000003B4
	static string smethod_4(string string_0, string string_1)
	{
		return string_0 + string_1;
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000021BD File Offset: 0x000003BD
	static IntPtr smethod_5(ProcessModule processModule_0)
	{
		return processModule_0.BaseAddress;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x000021C5 File Offset: 0x000003C5
	static int smethod_6(ProcessModule processModule_0)
	{
		return processModule_0.ModuleMemorySize;
	}

	// Token: 0x06000016 RID: 22 RVA: 0x000021CD File Offset: 0x000003CD
	static void smethod_7(Array array_0, int int_0, Array array_1, int int_1, int int_2)
	{
		Array.Copy(array_0, int_0, array_1, int_1, int_2);
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000021DA File Offset: 0x000003DA
	static Thread smethod_8(ThreadStart threadStart_0)
	{
		return new Thread(threadStart_0);
	}

	// Token: 0x06000018 RID: 24 RVA: 0x000021E2 File Offset: 0x000003E2
	static void smethod_9(Thread thread_0)
	{
		thread_0.Start();
	}

	// Token: 0x06000019 RID: 25 RVA: 0x000021EA File Offset: 0x000003EA
	static RegistryKey smethod_10(RegistryHive registryHive_0, RegistryView registryView_0)
	{
		return RegistryKey.OpenBaseKey(registryHive_0, registryView_0);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x000021F3 File Offset: 0x000003F3
	static RegistryKey smethod_11(RegistryKey registryKey_0, string string_0)
	{
		return registryKey_0.OpenSubKey(string_0);
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000021FC File Offset: 0x000003FC
	static string smethod_12(string string_0, object object_0)
	{
		return string.Format(string_0, object_0);
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002205 File Offset: 0x00000405
	static KeyNotFoundException smethod_13(string string_0)
	{
		return new KeyNotFoundException(string_0);
	}

	// Token: 0x0600001D RID: 29 RVA: 0x0000220D File Offset: 0x0000040D
	static object smethod_14(RegistryKey registryKey_0, string string_0)
	{
		return registryKey_0.GetValue(string_0);
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002216 File Offset: 0x00000416
	static IndexOutOfRangeException smethod_15(string string_0)
	{
		return new IndexOutOfRangeException(string_0);
	}

	// Token: 0x0600001F RID: 31 RVA: 0x0000221E File Offset: 0x0000041E
	static string smethod_16(object object_0)
	{
		return object_0.ToString();
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00002226 File Offset: 0x00000426
	static void smethod_17(IDisposable idisposable_0)
	{
		idisposable_0.Dispose();
	}

	// Token: 0x04000001 RID: 1
	public GClass14 gclass14_0;

	// Token: 0x04000002 RID: 2
	private GClass4 gclass4_0;

	// Token: 0x04000003 RID: 3
	private GClass3 gclass3_0;

	// Token: 0x04000004 RID: 4
	private GClass1 gclass1_0;

	// Token: 0x04000005 RID: 5
	private GClass2 gclass2_0;

	// Token: 0x04000006 RID: 6
	private ulong ulong_0;

	// Token: 0x04000007 RID: 7
	private Action action_0;
}
