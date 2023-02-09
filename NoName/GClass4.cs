using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// Token: 0x0200000B RID: 11
public class GClass4
{
	// Token: 0x06000089 RID: 137 RVA: 0x000024E0 File Offset: 0x000006E0
	public GClass4(GClass14 gclass14_1, MessageHandler gclass2_1)
	{
		this.gclass14_0 = gclass14_1;
		this.gclass2_0 = gclass2_1;
	}

	// Token: 0x0600008A RID: 138 RVA: 0x000039B0 File Offset: 0x00001BB0
	public void method_0(string string_0)
	{
		GClass4.Class9 @class = new GClass4.Class9();
		@class.gclass4_0 = this;
		long[] array = this.method_1();
		@class.long_0 = array[0] & -4096L;
		byte[] array2 = this.gclass14_0.method_4(@class.long_0, 4096);
		this.gclass2_0.Action_2 = new Action<byte[], int>(@class.method_0);
		this.gclass2_0.SendClientRequestNeedlePayloadMsg(this.gclass14_0.FileVersion, array, array2, (ulong)this.gclass14_0.GetMainModuleBaseAddress(), string_0);
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00003A38 File Offset: 0x00001C38
	private long[] method_1()
	{
		int num = 0;
		GStruct1 gstruct;
		KernelAPI.VirtualQueryEx(this.gclass14_0.processHandle, this.gclass14_0.process.MainModule.BaseAddress, out gstruct, Marshal.SizeOf(typeof(GStruct1)));
		byte[] array = this.gclass14_0.method_4((long)gstruct.ulong_0, (int)gstruct.ulong_2);
		if (array != null)
		{
			for (int i = (int)((long)(this.gclass14_0.process.MainModule.ModuleMemorySize / 4) & 4294963200L); i < (int)gstruct.ulong_2; i += 4096)
			{
				long num2 = BitConverter.ToInt64(array, i);
				if (this.method_2(num2))
				{
					for (int j = i; j < array.Length; j += 8)
					{
						long num3 = BitConverter.ToInt64(array, j);
						if (num3 != 0L && !this.method_2(num3))
						{
							Random random = new Random();
							do
							{
								num2 = BitConverter.ToInt64(array, i + random.Next(0, num) * 8);
							}
							while (!this.method_2(num2));
							List<long> list = new List<long>();
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
		return null;
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00003BA0 File Offset: 0x00001DA0
	private bool method_2(long long_0)
	{
		if (long_0 <= (long)this.gclass14_0.process.MainModule.BaseAddress || long_0 >= (long)this.gclass14_0.process.MainModule.BaseAddress + (long)this.gclass14_0.process.MainModule.ModuleMemorySize)
		{
			GStruct1 gstruct;
			KernelAPI.VirtualQueryEx(this.gclass14_0.processHandle, (IntPtr)long_0, out gstruct, Marshal.SizeOf(typeof(GStruct1)));
			return gstruct.ulong_2 != 0UL && gstruct.uint_2 != 1U && (gstruct.uint_0 & 64U) > 0U;
		}
		return false;
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00002195 File Offset: 0x00000395
	static ProcessModule smethod_0(Process process_0)
	{
		return process_0.MainModule;
	}

	// Token: 0x0600008E RID: 142 RVA: 0x000021BD File Offset: 0x000003BD
	static IntPtr smethod_1(ProcessModule processModule_0)
	{
		return processModule_0.BaseAddress;
	}

	// Token: 0x0600008F RID: 143 RVA: 0x000024C7 File Offset: 0x000006C7
	static Type smethod_2(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	// Token: 0x06000090 RID: 144 RVA: 0x000024CF File Offset: 0x000006CF
	static int smethod_3(Type type_0)
	{
		return Marshal.SizeOf(type_0);
	}

	// Token: 0x06000091 RID: 145 RVA: 0x000021C5 File Offset: 0x000003C5
	static int smethod_4(ProcessModule processModule_0)
	{
		return processModule_0.ModuleMemorySize;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x000024F6 File Offset: 0x000006F6
	static long smethod_5(byte[] byte_0, int int_0)
	{
		return BitConverter.ToInt64(byte_0, int_0);
	}

	// Token: 0x06000093 RID: 147 RVA: 0x0000226E File Offset: 0x0000046E
	static Random smethod_6()
	{
		return new Random();
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00002275 File Offset: 0x00000475
	static int smethod_7(Random random_0, int int_0, int int_1)
	{
		return random_0.Next(int_0, int_1);
	}

	// Token: 0x06000095 RID: 149 RVA: 0x000024FF File Offset: 0x000006FF
	static ulong smethod_8(byte[] byte_0, int int_0)
	{
		return BitConverter.ToUInt64(byte_0, int_0);
	}

	// Token: 0x04000021 RID: 33
	private GClass14 gclass14_0;

	// Token: 0x04000022 RID: 34
	private MessageHandler gclass2_0;

	// Token: 0x0200000C RID: 12
	[CompilerGenerated]
	private sealed class Class9
	{
		// Token: 0x06000097 RID: 151 RVA: 0x00003C54 File Offset: 0x00001E54
		internal void method_0(byte[] byte_0, int int_0)
		{
			this.gclass4_0.gclass14_0.WriteBytesToMemory((IntPtr)this.long_0, byte_0);
			this.gclass4_0.gclass14_0.method_0(true);
			this.gclass4_0.gclass14_0.method_3((IntPtr)(this.long_0 + (long)int_0));
			Thread.Sleep(25);
			this.gclass4_0.gclass14_0.method_0(false);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000022E2 File Offset: 0x000004E2
		static void smethod_0(int int_0)
		{
			Thread.Sleep(int_0);
		}

		// Token: 0x04000023 RID: 35
		public GClass4 gclass4_0;

		// Token: 0x04000024 RID: 36
		public long long_0;
	}
}
