using System;
using System.Diagnostics;
using System.Linq;
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
		IntPtr intPtr = KernelAPI.GetProcAddress(KernelAPI.GetModuleHandle("KERNEL32"), "BaseThreadInitThunk") + 4;
		this.method_10(intPtr, array);
	}

	// Token: 0x06000173 RID: 371 RVA: 0x000029E5 File Offset: 0x00000BE5
	public IntPtr method_1(int int_0)
	{
		return KernelAPI.OpenProcess(int_0, false, this.Process_0.Id);
	}

	// Token: 0x06000174 RID: 372 RVA: 0x000029F9 File Offset: 0x00000BF9
	public bool method_2(IntPtr intptr_2)
	{
		return KernelAPI.CloseHandle(intptr_2);
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00004F78 File Offset: 0x00003178
	public IntPtr method_3(IntPtr intptr_2)
	{
		IntPtr intPtr;
		return KernelAPI.CreateRemoteThread(this.IntPtr_0, IntPtr.Zero, 0U, intptr_2, IntPtr.Zero, 0, out intPtr);
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
		KernelAPI.ReadProcessMemory(this.IntPtr_0, (IntPtr)long_1, array, array.Length, out zero);
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
		KernelAPI.WriteProcessMemory(this.IntPtr_0, intptr_2, byte_0, byte_0.Length, out zero);
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
		return KernelAPI.GetProcAddress(intptr_2, string_0);
	}

	// Token: 0x06000182 RID: 386 RVA: 0x00005070 File Offset: 0x00003270
	public IntPtr method_16(int int_0, MemoryProtectionFlags genum3_0, MemoryAllocationFlags genum4_0 = MemoryAllocationFlags.MEM_COMMIT, long long_1 = -1L)
	{
		IntPtr intPtr = IntPtr.Zero;
		if (long_1 != -1L)
		{
			intPtr = (IntPtr)long_1;
		}
		return KernelAPI.VirtualAllocEx(this.IntPtr_0, intPtr, int_0, (int)genum4_0, genum3_0);
	}

	// Token: 0x0200001F RID: 31
	public enum MemoryAllocationFlags
	{
		// Token: 0x040000DF RID: 223
		MEM_COMMIT = 4096,
		// Token: 0x040000E0 RID: 224
		MEM_RESERVE = 8192
	}
}
