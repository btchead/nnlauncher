using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

// Token: 0x0200000D RID: 13
public class GClass5
{
	// Token: 0x06000099 RID: 153 RVA: 0x00002508 File Offset: 0x00000708
	public GClass5(ProcessMemoryHandler gclass14_1, MessageHandler gclass2_1)
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
		this.gclass14_0.WriteBytesToMemory((IntPtr)((long)ulong_0), this.gclass2_0.Byte_1);
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00003D34 File Offset: 0x00001F34
	public void method_1()
	{
		GClass5.Class10 @class = new GClass5.Class10();
		@class.gclass5_0 = this;
		List<byte> list = new List<byte>();
		list.AddRange(this.gclass2_0.Byte_0);
		@class.ulong_0 = (ulong)(long)this.gclass14_0.AllocateMemory(list.Count, MemoryProtectionFlags.PAGE_EXECUTE_READWRITE, ProcessMemoryHandler.MemoryAllocationType.MEM_COMMIT, -1L);
		this.gclass14_0.WriteBytesToMemory((IntPtr)((long)@class.ulong_0), list.ToArray());
		@class.ulong_1 = (ulong)this.gclass14_0.GetMainModuleBaseAddress();
		@class.long_0 = 0L;
		@class.long_0 = this.method_4((int)this.gclass2_0.List_0[35], new Action<byte[], int>(@class.method_0));
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
			KernelAPI.NtResumeProcess(this.gclass14_0.processHandle);
			Console.Write(".");
			Thread.Sleep(50);
			KernelAPI.NtSuspendProcess(this.gclass14_0.processHandle);
		}
		long num = array[0] & -4096L;
		byte[] array2 = this.gclass14_0.method_4(num, 4096);
		if (array2 != null)
		{
			this.gclass2_0.Action_1 = action_0;
			this.gclass2_0.SendClientRequestHookPayloadMsg(this.gclass14_0.FileVersion, array, array2, (ulong)this.gclass14_0.GetMainModuleBaseAddress());
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
		KernelAPI.VirtualQueryEx(this.gclass14_0.processHandle, this.gclass14_0.process.MainModule.BaseAddress, out gstruct, Marshal.SizeOf(typeof(GStruct1)));
		byte[] array = this.gclass14_0.method_4((long)gstruct.ulong_0, (int)gstruct.ulong_2);
		if (array == null)
		{
			return null;
		}
		for (int i = (int)((long)(this.gclass14_0.process.MainModule.ModuleMemorySize / 4) & 4294963200L); i < (int)gstruct.ulong_2; i += 4096)
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
		if (long_0 <= (long)this.gclass14_0.process.MainModule.BaseAddress || long_0 >= (long)this.gclass14_0.process.MainModule.BaseAddress + (long)this.gclass14_0.process.MainModule.ModuleMemorySize)
		{
			GStruct1 gstruct;
			KernelAPI.VirtualQueryEx(this.gclass14_0.processHandle, (IntPtr)long_0, out gstruct, Marshal.SizeOf(typeof(GStruct1)));
			return gstruct.ulong_2 != 0UL && gstruct.uint_2 != 1U && (gstruct.uint_0 & 64U) > 0U;
		}
		return false;
	}

	// Token: 0x04000025 RID: 37
	private ProcessMemoryHandler gclass14_0;

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
			this.gclass5_0.gclass14_0.WriteBytesToMemory((IntPtr)this.long_0, byte_0);
			this.gclass5_0.gclass14_0.WriteBytesToMemory((IntPtr)((long)(this.ulong_1 + this.gclass5_0.gclass2_0.List_0[80])), BitConverter.GetBytes(this.ulong_1 + this.gclass5_0.gclass2_0.List_0[34] + 5UL));
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
