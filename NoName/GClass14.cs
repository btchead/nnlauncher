using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

// Token: 0x0200001E RID: 30
public class GClass14
{
	public Process process { get; set; }

	public IntPtr processHandle { get; set; }

	public IntPtr pointer2 { get; set; }

	private long[] Int64_0 { get; set; }

	public string FileVersion => this.process.MainModule.FileVersionInfo.FileVersion;

	// Token: 0x06000171 RID: 369 RVA: 0x000029BE File Offset: 0x00000BBE
	public GClass14(Process process_1)
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

	// Token: 0x06000173 RID: 371 RVA: 0x000029E5 File Offset: 0x00000BE5
	public IntPtr OpenProcess(int accessRight)
	{
		return KernelAPI.OpenProcess(accessRight, false, process.Id);
	}

	// Token: 0x06000174 RID: 372 RVA: 0x000029F9 File Offset: 0x00000BF9
	public bool CloseHandle(IntPtr handlePointer)
	{
		return KernelAPI.CloseHandle(handlePointer);
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00004F78 File Offset: 0x00003178
	public IntPtr method_3(IntPtr intptr_2)
	{
		IntPtr intPtr;
		return KernelAPI.CreateRemoteThread(this.processHandle, IntPtr.Zero, 0U, intptr_2, IntPtr.Zero, 0, out intPtr);
	}

	// Token: 0x06000176 RID: 374 RVA: 0x00004FA0 File Offset: 0x000031A0
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
