using System;
using System.Runtime.InteropServices;

public static class KernelAPI
{
	[DllImport("Kernel32.dll")]
	public static extern bool CloseHandle(IntPtr processHandle);

	[DllImport("ntdll.dll")]
	public static extern void NtResumeProcess(IntPtr processHandle);

	[DllImport("ntdll.dll")]
	public static extern void NtSuspendProcess(IntPtr processHandle);

	[DllImport("Kernel32.dll", SetLastError = true)]
	public static extern IntPtr OpenProcess(int processAccess, bool bInheritHandle, int processId);

	[DllImport("Kernel32.dll", SetLastError = true)]
	public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

	[DllImport("Kernel32.dll", SetLastError = true)]
	public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);

	[DllImport("kernel32.dll")]
	public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, int dwCreationFlags, out IntPtr lpThreadId);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
	public static extern IntPtr GetModuleHandle(string lpModuleName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
	public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

	[DllImport("Kernel32.dll", SetLastError = true)]
	public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MemoryBasicInformation lpBuffer, int dwLength);

	[DllImport("kernel32.dll")]
	public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, MemoryProtectionFlags flNewProtect, out MemoryProtectionFlags lpflOldProtect);

	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, int flAllocationType, MemoryProtectionFlags flProtect);

	[DllImport("kernel32.dll")]
	public static extern int GetLastError();
}
