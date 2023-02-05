using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;

// Token: 0x02000003 RID: 3
internal class Class5
{
	// Token: 0x06000021 RID: 33 RVA: 0x00002DE4 File Offset: 0x00000FE4
	private static void Main(string[] string_2)
	{
		Class6 @class = new Class6();
		Console.Title = mGetRandomTitle();
		if (string_2.Length >= 1 && string_2[0] != ".")
		{
			Class5.string_0 = string_2[0];
		}
		else
		{
			if (!File.Exists("license.txt"))
			{
				Console.WriteLine("Usage: NoName.exe LICENSE_KEY [or create a 'license.txt' file]");
				return;
			}
			Class5.string_0 = File.ReadAllText("license.txt");
		}
		if (string_2.Length >= 2 && !int.TryParse(string_2[1], out Class5.int_0))
		{
			Class5.int_0 = -1;
		}
		if (string_2.Length >= 3)
		{
			string text = string_2[2];
			if (File.Exists(text))
			{
				Class5.string_1 = text;
			}
		}
		if (Class5.string_1 == "" && File.Exists("path.txt"))
		{
			string text2 = File.ReadAllText(Class5.string_1);
			if (File.Exists(text2))
			{
				Class5.string_1 = text2;
			}
		}
		string text3 = "";
		@class.bool_0 = false;
		@class.string_0 = new string[] { "Wow", "WowT", "WowClassic" };
		if (text3 != "")
		{
			@class.string_0 = new string[] { text3 };
		}
		@class.list_0 = new List<Process>();
		foreach (string text4 in @class.string_0)
		{
			@class.list_0.AddRange(Process.GetProcessesByName(text4));
		}
		foreach (Process process in @class.list_0)
		{
			if (!(process.StartTime < DateTime.Now))
			{
			}
		}
		@class.dateTime_0 = DateTime.Now.AddSeconds(20.0);
		@class.process_0 = null;
		@class.gclass12_0 = new GClass12(new Action(Class5.smethod_2));
		GClass2 gclass = new GClass2(@class.gclass12_0);
		if (gclass.method_1())
		{
			gclass.Action_3 = new Action<object>(@class.method_0);
			@class.bool_1 = true;
			if (Class5.int_0 != 0 && Class5.string_1 != "" && File.Exists(Class5.string_1))
			{
				for (int k = 0; k < Class5.int_0; k++)
				{
					while (!@class.bool_1)
					{
						Thread.Sleep(100);
					}
					@class.bool_1 = false;
					gclass.method_2(Class5.string_0, Class5.smethod_3());
					Thread.Sleep(4000);
				}
			}
			else
			{
				gclass.method_2(Class5.string_0, Class5.smethod_3());
			}
			Thread.Sleep(-1);
			return;
		}
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Failed to connect!");
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.WriteLine("Press any key to exit...");
		Console.ReadLine();
	}

	private static string mGetRandomTitle()
    {
		Random random = new Random();
		byte[] array = new byte[random.Next(5, 19)];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)random.Next(0, 255);
		}
		return Convert.ToBase64String(array).Replace("=", "").Replace("=", "");
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00003114 File Offset: 0x00001314
	private static void smethod_1(object object_0)
	{
		Console.Clear();
		GClass2 gclass = (GClass2)object_0;
		Console.Write("Username: ");
		string text = Console.ReadLine();
		Console.Write("Password: ");
		string text2 = Console.ReadLine();
		Console.Clear();
		Console.WriteLine("Username: " + text);
		Console.WriteLine("Password: " + new string('*', text2.Length) + "\n");
		gclass.method_2(text, text2);
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00003198 File Offset: 0x00001398
	private static void smethod_2()
	{
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine("Connection to the server was lost!");
		if (Class5.bool_0)
		{
			Console.WriteLine("Force-killing all instances to prevent detection!");
			Console.ForegroundColor = ConsoleColor.Magenta;
			foreach (int num in Class5.list_0)
			{
				try
				{
					Process processById = Process.GetProcessById(num);
					if (!processById.HasExited)
					{
						Console.WriteLine(string.Format("Killing process with PID: {0}", num));
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
	private static string smethod_3()
	{
		string text = "SOFTWARE\\Microsoft\\Cryptography";
		string text2 = "MachineGuid";
		string text3;
		using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
		{
			using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
			{
				if (registryKey2 == null)
				{
					throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
				}
				object value = registryKey2.GetValue(text2);
				if (value == null)
				{
					throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
				}
				text3 = value.ToString();
			}
		}
		return text3;
	}

	// Token: 0x06000027 RID: 39 RVA: 0x0000226E File Offset: 0x0000046E
	static Random smethod_4()
	{
		return new Random();
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00002275 File Offset: 0x00000475
	static int smethod_5(Random random_0, int int_1, int int_2)
	{
		return random_0.Next(int_1, int_2);
	}

	// Token: 0x06000029 RID: 41 RVA: 0x0000227F File Offset: 0x0000047F
	static string smethod_6(byte[] byte_0)
	{
		return Convert.ToBase64String(byte_0);
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00002287 File Offset: 0x00000487
	static string smethod_7(string string_2, string string_3, string string_4)
	{
		return string_2.Replace(string_3, string_4);
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00002291 File Offset: 0x00000491
	static void smethod_8(string string_2)
	{
		Console.Title = string_2;
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00002299 File Offset: 0x00000499
	static bool smethod_9(string string_2, string string_3)
	{
		return string_2 != string_3;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x000022A2 File Offset: 0x000004A2
	static bool smethod_10(string string_2)
	{
		return File.Exists(string_2);
	}

	// Token: 0x0600002E RID: 46 RVA: 0x000022AA File Offset: 0x000004AA
	static string smethod_11(string string_2)
	{
		return File.ReadAllText(string_2);
	}

	// Token: 0x0600002F RID: 47 RVA: 0x000022B2 File Offset: 0x000004B2
	static void smethod_12(string string_2)
	{
		Console.WriteLine(string_2);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x000022BA File Offset: 0x000004BA
	static bool smethod_13(string string_2, string string_3)
	{
		return string_2 == string_3;
	}

	// Token: 0x06000031 RID: 49 RVA: 0x000022C3 File Offset: 0x000004C3
	static Process[] smethod_14(string string_2)
	{
		return Process.GetProcessesByName(string_2);
	}

	// Token: 0x06000032 RID: 50 RVA: 0x000022CB File Offset: 0x000004CB
	static DateTime smethod_15(Process process_0)
	{
		return process_0.StartTime;
	}

	// Token: 0x06000033 RID: 51 RVA: 0x000022D3 File Offset: 0x000004D3
	static void smethod_16(ConsoleColor consoleColor_0)
	{
		Console.ForegroundColor = consoleColor_0;
	}

	// Token: 0x06000034 RID: 52 RVA: 0x000022DB File Offset: 0x000004DB
	static string smethod_17()
	{
		return Console.ReadLine();
	}

	// Token: 0x06000035 RID: 53 RVA: 0x000022E2 File Offset: 0x000004E2
	static void smethod_18(int int_1)
	{
		Thread.Sleep(int_1);
	}

	// Token: 0x06000036 RID: 54 RVA: 0x000022EA File Offset: 0x000004EA
	static void smethod_19()
	{
		Console.Clear();
	}

	// Token: 0x06000037 RID: 55 RVA: 0x000022F1 File Offset: 0x000004F1
	static void smethod_20(string string_2)
	{
		Console.Write(string_2);
	}

	// Token: 0x06000038 RID: 56 RVA: 0x000021B4 File Offset: 0x000003B4
	static string smethod_21(string string_2, string string_3)
	{
		return string_2 + string_3;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x000022F9 File Offset: 0x000004F9
	static int smethod_22(string string_2)
	{
		return string_2.Length;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00002301 File Offset: 0x00000501
	static string smethod_23(char char_0, int int_1)
	{
		return new string(char_0, int_1);
	}

	// Token: 0x0600003B RID: 59 RVA: 0x0000230A File Offset: 0x0000050A
	static string smethod_24(string string_2, string string_3, string string_4)
	{
		return string_2 + string_3 + string_4;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002314 File Offset: 0x00000514
	static Process smethod_25(int int_1)
	{
		return Process.GetProcessById(int_1);
	}

	// Token: 0x0600003D RID: 61 RVA: 0x0000231C File Offset: 0x0000051C
	static bool smethod_26(Process process_0)
	{
		return process_0.HasExited;
	}

	// Token: 0x0600003E RID: 62 RVA: 0x000021FC File Offset: 0x000003FC
	static string smethod_27(string string_2, object object_0)
	{
		return string.Format(string_2, object_0);
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00002324 File Offset: 0x00000524
	static void smethod_28(Process process_0)
	{
		process_0.Kill();
	}

	// Token: 0x06000040 RID: 64 RVA: 0x0000232C File Offset: 0x0000052C
	static Process smethod_29()
	{
		return Process.GetCurrentProcess();
	}

	// Token: 0x06000041 RID: 65 RVA: 0x000021EA File Offset: 0x000003EA
	static RegistryKey smethod_30(RegistryHive registryHive_0, RegistryView registryView_0)
	{
		return RegistryKey.OpenBaseKey(registryHive_0, registryView_0);
	}

	// Token: 0x06000042 RID: 66 RVA: 0x000021F3 File Offset: 0x000003F3
	static RegistryKey smethod_31(RegistryKey registryKey_0, string string_2)
	{
		return registryKey_0.OpenSubKey(string_2);
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00002205 File Offset: 0x00000405
	static KeyNotFoundException smethod_32(string string_2)
	{
		return new KeyNotFoundException(string_2);
	}

	// Token: 0x06000044 RID: 68 RVA: 0x0000220D File Offset: 0x0000040D
	static object smethod_33(RegistryKey registryKey_0, string string_2)
	{
		return registryKey_0.GetValue(string_2);
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00002216 File Offset: 0x00000416
	static IndexOutOfRangeException smethod_34(string string_2)
	{
		return new IndexOutOfRangeException(string_2);
	}

	// Token: 0x06000046 RID: 70 RVA: 0x0000221E File Offset: 0x0000041E
	static string smethod_35(object object_0)
	{
		return object_0.ToString();
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00002226 File Offset: 0x00000426
	static void smethod_36(IDisposable idisposable_0)
	{
		idisposable_0.Dispose();
	}

	// Token: 0x04000008 RID: 8
	public const ushort ushort_0 = 105;

	// Token: 0x04000009 RID: 9
	private static List<int> list_0 = new List<int>();

	// Token: 0x0400000A RID: 10
	private static bool bool_0 = false;

	// Token: 0x0400000B RID: 11
	private static bool bool_1 = false;

	// Token: 0x0400000C RID: 12
	private static string string_0 = "";

	// Token: 0x0400000D RID: 13
	private static bool bool_2 = false;

	// Token: 0x0400000E RID: 14
	private static string string_1 = "";

	// Token: 0x0400000F RID: 15
	private static int int_0 = -1;

	// Token: 0x02000004 RID: 4
	[CompilerGenerated]
	private sealed class Class6
	{
		// Token: 0x06000049 RID: 73 RVA: 0x0000325C File Offset: 0x0000145C
		internal void method_0(object object_0)
		{
			Class5.Struct6 @struct;
			@struct.ushort_0 = (ushort)object_0;
			if (@struct.ushort_0 == 0)
			{
				Thread.Sleep(2000);
				return;
			}
			if (Class5.int_0 != 0 && Class5.string_1 != "" && File.Exists(Class5.string_1))
			{
				try
				{
					Process process = Process.Start(new ProcessStartInfo(Class5.string_1)
					{
						UseShellExecute = false
					});
					Console.WriteLine("Launched " + process.Id.ToString("X"));
					Thread.Sleep(2500);
					this.method_1(process, ref @struct);
					return;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					return;
				}
			}
			Console.WriteLine("Waiting for World of Warcraft...");
			bool flag = true;
			while (flag)
			{
				List<Process> list = new List<Process>();
				foreach (string text in this.string_0)
				{
					list.AddRange(Process.GetProcessesByName(text));
				}
				using (List<Process>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Class5.Class8 @class = new Class5.Class8();
						@class.process_0 = enumerator.Current;
						if (this.list_0.FindIndex(new Predicate<Process>(@class.method_0)) == -1)
						{
							this.list_0.Add(@class.process_0);
							if (!Class5.list_0.Contains(@class.process_0.Id) && (@class.process_0.HandleCount <= 0 || !@class.process_0.HasExited))
							{
								Class5.list_0.Add(@class.process_0.Id);
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
				if (this.dateTime_0 < DateTime.Now || this.process_0 != null)
				{
					Thread.Sleep(12500);
					Process.GetCurrentProcess().Kill();
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000034A4 File Offset: 0x000016A4
		internal void method_1(Process process_1, ref Class5.Struct6 struct6_0)
		{
			Class5.Class7 @class = new Class5.Class7();
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

		// Token: 0x0600004B RID: 75 RVA: 0x000022E2 File Offset: 0x000004E2
		static void smethod_0(int int_0)
		{
			Thread.Sleep(int_0);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002299 File Offset: 0x00000499
		static bool smethod_1(string string_1, string string_2)
		{
			return string_1 != string_2;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000022A2 File Offset: 0x000004A2
		static bool smethod_2(string string_1)
		{
			return File.Exists(string_1);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002333 File Offset: 0x00000533
		static ProcessStartInfo smethod_3(string string_1)
		{
			return new ProcessStartInfo(string_1);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000233B File Offset: 0x0000053B
		static void smethod_4(ProcessStartInfo processStartInfo_0, bool bool_2)
		{
			processStartInfo_0.UseShellExecute = bool_2;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002344 File Offset: 0x00000544
		static Process smethod_5(ProcessStartInfo processStartInfo_0)
		{
			return Process.Start(processStartInfo_0);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000234C File Offset: 0x0000054C
		static int smethod_6(Process process_1)
		{
			return process_1.Id;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000021B4 File Offset: 0x000003B4
		static string smethod_7(string string_1, string string_2)
		{
			return string_1 + string_2;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000022B2 File Offset: 0x000004B2
		static void smethod_8(string string_1)
		{
			Console.WriteLine(string_1);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000221E File Offset: 0x0000041E
		static string smethod_9(object object_0)
		{
			return object_0.ToString();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000022C3 File Offset: 0x000004C3
		static Process[] smethod_10(string string_1)
		{
			return Process.GetProcessesByName(string_1);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002354 File Offset: 0x00000554
		static int smethod_11(Process process_1)
		{
			return process_1.HandleCount;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000231C File Offset: 0x0000051C
		static bool smethod_12(Process process_1)
		{
			return process_1.HasExited;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000232C File Offset: 0x0000052C
		static Process smethod_13()
		{
			return Process.GetCurrentProcess();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002324 File Offset: 0x00000524
		static void smethod_14(Process process_1)
		{
			process_1.Kill();
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000235C File Offset: 0x0000055C
		static string smethod_15(Process process_1)
		{
			return process_1.ProcessName;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002364 File Offset: 0x00000564
		static string smethod_16(string string_1, string string_2, string string_3, string string_4)
		{
			return string_1 + string_2 + string_3 + string_4;
		}

		// Token: 0x04000010 RID: 16
		public GClass12 gclass12_0;

		// Token: 0x04000011 RID: 17
		public bool bool_0;

		// Token: 0x04000012 RID: 18
		public bool bool_1;

		// Token: 0x04000013 RID: 19
		public string[] string_0;

		// Token: 0x04000014 RID: 20
		public List<Process> list_0;

		// Token: 0x04000015 RID: 21
		public Process process_0;

		// Token: 0x04000016 RID: 22
		public DateTime dateTime_0;
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
				this.class6_0.bool_0 = true;
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
			this.class6_0.bool_0 = true;
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
		public Class5.Class6 class6_0;
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

		// Token: 0x06000066 RID: 102 RVA: 0x0000234C File Offset: 0x0000054C
		static int smethod_0(Process process_1)
		{
			return process_1.Id;
		}

		// Token: 0x0400001C RID: 28
		public Process process_0;
	}
}
