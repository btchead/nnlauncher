using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

public class MemoryHandlerCommunicator
{
	public MemoryHandlerCommunicator(ProcessMemoryHandler gclass14_1, MessageHandler gclass2_1)
	{
		this.gclass14_0 = gclass14_1;
		this.gclass2_0 = gclass2_1;
	}

	public void method_0(string string_0)
	{
		MemoryHandlerCommunicator.Class9 @class = new MemoryHandlerCommunicator.Class9();
		@class.gclass4_0 = this;
		long[] array = this.method_1();
		@class.long_0 = array[0] & -4096L;
		byte[] array2 = this.gclass14_0.method_4(@class.long_0, 4096);
		this.gclass2_0.Action_2 = new Action<byte[], int>(@class.method_0);
		this.gclass2_0.SendClientRequestNeedlePayloadMsg(this.gclass14_0.FileVersion, array, array2, (ulong)this.gclass14_0.GetMainModuleBaseAddress(), string_0);
	}

	private long[] method_1()
	{
		int num = 0;
		MemoryBasicInformation gstruct;
		KernelAPI.VirtualQueryEx(this.gclass14_0.processHandle, this.gclass14_0.process.MainModule.BaseAddress, out gstruct, Marshal.SizeOf(typeof(MemoryBasicInformation)));
		byte[] array = this.gclass14_0.method_4((long)gstruct.BaseAddress, (int)gstruct.RegionSize);
		if (array != null)
		{
			for (int i = (int)((long)(this.gclass14_0.process.MainModule.ModuleMemorySize / 4) & 4294963200L); i < (int)gstruct.RegionSize; i += 4096)
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

	private bool method_2(long long_0)
	{
		if (long_0 <= (long)this.gclass14_0.process.MainModule.BaseAddress || long_0 >= (long)this.gclass14_0.process.MainModule.BaseAddress + (long)this.gclass14_0.process.MainModule.ModuleMemorySize)
		{
			MemoryBasicInformation gstruct;
			KernelAPI.VirtualQueryEx(this.gclass14_0.processHandle, (IntPtr)long_0, out gstruct, Marshal.SizeOf(typeof(MemoryBasicInformation)));
			return gstruct.RegionSize != 0UL && gstruct.Protect != 1U && (gstruct.AllocationProtect & 64U) > 0U;
		}
		return false;
	}

	static ProcessModule smethod_0(Process process_0)
	{
		return process_0.MainModule;
	}

	static IntPtr smethod_1(ProcessModule processModule_0)
	{
		return processModule_0.BaseAddress;
	}

	static Type smethod_2(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	static int smethod_3(Type type_0)
	{
		return Marshal.SizeOf(type_0);
	}

	static int smethod_4(ProcessModule processModule_0)
	{
		return processModule_0.ModuleMemorySize;
	}

	static long smethod_5(byte[] byte_0, int int_0)
	{
		return BitConverter.ToInt64(byte_0, int_0);
	}

	static Random smethod_6()
	{
		return new Random();
	}

	static int smethod_7(Random random_0, int int_0, int int_1)
	{
		return random_0.Next(int_0, int_1);
	}

	static ulong smethod_8(byte[] byte_0, int int_0)
	{
		return BitConverter.ToUInt64(byte_0, int_0);
	}

	private ProcessMemoryHandler gclass14_0;

	private MessageHandler gclass2_0;

	[CompilerGenerated]
	private sealed class Class9
	{
		internal void method_0(byte[] byte_0, int int_0)
		{
			this.gclass4_0.gclass14_0.WriteBytesToMemory((IntPtr)this.long_0, byte_0);
			this.gclass4_0.gclass14_0.method_0(true);
			this.gclass4_0.gclass14_0.method_3((IntPtr)(this.long_0 + (long)int_0));
			Thread.Sleep(25);
			this.gclass4_0.gclass14_0.method_0(false);
		}

		static void smethod_0(int int_0)
		{
			Thread.Sleep(int_0);
		}

		public MemoryHandlerCommunicator gclass4_0;

		public long long_0;
	}
}
