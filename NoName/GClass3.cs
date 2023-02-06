using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

// Token: 0x0200000A RID: 10
public class GClass3
{
	// Token: 0x0600007C RID: 124 RVA: 0x00002499 File Offset: 0x00000699
	public GClass3(GClass14 gclass14_1, MessageHandler gclass2_1)
	{
		this.gclass14_0 = gclass14_1;
		this.gclass2_0 = gclass2_1;
	}

	// Token: 0x0600007D RID: 125 RVA: 0x0000380C File Offset: 0x00001A0C
	public void method_0()
	{
		List<IntPtr> list = new List<IntPtr>();
		bool flag = true;
		while (this.bool_0)
		{
			ulong num = 0UL;
			int num2 = 4500;
			TimeSpan timeSpan = TimeSpan.FromSeconds(180.0);
			TimeSpan timeSpan2 = DateTime.Now - this.gclass14_0.Process_0.StartTime;
			if (timeSpan2 < timeSpan)
			{
				Thread.Sleep(timeSpan - timeSpan2);
			}
			int num3;
			do
			{
				if (this.gclass14_0.Process_0.HasExited)
				{
					Process.GetCurrentProcess().Kill();
				}
				IntPtr intPtr = (IntPtr)((long)num);
				GStruct1 gstruct;
				num3 = KernelAPI.VirtualQueryEx(this.gclass14_0.IntPtr_0, intPtr, out gstruct, Marshal.SizeOf(typeof(GStruct1)));
				num += gstruct.ulong_2;
				if (num == 0UL)
				{
					goto IL_18B;
				}
				if (gstruct.uint_2 == 64U && gstruct.ulong_2 > 1024UL && !list.Contains(intPtr))
				{
					if (!flag)
					{
						Console.WriteLine("Possible warden module detected, exiting!", ConsoleColor.Yellow);
						byte[] array = new byte[gstruct.ulong_2];
						IntPtr intPtr2;
						KernelAPI.ReadProcessMemory(this.gclass14_0.IntPtr_0, intPtr, array, array.Length, out intPtr2);
						if ((long)intPtr2 == (long)gstruct.ulong_2)
						{
							this.gclass2_0.IsClientWardenUploadMsg_Sent(array);
						}
						Thread.Sleep(1500);
						Process.GetCurrentProcess().Kill();
					}
					list.Add(intPtr);
				}
			}
			while (num3 != 0);
			flag = false;
			Thread.Sleep(num2);
			continue;
			IL_18B:
			Console.WriteLine("Fatal error, im out!");
			return;
		}
	}

	// Token: 0x0600007E RID: 126 RVA: 0x000024B6 File Offset: 0x000006B6
	public void method_1()
	{
		this.bool_0 = false;
	}

	// Token: 0x0600007F RID: 127 RVA: 0x000022CB File Offset: 0x000004CB
	static DateTime smethod_0(Process process_0)
	{
		return process_0.StartTime;
	}

	// Token: 0x06000080 RID: 128 RVA: 0x000024BF File Offset: 0x000006BF
	static void smethod_1(TimeSpan timeSpan_0)
	{
		Thread.Sleep(timeSpan_0);
	}

	// Token: 0x06000081 RID: 129 RVA: 0x0000231C File Offset: 0x0000051C
	static bool smethod_2(Process process_0)
	{
		return process_0.HasExited;
	}

	// Token: 0x06000082 RID: 130 RVA: 0x0000232C File Offset: 0x0000052C
	static Process smethod_3()
	{
		return Process.GetCurrentProcess();
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00002324 File Offset: 0x00000524
	static void smethod_4(Process process_0)
	{
		process_0.Kill();
	}

	// Token: 0x06000084 RID: 132 RVA: 0x000024C7 File Offset: 0x000006C7
	static Type smethod_5(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	// Token: 0x06000085 RID: 133 RVA: 0x000024CF File Offset: 0x000006CF
	static int smethod_6(Type type_0)
	{
		return Marshal.SizeOf(type_0);
	}

	// Token: 0x06000086 RID: 134 RVA: 0x000022B2 File Offset: 0x000004B2
	static void smethod_7(string string_0)
	{
		Console.WriteLine(string_0);
	}

	// Token: 0x06000087 RID: 135 RVA: 0x000024D7 File Offset: 0x000006D7
	static void smethod_8(string string_0, object object_0)
	{
		Console.WriteLine(string_0, object_0);
	}

	// Token: 0x06000088 RID: 136 RVA: 0x000022E2 File Offset: 0x000004E2
	static void smethod_9(int int_0)
	{
		Thread.Sleep(int_0);
	}

	// Token: 0x0400001E RID: 30
	private GClass14 gclass14_0;

	// Token: 0x0400001F RID: 31
	private MessageHandler gclass2_0;

	// Token: 0x04000020 RID: 32
	private bool bool_0 = true;
}
