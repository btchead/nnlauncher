using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;

// Token: 0x02000003 RID: 3
internal class Application
{
	// Token: 0x06000021 RID: 33 RVA: 0x00002DE4 File Offset: 0x00000FE4
	private static void Main()
	{
		Console.Title = mGenerateRandomTitle();

		Class6 classInstance = new Class6();

		if (!File.Exists(licenseFileName))
        {
            Console.WriteLine("Usage: NoName.exe LICENSE_KEY [or create a 'license.txt' file]");
            return;
        }
		else
        {
			licenseKey = File.ReadAllText(licenseFileName);
        }

		classInstance.isInjected = false;
		classInstance.processList = new List<Process>();

		foreach (string processName in classInstance.wowProcessNames)
		{
			classInstance.processList.AddRange(Process.GetProcessesByName(processName));
		}

		classInstance.maxProcessWaitTimestamp = DateTime.Now.AddSeconds(20.0);
		classInstance.process_0 = null;
		classInstance.gclass12_0 = new GClass12(new Action(Application.mEmergencyApplicationExit));
		GClass2 gclass = new GClass2(classInstance.gclass12_0);
		if (gclass.method_1())
		{
			gclass.Action_3 = new Action<object>(classInstance.method_0);
			classInstance.bool_1 = true;
			gclass.method_2(Application.licenseKey, Application.mGetMachineGUID());
			Thread.Sleep(-1);
			return;
		}
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Failed to connect!");
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine("Press any key to exit...");
		Console.ReadLine();
	}

	private static string mGenerateRandomTitle()
    {
		Random random = new Random();
		byte[] array = new byte[random.Next(5, 19)];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)random.Next(0, 255);
		}
		return Convert.ToBase64String(array).Replace("=", "").Replace("=", "");
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00003198 File Offset: 0x00001398
	private static void mEmergencyApplicationExit()
	{
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Connection to the server was lost!");
		if (Application.isWowLaunched)
		{
			Console.WriteLine("Force-killing all instances to prevent detection!");
			Console.ForegroundColor = ConsoleColor.Magenta;
			foreach (int processID in Application.pidList)
			{
				try
				{
					Process processById = Process.GetProcessById(processID);
					if (!processById.HasExited)
					{
						Console.WriteLine(string.Format("Killing process with PID: {0}", processID));
						processById.Kill();
					}
				}
				catch
				{
				}
			}
			Console.ForegroundColor = ConsoleColor.Gray;
		}
		Process.GetCurrentProcess().Kill();
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00002D40 File Offset: 0x00000F40
	private static string mGetMachineGUID()
	{
		string registryPath = "SOFTWARE\\Microsoft\\Cryptography";
		string targetKey = "MachineGuid";
		string machineGUID;
		using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
		{
			using (RegistryKey registryKey2 = registryKey.OpenSubKey(registryPath))
			{
				if (registryKey2 == null)
				{
					throw new KeyNotFoundException(string.Format("Key Not Found: {0}", registryPath));
				}
				object value = registryKey2.GetValue(targetKey);
				if (value == null)
				{
					throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", targetKey));
				}
				machineGUID = value.ToString();
			}
		}
		return machineGUID;
	}

	// Token: 0x04000008 RID: 8
	public const ushort ushort_0 = 105;

	// Token: 0x04000009 RID: 9
	private static List<int> pidList = new List<int>();

	// Token: 0x0400000A RID: 10
	private static readonly bool isWowLaunched = false;

	// Token: 0x0400000C RID: 12
	private static string licenseKey = "";

	private static string licenseFileName = "license.txt";

	// Token: 0x02000004 RID: 4
	[CompilerGenerated]
	private sealed class Class6
	{
		// Token: 0x06000049 RID: 73 RVA: 0x0000325C File Offset: 0x0000145C
		internal void method_0(object object_0)
		{
			Application.Struct6 @struct;
			@struct.ushort_0 = (ushort)object_0;
			if (@struct.ushort_0 == 0)
			{
				Thread.Sleep(2000);
				return;
			}
			Console.WriteLine("Waiting for World of Warcraft...");
			bool flag = true;
			while (flag)
			{
				List<Process> list = new List<Process>();
				foreach (string text in this.wowProcessNames)
				{
					list.AddRange(Process.GetProcessesByName(text));
				}
				using (List<Process>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Application.Class8 @class = new Application.Class8();
						@class.process_0 = enumerator.Current;
						if (this.processList.FindIndex(new Predicate<Process>(@class.method_0)) == -1)
						{
							this.processList.Add(@class.process_0);
							if (!Application.pidList.Contains(@class.process_0.Id) && (@class.process_0.HandleCount <= 0 || !@class.process_0.HasExited))
							{
								Application.pidList.Add(@class.process_0.Id);
								if (this.process_0 == null)
								{
									this.process_0 = @class.process_0;
								}
								this.method_1(@class.process_0, ref @struct);
								flag = false;
							}
						}
					}
				}
				Thread.Sleep(1000);
				if (this.maxProcessWaitTimestamp < DateTime.Now || this.process_0 != null)
				{
					Thread.Sleep(12500);
					Process.GetCurrentProcess().Kill();
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000034A4 File Offset: 0x000016A4
		internal void method_1(Process process_1, ref Application.Struct6 struct6_0)
		{
			Application.Class7 @class = new Application.Class7();
			@class.class6_0 = this;
			@class.process_0 = process_1;
			try
			{
				@class.bool_0 = struct6_0.ushort_0 == 2;
				@class.gclass0_0 = new GClass0(new GClass14(@class.process_0), this.gclass12_0);
				if (@class.bool_0)
				{
					@class.gclass0_0.method_10();
				}
				@class.gclass0_0.method_0(new Action(@class.method_0));
			}
			catch (Exception)
			{
				Console.WriteLine("Failed to inject " + @class.process_0.ProcessName + " " + @class.process_0.Id.ToString("X"));
			}
		}

		// Token: 0x04000010 RID: 16
		public GClass12 gclass12_0;

		// Token: 0x04000011 RID: 17
		public bool isInjected;

		// Token: 0x04000012 RID: 18
		public bool bool_1;

		// Token: 0x04000013 RID: 19
		public readonly string[] wowProcessNames = { "Wow", "WowT", "WowClassic" };

		// Token: 0x04000014 RID: 20
		public List<Process> processList;

		// Token: 0x04000015 RID: 21
		public Process process_0;

		// Token: 0x04000016 RID: 22
		public DateTime maxProcessWaitTimestamp;
	}

	// Token: 0x02000005 RID: 5
	[CompilerGenerated]
	[StructLayout(LayoutKind.Auto)]
	private struct Struct6
	{
		// Token: 0x04000017 RID: 23
		public ushort ushort_0;
	}

	// Token: 0x02000006 RID: 6
	[CompilerGenerated]
	private sealed class Class7
	{
		// Token: 0x0600005D RID: 93 RVA: 0x0000356C File Offset: 0x0000176C
		internal void method_0()
		{
			if (!this.bool_0)
			{
				Thread.Sleep(5000);
				this.gclass0_0.method_4();
				this.class6_0.isInjected = true;
				Console.WriteLine("Injected into " + this.process_0.ProcessName + " " + this.process_0.Id.ToString("X"));
				this.gclass0_0.method_6();
				return;
			}
			this.gclass0_0.method_1("Punani", new Action(this.method_1));
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003608 File Offset: 0x00001808
		internal void method_1()
		{
			this.gclass0_0.method_5();
			this.class6_0.isInjected = true;
			this.class6_0.bool_1 = true;
			Console.WriteLine("Injected into " + this.process_0.ProcessName + " " + this.process_0.Id.ToString("X"));
			this.gclass0_0.method_6();
			if (this.bool_0)
			{
				this.gclass0_0.method_11();
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000022E2 File Offset: 0x000004E2
		static void smethod_0(int int_0)
		{
			Thread.Sleep(int_0);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000235C File Offset: 0x0000055C
		static string smethod_1(Process process_1)
		{
			return process_1.ProcessName;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000234C File Offset: 0x0000054C
		static int smethod_2(Process process_1)
		{
			return process_1.Id;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002364 File Offset: 0x00000564
		static string smethod_3(string string_0, string string_1, string string_2, string string_3)
		{
			return string_0 + string_1 + string_2 + string_3;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000022B2 File Offset: 0x000004B2
		static void smethod_4(string string_0)
		{
			Console.WriteLine(string_0);
		}

		// Token: 0x04000018 RID: 24
		public Process process_0;

		// Token: 0x04000019 RID: 25
		public bool bool_0;

		// Token: 0x0400001A RID: 26
		public GClass0 gclass0_0;

		// Token: 0x0400001B RID: 27
		public Application.Class6 class6_0;
	}

	// Token: 0x02000007 RID: 7
	[CompilerGenerated]
	private sealed class Class8
	{
		// Token: 0x06000065 RID: 101 RVA: 0x0000236F File Offset: 0x0000056F
		internal bool method_0(Process process_1)
		{
			return process_1.Id == this.process_0.Id;
		}
		// Token: 0x0400001C RID: 28
		public Process process_0;
	}
}
