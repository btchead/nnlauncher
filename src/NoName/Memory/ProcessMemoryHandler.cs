using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

public class ProcessMemoryHandler
{
	public Process process { get; set; }

	public IntPtr processHandle { get; set; }

	public IntPtr pointer2 { get; set; }

	private long[] Int64_0 { get; set; }

	public string FileVersion => this.process.MainModule.FileVersionInfo.FileVersion;

	public ProcessMemoryHandler(Process process_1)
	{
		this.process = process_1;
		this.processHandle = this.OpenProcess(65535);
		this.Int64_0 = null;
	}

	public void method_0(bool bool_0)
	{
		byte[] array = new byte[] { 133, 201, 117, 24 };
		if (bool_0)
		{
			array = new byte[] { 144, 72, byte.MaxValue, 194 };
		}
		IntPtr intPtr = KernelAPI.GetProcAddress(KernelAPI.GetModuleHandle("KERNEL32"), "BaseThreadInitThunk") + 4;
		this.WriteBytesToMemory(intPtr, array);
	}

	public IntPtr OpenProcess(int accessRight)
	{
		return KernelAPI.OpenProcess(accessRight, false, process.Id);
	}

	public bool CloseHandle(IntPtr handlePointer)
	{
		return KernelAPI.CloseHandle(handlePointer);
	}

	public IntPtr method_3(IntPtr intptr_2)
	{
		IntPtr intPtr;
		return KernelAPI.CreateRemoteThread(this.processHandle, IntPtr.Zero, 0U, intptr_2, IntPtr.Zero, 0, out intPtr);
	}

	public byte[] method_4(long long_1, int int_0)
	{
		if (this.process.HasExited)
		{
			return null;
		}
		IntPtr zero = IntPtr.Zero;
		byte[] array = new byte[int_0];
		KernelAPI.ReadProcessMemory(this.processHandle, (IntPtr)long_1, array, array.Length, out zero);
		if (zero.ToInt32() != int_0)
		{
			return null;
		}
		return array;
	}

	public byte[] method_5(IntPtr intptr_2, int int_0)
	{
		return this.method_4((long)intptr_2, int_0);
	}

	public long method_6(IntPtr intptr_2)
	{
		return BitConverter.ToInt64(this.method_4((long)intptr_2, 8), 0);
	}

	public float method_7(IntPtr intptr_2)
	{
		return BitConverter.ToSingle(this.method_4((long)intptr_2, 4), 0);
	}

	public void method_8(IntPtr intptr_2, ref byte[] byte_0)
	{
		byte_0 = this.method_4((long)intptr_2, byte_0.Length);
	}

	public string method_9(IntPtr intptr_2, int int_0 = 32)
	{
		byte[] array = this.method_4((long)intptr_2, int_0);
		if (array == null)
		{
			return "Err";
		}
		return Encoding.UTF8.GetString(array).Split(new char[1]).FirstOrDefault<string>();
	}

	public bool WriteBytesToMemory(IntPtr targetPointer, byte[] dataToWrite)
	{
		if (process.HasExited)
		{
			return false;
		}
		IntPtr numberOfBytesWritten = IntPtr.Zero;
		bool isSuccessful = KernelAPI.WriteProcessMemory(processHandle, targetPointer, dataToWrite, dataToWrite.Length, out numberOfBytesWritten);
		return isSuccessful && (numberOfBytesWritten.ToInt32() == dataToWrite.Length);
	}

	public bool WriteLongToMemory(IntPtr memoryPointer, long value)
	{
		return WriteBytesToMemory(memoryPointer, BitConverter.GetBytes(value));
	}

	public bool WriteIntToMemory(IntPtr memoryPointer, int value)
	{
		return WriteBytesToMemory(memoryPointer, BitConverter.GetBytes(value));
	}

	public bool WriteStringToMemory(IntPtr memoryPointer, string stringValue)
	{
		return WriteBytesToMemory(memoryPointer, Encoding.UTF8.GetBytes(stringValue));
	}

	public long GetMainModuleBaseAddress()
	{
		return (long)process.MainModule.BaseAddress;
	}

	public IntPtr GetFunctionAddressFromModule(IntPtr moduleHandle, string functionName)
	{
		return KernelAPI.GetProcAddress(moduleHandle, functionName);
	}

	public IntPtr AllocateMemory(int size, MemoryProtectionFlags protection, MemoryAllocationType allocationType = MemoryAllocationType.MEM_COMMIT, long address = -1L)
	{
		IntPtr allocatedAddress = IntPtr.Zero;
		if (address != -1L)
		{
			allocatedAddress = (IntPtr)address;
		}
		return KernelAPI.VirtualAllocEx(processHandle, allocatedAddress, size, (int)allocationType, protection);
	}

	public enum MemoryAllocationType
	{
		MEM_COMMIT = 4096,
		MEM_RESERVE = 8192
	}
}
