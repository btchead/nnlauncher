using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

// Token: 0x0200000D RID: 13
public class GClass5
{
	// Token: 0x06000099 RID: 153 RVA: 0x00002508 File Offset: 0x00000708
	public GClass5(GClass14 gclass14_1, MessageHandler gclass2_1)
	{
		this.gclass14_0 = gclass14_1;
		this.gclass2_0 = gclass2_1;
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00003CC8 File Offset: 0x00001EC8
	public void method_0(ulong ulong_0)
	{
		StringBuilder stringBuilder = new StringBuilder(this.gclass2_0.Byte_1.Length);
		for (int i = 0; i < this.gclass2_0.Byte_1.Length; i++)
		{
			stringBuilder.Append((char)this.gclass2_0.Byte_1[i]);
		}
		this.gclass14_0.method_10((IntPtr)((long)ulong_0), this.gclass2_0.Byte_1);
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00003D34 File Offset: 0x00001F34
	public void method_1()
	{
		GClass5.Class10 @class = new GClass5.Class10();
		@class.gclass5_0 = this;
		List<byte> list = new List<byte>();
		list.AddRange(this.gclass2_0.Byte_0);
		@class.ulong_0 = (ulong)(long)this.gclass14_0.method_16(list.Count, MemoryProtectionFlags.PAGE_EXECUTE_READWRITE, GClass14.MemoryAllocationFlags.MEM_COMMIT, -1L);
		this.gclass14_0.method_10((IntPtr)((long)@class.ulong_0), list.ToArray());
		@class.ulong_1 = (ulong)this.gclass14_0.method_14();
		@class.long_0 = 0L;
		@class.long_0 = this.method_4((int)this.gclass2_0.List_0[35], new Action<byte[], int>(@class.method_0));
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00003DFC File Offset: 0x00001FFC
	private void method_2(byte[] byte_1, byte[] byte_2)
	{
		for (int i = 0; i < byte_2.Length; i += 2)
		{
			int num = i;
			byte_2[num] ^= byte_1[i % 16];
		}
		ulong num2 = (ulong)(long)this.gclass14_0.method_16(byte_2.Length, MemoryProtectionFlags.PAGE_READWRITE, GClass14.MemoryAllocationFlags.MEM_COMMIT, -1L);
		this.gclass14_0.method_10((IntPtr)((long)num2), byte_2);
	}

	// Token: 0x0600009D RID: 157 RVA: 0x00003E60 File Offset: 0x00002060
	private void method_3(ulong ulong_0, string string_0, ulong ulong_1)
	{
		List<byte> list = new List<byte>();
		list.AddRange(GClass5.byte_0);
		ulong num = (ulong)(long)this.gclass14_0.method_16(GClass5.byte_0.Length + string_0.Length + 30, MemoryProtectionFlags.PAGE_EXECUTE_READWRITE, GClass14.MemoryAllocationFlags.MEM_COMMIT, -1L);
		byte[] bytes = BitConverter.GetBytes(num + (ulong)((long)list.Count));
		for (int i = 0; i < bytes.Length; i++)
		{
			list[3 + i] = bytes[i];
		}
		list.AddRange(BitConverter.GetBytes(ulong_0));
		list.AddRange(BitConverter.GetBytes(ulong_1));
		list.AddRange(BitConverter.GetBytes(num + (ulong)(list.Count + 8)));
		list.AddRange(Encoding.ASCII.GetBytes(string_0));
		list.Add(0);
		this.gclass14_0.method_10((IntPtr)((long)num), list.ToArray());
		this.gclass14_0.method_0(true);
		this.gclass14_0.method_3((IntPtr)((long)num));
		Thread.Sleep(50);
		this.gclass14_0.method_0(false);
		Console.WriteLine(string.Concat(new string[]
		{
			"Registerd LuaFunction ",
			string_0,
			" from ",
			num.ToString("X"),
			" on addr ",
			ulong_1.ToString("X2")
		}));
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00003FB8 File Offset: 0x000021B8
	public long method_4(int int_0, Action<byte[], int> action_0)
	{
		long[] array;
		for (;;)
		{
			array = this.method_5(int_0);
			if (array != null)
			{
				break;
			}
			KernelAPI.NtResumeProcess(this.gclass14_0.IntPtr_0);
			Console.Write(".");
			Thread.Sleep(50);
			KernelAPI.NtSuspendProcess(this.gclass14_0.IntPtr_0);
		}
		long num = array[0] & -4096L;
		byte[] array2 = this.gclass14_0.method_4(num, 4096);
		if (array2 != null)
		{
			this.gclass2_0.Action_1 = action_0;
			this.gclass2_0.IsClientRequestHookPayloadMsg_Sent(this.gclass14_0.String_0, array, array2, (ulong)this.gclass14_0.method_14());
			return num;
		}
		Console.WriteLine("Criticale error!");
		return 0L;
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00004070 File Offset: 0x00002270
	private long[] method_5(int int_0)
	{
		int num = 0;
		GStruct1 gstruct;
		KernelAPI.VirtualQueryEx(this.gclass14_0.IntPtr_0, this.gclass14_0.Process_0.MainModule.BaseAddress, out gstruct, Marshal.SizeOf(typeof(GStruct1)));
		byte[] array = this.gclass14_0.method_4((long)gstruct.ulong_0, (int)gstruct.ulong_2);
		if (array == null)
		{
			return null;
		}
		for (int i = (int)((long)(this.gclass14_0.Process_0.MainModule.ModuleMemorySize / 4) & 4294963200L); i < (int)gstruct.ulong_2; i += 4096)
		{
			long num2 = BitConverter.ToInt64(array, i);
			if (this.method_6(num2))
			{
				for (int j = i; j < array.Length; j += 8)
				{
					long num3 = BitConverter.ToInt64(array, j);
					if (num3 != 0L && !this.method_6(num3))
					{
						List<long> list = new List<long>();
						num2 = BitConverter.ToInt64(array, int_0);
						list.Add(num2);
						ulong num4 = (ulong)(num2 & -4096L);
						for (int k = i; k < j; k += 8)
						{
							ulong num5 = BitConverter.ToUInt64(array, k);
							if ((num5 & 18446744073709547520UL) == num4)
							{
								list.Add((long)num5);
							}
						}
						return list.ToArray();
					}
					num++;
				}
			}
		}
		return null;
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x000041B8 File Offset: 0x000023B8
	private bool method_6(long long_0)
	{
		if (long_0 <= (long)this.gclass14_0.Process_0.MainModule.BaseAddress || long_0 >= (long)this.gclass14_0.Process_0.MainModule.BaseAddress + (long)this.gclass14_0.Process_0.MainModule.ModuleMemorySize)
		{
			GStruct1 gstruct;
			KernelAPI.VirtualQueryEx(this.gclass14_0.IntPtr_0, (IntPtr)long_0, out gstruct, Marshal.SizeOf(typeof(GStruct1)));
			return gstruct.ulong_2 != 0UL && gstruct.uint_2 != 1U && (gstruct.uint_0 & 64U) > 0U;
		}
		return false;
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x00002537 File Offset: 0x00000737
	static StringBuilder smethod_0(int int_0)
	{
		return new StringBuilder(int_0);
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x0000253F File Offset: 0x0000073F
	static StringBuilder smethod_1(StringBuilder stringBuilder_0, char char_0)
	{
		return stringBuilder_0.Append(char_0);
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x000022F9 File Offset: 0x000004F9
	static int smethod_2(string string_0)
	{
		return string_0.Length;
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00002548 File Offset: 0x00000748
	static byte[] smethod_3(ulong ulong_0)
	{
		return BitConverter.GetBytes(ulong_0);
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00002550 File Offset: 0x00000750
	static Encoding smethod_4()
	{
		return Encoding.ASCII;
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x00002557 File Offset: 0x00000757
	static byte[] smethod_5(Encoding encoding_0, string string_0)
	{
		return encoding_0.GetBytes(string_0);
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x000022E2 File Offset: 0x000004E2
	static void smethod_6(int int_0)
	{
		Thread.Sleep(int_0);
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00002560 File Offset: 0x00000760
	static string smethod_7(string[] string_0)
	{
		return string.Concat(string_0);
	}

	// Token: 0x060000AA RID: 170 RVA: 0x000022B2 File Offset: 0x000004B2
	static void smethod_8(string string_0)
	{
		Console.WriteLine(string_0);
	}

	// Token: 0x060000AB RID: 171 RVA: 0x000022F1 File Offset: 0x000004F1
	static void smethod_9(string string_0)
	{
		Console.Write(string_0);
	}

	// Token: 0x060000AC RID: 172 RVA: 0x00002195 File Offset: 0x00000395
	static ProcessModule smethod_10(Process process_0)
	{
		return process_0.MainModule;
	}

	// Token: 0x060000AD RID: 173 RVA: 0x000021BD File Offset: 0x000003BD
	static IntPtr smethod_11(ProcessModule processModule_0)
	{
		return processModule_0.BaseAddress;
	}

	// Token: 0x060000AE RID: 174 RVA: 0x000024C7 File Offset: 0x000006C7
	static Type smethod_12(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	// Token: 0x060000AF RID: 175 RVA: 0x000024CF File Offset: 0x000006CF
	static int smethod_13(Type type_0)
	{
		return Marshal.SizeOf(type_0);
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x000021C5 File Offset: 0x000003C5
	static int smethod_14(ProcessModule processModule_0)
	{
		return processModule_0.ModuleMemorySize;
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x000024F6 File Offset: 0x000006F6
	static long smethod_15(byte[] byte_1, int int_0)
	{
		return BitConverter.ToInt64(byte_1, int_0);
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x000024FF File Offset: 0x000006FF
	static ulong smethod_16(byte[] byte_1, int int_0)
	{
		return BitConverter.ToUInt64(byte_1, int_0);
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x00002568 File Offset: 0x00000768
	static void smethod_17(Array array_0, RuntimeFieldHandle runtimeFieldHandle_0)
	{
		RuntimeHelpers.InitializeArray(array_0, runtimeFieldHandle_0);
	}

	// Token: 0x04000025 RID: 37
	private GClass14 gclass14_0;

	// Token: 0x04000026 RID: 38
	private MessageHandler gclass2_0;

	// Token: 0x04000027 RID: 39
	private static byte[] byte_0 = new byte[]
	{
		195, 72, 191, 239, 238, 238, 238, 238, 190, 173,
		222, 72, 141, 71, byte.MaxValue, 80, 87, 72, 131, 236,
		32, 106, 80, 91, 72, 139, 79, 16, 72, 139,
		87, 8, byte.MaxValue, 39, 195
	};

	// Token: 0x0200000E RID: 14
	[CompilerGenerated]
	private sealed class Class10
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x0000426C File Offset: 0x0000246C
		internal void method_0(byte[] byte_0, int int_0)
		{
			byte[] bytes = BitConverter.GetBytes(this.ulong_0);
			for (int i = 0; i < bytes.Length; i++)
			{
				byte_0[int_0 + i] = bytes[i];
			}
			this.gclass5_0.gclass14_0.method_10((IntPtr)this.long_0, byte_0);
			this.gclass5_0.gclass14_0.method_10((IntPtr)((long)(this.ulong_1 + this.gclass5_0.gclass2_0.List_0[80])), BitConverter.GetBytes(this.ulong_1 + this.gclass5_0.gclass2_0.List_0[34] + 5UL));
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00002548 File Offset: 0x00000748
		static byte[] smethod_0(ulong ulong_2)
		{
			return BitConverter.GetBytes(ulong_2);
		}

		// Token: 0x04000028 RID: 40
		public ulong ulong_0;

		// Token: 0x04000029 RID: 41
		public GClass5 gclass5_0;

		// Token: 0x0400002A RID: 42
		public long long_0;

		// Token: 0x0400002B RID: 43
		public ulong ulong_1;
	}
}
