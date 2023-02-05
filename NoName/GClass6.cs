using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x0200000F RID: 15
public class GClass6
{
	// Token: 0x060000B7 RID: 183 RVA: 0x00002571 File Offset: 0x00000771
	public static void smethod_0(GClass10 gclass10_0, GClass12 gclass12_0)
	{
		gclass10_0.method_13(8);
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x0000431C File Offset: 0x0000251C
	public static void smethod_1(GClass10 gclass10_0, GClass12 gclass12_0)
	{
		gclass12_0.ushort_1 = gclass10_0.method_5();
		gclass12_0.byte_7 = gclass10_0.method_13(16);
		new Thread(new ParameterizedThreadStart(gclass12_0.action_7.Invoke)).Start(gclass12_0.ushort_1);
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x0000436C File Offset: 0x0000256C
	public static void smethod_2(GClass10 gclass10_0, GClass12 gclass12_0)
	{
		ConsoleColor consoleColor = (ConsoleColor)gclass10_0.method_4();
		ushort num = gclass10_0.method_5();
		string text = gclass10_0.method_12((int)num);
		ConsoleColor foregroundColor = Console.ForegroundColor;
		Console.ForegroundColor = consoleColor;
		Console.WriteLine(text);
		Console.ForegroundColor = foregroundColor;
	}

	// Token: 0x060000BA RID: 186 RVA: 0x0000436C File Offset: 0x0000256C
	public static void smethod_3(GClass10 gclass10_0, GClass12 gclass12_0)
	{
		ConsoleColor consoleColor = (ConsoleColor)gclass10_0.method_4();
		ushort num = gclass10_0.method_5();
		string text = gclass10_0.method_12((int)num);
		ConsoleColor foregroundColor = Console.ForegroundColor;
		Console.ForegroundColor = consoleColor;
		Console.WriteLine(text);
		Console.ForegroundColor = foregroundColor;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x000043A8 File Offset: 0x000025A8
	public static void smethod_4(GClass10 gclass10_0, GClass12 gclass12_0)
	{
		int num = gclass10_0.method_2();
		gclass12_0.byte_5 = gclass10_0.method_13(num);
		num = gclass10_0.method_2();
		gclass12_0.byte_6 = gclass10_0.method_13(num);
		if (gclass12_0.action_3 != null)
		{
			gclass12_0.action_3();
		}
	}

	// Token: 0x060000BC RID: 188 RVA: 0x000043F0 File Offset: 0x000025F0
	public static void smethod_5(GClass10 gclass10_0, GClass12 gclass12_0)
	{
		int num = gclass10_0.method_2();
		byte[] array = gclass10_0.method_13(num);
		int num2 = gclass10_0.method_2();
		if (gclass12_0.action_4 != null)
		{
			gclass12_0.action_4(array, num2);
		}
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00004428 File Offset: 0x00002628
	public static void smethod_6(GClass10 gclass10_0, GClass12 gclass12_0)
	{
		int num = gclass10_0.method_2();
		byte[] array = gclass10_0.method_13(num);
		int num2 = gclass10_0.method_2();
		if (gclass12_0.action_5 != null)
		{
			gclass12_0.action_5(array, num2);
		}
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00004460 File Offset: 0x00002660
	public static void smethod_7(GClass10 gclass10_0, GClass12 gclass12_0)
	{
		uint num = gclass10_0.method_6();
		gclass12_0.list_0 = new List<ulong>();
		int num2 = 0;
		while ((long)num2 < (long)((ulong)num))
		{
			gclass12_0.list_0.Add(gclass10_0.method_7());
			num2++;
		}
		if (gclass12_0.action_1 != null)
		{
			gclass12_0.action_1();
		}
	}

	// Token: 0x060000BF RID: 191 RVA: 0x000044B4 File Offset: 0x000026B4
	public static void smethod_8(GClass10 gclass10_0, GClass12 gclass12_0)
	{
		uint num = gclass10_0.method_6();
		gclass12_0.list_1 = new List<ulong>();
		int num2 = 0;
		while ((long)num2 < (long)((ulong)num))
		{
			gclass12_0.list_1.Add(gclass10_0.method_7());
			num2++;
		}
		if (gclass12_0.action_2 != null)
		{
			gclass12_0.action_2();
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x0000257B File Offset: 0x0000077B
	public static void smethod_9(GClass10 gclass10_0, GClass12 gclass12_0)
	{
		gclass10_0.method_6();
		gclass12_0.action_6();
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x0000213D File Offset: 0x0000033D
	public static void smethod_10(GClass10 gclass10_0, GClass12 gclass12_0)
	{
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00004508 File Offset: 0x00002708
	public static void smethod_11(GClass10 gclass10_0, GClass12 gclass12_0)
	{
		uint num = gclass10_0.method_6();
		byte[] array = gclass10_0.method_13(16);
		byte[] array2 = gclass10_0.method_13((int)num);
		if (gclass12_0.action_8 != null)
		{
			gclass12_0.action_8(array, array2);
		}
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x0000258F File Offset: 0x0000078F
	static Thread smethod_12(ParameterizedThreadStart parameterizedThreadStart_0)
	{
		return new Thread(parameterizedThreadStart_0);
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00002597 File Offset: 0x00000797
	static void smethod_13(Thread thread_0, object object_0)
	{
		thread_0.Start(object_0);
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x000025A0 File Offset: 0x000007A0
	static ConsoleColor smethod_14()
	{
		return Console.ForegroundColor;
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x000022D3 File Offset: 0x000004D3
	static void smethod_15(ConsoleColor consoleColor_0)
	{
		Console.ForegroundColor = consoleColor_0;
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x000022B2 File Offset: 0x000004B2
	static void smethod_16(string string_0)
	{
		Console.WriteLine(string_0);
	}
}
