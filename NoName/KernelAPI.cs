using System;
using System.Runtime.InteropServices;

// Token: 0x0200001A RID: 26
public static class KernelAPI
{
	// Token: 0x0600015B RID: 347
	[DllImport("Kernel32.dll")]
	public static extern bool CloseHandle(IntPtr intptr_0);

	// Token: 0x0600015C RID: 348
	[DllImport("ntdll.dll")]
	public static extern void NtResumeProcess(IntPtr intptr_0);

	// Token: 0x0600015D RID: 349
	[DllImport("ntdll.dll")]
	public static extern void NtSuspendProcess(IntPtr intptr_0);

	// Token: 0x0600015E RID: 350
	[DllImport("Kernel32.dll", SetLastError = true)]
	public static extern IntPtr OpenProcess(int int_0, bool bool_0, int int_1);

	// Token: 0x0600015F RID: 351
	[DllImport("Kernel32.dll", SetLastError = true)]
	public static extern bool ReadProcessMemory(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, int int_0, out IntPtr intptr_2);

	// Token: 0x06000160 RID: 352
	[DllImport("Kernel32.dll", SetLastError = true)]
	public static extern bool WriteProcessMemory(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, int int_0, out IntPtr intptr_2);

	// Token: 0x06000161 RID: 353
	[DllImport("kernel32.dll")]
	public static extern IntPtr CreateRemoteThread(IntPtr intptr_0, IntPtr intptr_1, uint uint_0, IntPtr intptr_2, IntPtr intptr_3, int int_0, out IntPtr intptr_4);

	// Token: 0x06000162 RID: 354
	[DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
	public static extern IntPtr GetModuleHandle(string string_0);

	// Token: 0x06000163 RID: 355
	[DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
	public static extern IntPtr GetProcAddress(IntPtr intptr_0, string string_0);

	// Token: 0x06000164 RID: 356
	[DllImport("Kernel32.dll", SetLastError = true)]
	public static extern int VirtualQueryEx(IntPtr intptr_0, IntPtr intptr_1, out GStruct1 gstruct1_0, int int_0);

	// Token: 0x06000165 RID: 357
	[DllImport("kernel32.dll")]
	public static extern bool VirtualProtectEx(IntPtr intptr_0, IntPtr intptr_1, int int_0, MemoryProtectionFlags genum3_0, out MemoryProtectionFlags genum3_1);

	// Token: 0x06000166 RID: 358
	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr VirtualAllocEx(IntPtr intptr_0, IntPtr intptr_1, int int_0, int int_1, MemoryProtectionFlags genum3_0);

	// Token: 0x06000167 RID: 359
	[DllImport("kernel32.dll")]
	public static extern int GetLastError();
}
