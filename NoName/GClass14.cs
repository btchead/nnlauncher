using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

// Token: 0x0200001E RID: 30
public class GClass14
{
	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000168 RID: 360 RVA: 0x00002963 File Offset: 0x00000B63
	// (set) Token: 0x06000169 RID: 361 RVA: 0x0000296B File Offset: 0x00000B6B
	public Process Process_0 { get; set; }

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x0600016A RID: 362 RVA: 0x00002974 File Offset: 0x00000B74
	// (set) Token: 0x0600016B RID: 363 RVA: 0x0000297C File Offset: 0x00000B7C
	public IntPtr IntPtr_0 { get; set; }

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x0600016C RID: 364 RVA: 0x00002985 File Offset: 0x00000B85
	// (set) Token: 0x0600016D RID: 365 RVA: 0x0000298D File Offset: 0x00000B8D
	public IntPtr IntPtr_1 { get; set; }

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x0600016E RID: 366 RVA: 0x00002996 File Offset: 0x00000B96
	// (set) Token: 0x0600016F RID: 367 RVA: 0x0000299E File Offset: 0x00000B9E
	private long[] Int64_0 { get; set; }

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x06000170 RID: 368 RVA: 0x000029A7 File Offset: 0x00000BA7
	public string String_0
	{
		get
		{
			return this.Process_0.MainModule.FileVersionInfo.FileVersion;
		}
	}

	// Token: 0x06000171 RID: 369 RVA: 0x000029BE File Offset: 0x00000BBE
	public GClass14(Process process_1)
	{
		this.Process_0 = process_1;
		this.IntPtr_0 = this.method_1(65535);
		this.Int64_0 = null;
	}

	// Token: 0x06000172 RID: 370 RVA: 0x00004F1C File Offset: 0x0000311C
	public void method_0(bool bool_0)
	{
		byte[] array = new byte[] { 133, 201, 117, 24 };
		if (bool_0)
		{
			array = new byte[] { 144, 72, byte.MaxValue, 194 };
		}
		IntPtr intPtr = GClass13.GetProcAddress(GClass13.GetModuleHandle("KERNEL32"), "BaseThreadInitThunk") + 4;
		this.method_10(intPtr, array);
	}

	// Token: 0x06000173 RID: 371 RVA: 0x000029E5 File Offset: 0x00000BE5
	public IntPtr method_1(int int_0)
	{
		return GClass13.OpenProcess(int_0, false, this.Process_0.Id);
	}

	// Token: 0x06000174 RID: 372 RVA: 0x000029F9 File Offset: 0x00000BF9
	public bool method_2(IntPtr intptr_2)
	{
		return GClass13.CloseHandle(intptr_2);
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00004F78 File Offset: 0x00003178
	public IntPtr method_3(IntPtr intptr_2)
	{
		IntPtr intPtr;
		return GClass13.CreateRemoteThread(this.IntPtr_0, IntPtr.Zero, 0U, intptr_2, IntPtr.Zero, 0, out intPtr);
	}

	// Token: 0x06000176 RID: 374 RVA: 0x00004FA0 File Offset: 0x000031A0
	public byte[] method_4(long long_1, int int_0)
	{
		if (this.Process_0.HasExited)
		{
			return null;
		}
		IntPtr zero = IntPtr.Zero;
		byte[] array = new byte[int_0];
		GClass13.ReadProcessMemory(this.IntPtr_0, (IntPtr)long_1, array, array.Length, out zero);
		if (zero.ToInt32() != int_0)
		{
			return null;
		}
		return array;
	}

	// Token: 0x06000177 RID: 375 RVA: 0x00002A01 File Offset: 0x00000C01
	public byte[] method_5(IntPtr intptr_2, int int_0)
	{
		return this.method_4((long)intptr_2, int_0);
	}

	// Token: 0x06000178 RID: 376 RVA: 0x00002A10 File Offset: 0x00000C10
	public long method_6(IntPtr intptr_2)
	{
		return BitConverter.ToInt64(this.method_4((long)intptr_2, 8), 0);
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00002A20 File Offset: 0x00000C20
	public float method_7(IntPtr intptr_2)
	{
		return BitConverter.ToSingle(this.method_4((long)intptr_2, 4), 0);
	}

	// Token: 0x0600017A RID: 378 RVA: 0x00002A30 File Offset: 0x00000C30
	public void method_8(IntPtr intptr_2, ref byte[] byte_0)
	{
		byte_0 = this.method_4((long)intptr_2, byte_0.Length);
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00004FF0 File Offset: 0x000031F0
	public string method_9(IntPtr intptr_2, int int_0 = 32)
	{
		byte[] array = this.method_4((long)intptr_2, int_0);
		if (array == null)
		{
			return "Err";
		}
		return Encoding.UTF8.GetString(array).Split(new char[1]).FirstOrDefault<string>();
	}

	// Token: 0x0600017C RID: 380 RVA: 0x0000502C File Offset: 0x0000322C
	public bool method_10(IntPtr intptr_2, byte[] byte_0)
	{
		if (this.Process_0.HasExited)
		{
			return false;
		}
		IntPtr zero = IntPtr.Zero;
		GClass13.WriteProcessMemory(this.IntPtr_0, intptr_2, byte_0, byte_0.Length, out zero);
		return zero.ToInt32() == byte_0.Length;
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00002A3F File Offset: 0x00000C3F
	public bool method_11(IntPtr intptr_2, long long_1)
	{
		return this.method_10(intptr_2, BitConverter.GetBytes(long_1));
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00002A4E File Offset: 0x00000C4E
	public bool method_12(IntPtr intptr_2, int int_0)
	{
		return this.method_10(intptr_2, BitConverter.GetBytes(int_0));
	}

	// Token: 0x0600017F RID: 383 RVA: 0x00002A5D File Offset: 0x00000C5D
	public bool method_13(IntPtr intptr_2, string string_0)
	{
		return this.method_10(intptr_2, Encoding.UTF8.GetBytes(string_0));
	}

	// Token: 0x06000180 RID: 384 RVA: 0x00002A71 File Offset: 0x00000C71
	public long method_14()
	{
		return (long)this.Process_0.MainModule.BaseAddress;
	}

	// Token: 0x06000181 RID: 385 RVA: 0x00002A88 File Offset: 0x00000C88
	public IntPtr method_15(IntPtr intptr_2, string string_0)
	{
		return GClass13.GetProcAddress(intptr_2, string_0);
	}

	// Token: 0x06000182 RID: 386 RVA: 0x00005070 File Offset: 0x00003270
	public IntPtr method_16(int int_0, MemoryProtectionFlags genum3_0, GClass14.GEnum4 genum4_0 = GClass14.GEnum4.MEM_COMMIT, long long_1 = -1L)
	{
		IntPtr intPtr = IntPtr.Zero;
		if (long_1 != -1L)
		{
			intPtr = (IntPtr)long_1;
		}
		return GClass13.VirtualAllocEx(this.IntPtr_0, intPtr, int_0, (int)genum4_0, genum3_0);
	}

	// Token: 0x06000183 RID: 387 RVA: 0x00002195 File Offset: 0x00000395
	static ProcessModule smethod_0(Process process_1)
	{
		return process_1.MainModule;
	}

	// Token: 0x06000184 RID: 388 RVA: 0x0000219D File Offset: 0x0000039D
	static FileVersionInfo smethod_1(ProcessModule processModule_0)
	{
		return processModule_0.FileVersionInfo;
	}

	// Token: 0x06000185 RID: 389 RVA: 0x000021A5 File Offset: 0x000003A5
	static string smethod_2(FileVersionInfo fileVersionInfo_0)
	{
		return fileVersionInfo_0.FileVersion;
	}

	// Token: 0x06000186 RID: 390 RVA: 0x00002568 File Offset: 0x00000768
	static void smethod_3(Array array_0, RuntimeFieldHandle runtimeFieldHandle_0)
	{
		RuntimeHelpers.InitializeArray(array_0, runtimeFieldHandle_0);
	}

	// Token: 0x06000187 RID: 391 RVA: 0x0000234C File Offset: 0x0000054C
	static int smethod_4(Process process_1)
	{
		return process_1.Id;
	}

	// Token: 0x06000188 RID: 392 RVA: 0x0000231C File Offset: 0x0000051C
	static bool smethod_5(Process process_1)
	{
		return process_1.HasExited;
	}

	// Token: 0x06000189 RID: 393 RVA: 0x000024F6 File Offset: 0x000006F6
	static long smethod_6(byte[] byte_0, int int_0)
	{
		return BitConverter.ToInt64(byte_0, int_0);
	}

	// Token: 0x0600018A RID: 394 RVA: 0x00002A91 File Offset: 0x00000C91
	static float smethod_7(byte[] byte_0, int int_0)
	{
		return BitConverter.ToSingle(byte_0, int_0);
	}

	// Token: 0x0600018B RID: 395 RVA: 0x00002718 File Offset: 0x00000918
	static Encoding smethod_8()
	{
		return Encoding.UTF8;
	}

	// Token: 0x0600018C RID: 396 RVA: 0x0000271F File Offset: 0x0000091F
	static string smethod_9(Encoding encoding_0, byte[] byte_0)
	{
		return encoding_0.GetString(byte_0);
	}

	// Token: 0x0600018D RID: 397 RVA: 0x00002737 File Offset: 0x00000937
	static string[] smethod_10(string string_0, char[] char_0)
	{
		return string_0.Split(char_0);
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00002A9A File Offset: 0x00000C9A
	static byte[] smethod_11(long long_1)
	{
		return BitConverter.GetBytes(long_1);
	}

	// Token: 0x0600018F RID: 399 RVA: 0x00002AA2 File Offset: 0x00000CA2
	static byte[] smethod_12(int int_0)
	{
		return BitConverter.GetBytes(int_0);
	}

	// Token: 0x06000190 RID: 400 RVA: 0x00002557 File Offset: 0x00000757
	static byte[] smethod_13(Encoding encoding_0, string string_0)
	{
		return encoding_0.GetBytes(string_0);
	}

	// Token: 0x06000191 RID: 401 RVA: 0x000021BD File Offset: 0x000003BD
	static IntPtr smethod_14(ProcessModule processModule_0)
	{
		return processModule_0.BaseAddress;
	}

	// Token: 0x040000DA RID: 218
	[CompilerGenerated]
	private Process process_0;

	// Token: 0x040000DB RID: 219
	[CompilerGenerated]
	private IntPtr intptr_0;

	// Token: 0x040000DC RID: 220
	[CompilerGenerated]
	private IntPtr intptr_1;

	// Token: 0x040000DD RID: 221
	[CompilerGenerated]
	private long[] long_0;

	// Token: 0x0200001F RID: 31
	public enum GEnum4
	{
		// Token: 0x040000DF RID: 223
		MEM_COMMIT = 4096,
		// Token: 0x040000E0 RID: 224
		MEM_RESERVE = 8192
	}
}
