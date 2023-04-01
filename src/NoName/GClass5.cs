using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

public class GClass5
{
	public GClass5(ProcessMemoryHandler processMemoryHandler, NetworkStreamWriter networkStreamWriter)
	{
		this.processMemoryHandler = processMemoryHandler;
		this.networkStreamWriter = networkStreamWriter;
	}

	public void method_0(ulong ulong_0)
	{
		StringBuilder stringBuilder = new StringBuilder(this.networkStreamWriter.LuaPayload.Length);
		for (int i = 0; i < this.networkStreamWriter.LuaPayload.Length; i++)
		{
			stringBuilder.Append((char)this.networkStreamWriter.LuaPayload[i]);
		}
		this.processMemoryHandler.WriteBytesToMemory((IntPtr)((long)ulong_0), this.networkStreamWriter.LuaPayload);
	}

	public void method_1()
	{
		GClass5.Class10 @class = new GClass5.Class10();
		@class.gclass5_0 = this;
		List<byte> list = new List<byte>();
		list.AddRange(this.networkStreamWriter.AuthPayload);
		@class.ulong_0 = (ulong)(long)this.processMemoryHandler.AllocateMemory(list.Count, MemoryProtectionFlags.PAGE_EXECUTE_READWRITE, ProcessMemoryHandler.MemoryAllocationType.MEM_COMMIT, -1L);
		this.processMemoryHandler.WriteBytesToMemory((IntPtr)((long)@class.ulong_0), list.ToArray());
		@class.ulong_1 = (ulong)this.processMemoryHandler.GetMainModuleBaseAddress();
		@class.long_0 = 0L;
		@class.long_0 = this.method_4((int)this.networkStreamWriter.List_0[35], new Action<byte[], int>(@class.method_0));
	}

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
			KernelAPI.NtResumeProcess(this.processMemoryHandler.processHandle);
			Logger.Info(".");
			Thread.Sleep(50);
			KernelAPI.NtSuspendProcess(this.processMemoryHandler.processHandle);
		}
		long num = array[0] & -4096L;
		byte[] array2 = this.processMemoryHandler.method_4(num, 4096);
		if (array2 != null)
		{
			this.networkStreamWriter.Action_1 = action_0;
			this.networkStreamWriter.SendClientRequestHookPayloadMsg(this.processMemoryHandler.FileVersion, array, array2, (ulong)this.processMemoryHandler.GetMainModuleBaseAddress());
			return num;
		}
		Logger.Error("Criticale error!");
		return 0L;
	}

	private long[] method_5(int int_0)
	{
		int num = 0;
		MemoryBasicInformation memoryBasicInfo;
		KernelAPI.VirtualQueryEx(this.processMemoryHandler.processHandle, this.processMemoryHandler.process.MainModule.BaseAddress, out memoryBasicInfo, Marshal.SizeOf(typeof(MemoryBasicInformation)));
		byte[] array = this.processMemoryHandler.method_4((long)memoryBasicInfo.BaseAddress, (int)memoryBasicInfo.RegionSize);
		if (array == null)
		{
			return null;
		}
		for (int i = (int)((long)(this.processMemoryHandler.process.MainModule.ModuleMemorySize / 4) & 4294963200L); i < (int)memoryBasicInfo.RegionSize; i += 4096)
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

	private bool method_6(long long_0)
	{
		if (long_0 <= (long)this.processMemoryHandler.process.MainModule.BaseAddress || long_0 >= (long)this.processMemoryHandler.process.MainModule.BaseAddress + (long)this.processMemoryHandler.process.MainModule.ModuleMemorySize)
		{
			MemoryBasicInformation memoryBasicInfo;
			KernelAPI.VirtualQueryEx(this.processMemoryHandler.processHandle, (IntPtr)long_0, out memoryBasicInfo, Marshal.SizeOf(typeof(MemoryBasicInformation)));
			return memoryBasicInfo.RegionSize != 0UL && memoryBasicInfo.Protect != 1U && (memoryBasicInfo.AllocationProtect & 64U) > 0U;
		}
		return false;
	}

	private ProcessMemoryHandler processMemoryHandler;

	private NetworkStreamWriter networkStreamWriter;

	private static byte[] byte_0 = new byte[]
	{
		195, 72, 191, 239, 238, 238, 238, 238, 190, 173,
		222, 72, 141, 71, byte.MaxValue, 80, 87, 72, 131, 236,
		32, 106, 80, 91, 72, 139, 79, 16, 72, 139,
		87, 8, byte.MaxValue, 39, 195
	};

	[CompilerGenerated]
	private sealed class Class10
	{
		internal void method_0(byte[] byte_0, int int_0)
		{
			byte[] bytes = BitConverter.GetBytes(this.ulong_0);
			for (int i = 0; i < bytes.Length; i++)
			{
				byte_0[int_0 + i] = bytes[i];
			}
			this.gclass5_0.processMemoryHandler.WriteBytesToMemory((IntPtr)this.long_0, byte_0);
			this.gclass5_0.processMemoryHandler.WriteBytesToMemory((IntPtr)((long)(this.ulong_1 + this.gclass5_0.networkStreamWriter.List_0[80])), BitConverter.GetBytes(this.ulong_1 + this.gclass5_0.networkStreamWriter.List_0[34] + 5UL));
		}

		public ulong ulong_0;

		public GClass5 gclass5_0;

		public long long_0;

		public ulong ulong_1;
	}
}
