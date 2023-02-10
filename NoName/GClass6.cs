using System;
using System.Collections.Generic;
using System.Threading;

// Token: 0x0200000F RID: 15
public class GClass6
{
	// Token: 0x060000B7 RID: 183 RVA: 0x00002571 File Offset: 0x00000771
	public static void smethod_0(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
		binaryReaderWrapper.method_13(8);
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x0000431C File Offset: 0x0000251C
	public static void smethod_1(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
		server.ushort_1 = binaryReaderWrapper.method_5();
		server.byte_7 = binaryReaderWrapper.method_13(16);
		new Thread(new ParameterizedThreadStart(server.WaitForWorldOfWarcraft.Invoke)).Start(server.ushort_1);
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x0000436C File Offset: 0x0000256C
	public static void smethod_2(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
		ConsoleColor consoleColor = (ConsoleColor)binaryReaderWrapper.method_4();
		ushort num = binaryReaderWrapper.method_5();
		string text = binaryReaderWrapper.method_12((int)num);
		ConsoleColor foregroundColor = Console.ForegroundColor;
		Console.ForegroundColor = consoleColor;
		Console.WriteLine(text);
		Console.ForegroundColor = foregroundColor;
	}

	// Token: 0x060000BA RID: 186 RVA: 0x0000436C File Offset: 0x0000256C
	public static void smethod_3(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
		ConsoleColor consoleColor = (ConsoleColor)binaryReaderWrapper.method_4();
		ushort num = binaryReaderWrapper.method_5();
		string text = binaryReaderWrapper.method_12((int)num);
		ConsoleColor foregroundColor = Console.ForegroundColor;
		Console.ForegroundColor = consoleColor;
		Console.WriteLine(text);
		Console.ForegroundColor = foregroundColor;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x000043A8 File Offset: 0x000025A8
	public static void smethod_4(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
		int num = binaryReaderWrapper.method_2();
		server.byte_5 = binaryReaderWrapper.method_13(num);
		num = binaryReaderWrapper.method_2();
		server.byte_6 = binaryReaderWrapper.method_13(num);
		if (server.action_3 != null)
		{
			server.action_3();
		}
	}

	// Token: 0x060000BC RID: 188 RVA: 0x000043F0 File Offset: 0x000025F0
	public static void smethod_5(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
		int num = binaryReaderWrapper.method_2();
		byte[] array = binaryReaderWrapper.method_13(num);
		int num2 = binaryReaderWrapper.method_2();
		if (server.action_4 != null)
		{
			server.action_4(array, num2);
		}
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00004428 File Offset: 0x00002628
	public static void smethod_6(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
		int num = binaryReaderWrapper.method_2();
		byte[] array = binaryReaderWrapper.method_13(num);
		int num2 = binaryReaderWrapper.method_2();
		if (server.action_5 != null)
		{
			server.action_5(array, num2);
		}
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00004460 File Offset: 0x00002660
	public static void smethod_7(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
		uint num = binaryReaderWrapper.method_6();
		server.list_0 = new List<ulong>();
		int num2 = 0;
		while ((long)num2 < (long)((ulong)num))
		{
			server.list_0.Add(binaryReaderWrapper.method_7());
			num2++;
		}
		if (server.action_1 != null)
		{
			server.action_1();
		}
	}

	// Token: 0x060000BF RID: 191 RVA: 0x000044B4 File Offset: 0x000026B4
	public static void smethod_8(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
		uint num = binaryReaderWrapper.method_6();
		server.list_1 = new List<ulong>();
		int num2 = 0;
		while ((long)num2 < (long)((ulong)num))
		{
			server.list_1.Add(binaryReaderWrapper.method_7());
			num2++;
		}
		if (server.action_2 != null)
		{
			server.action_2();
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x0000257B File Offset: 0x0000077B
	public static void smethod_9(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
		binaryReaderWrapper.method_6();
		server.action_6();
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x0000213D File Offset: 0x0000033D
	public static void smethod_10(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00004508 File Offset: 0x00002708
	public static void smethod_11(BinaryReaderWrapper binaryReaderWrapper, Server server)
	{
		uint num = binaryReaderWrapper.method_6();
		byte[] array = binaryReaderWrapper.method_13(16);
		byte[] array2 = binaryReaderWrapper.method_13((int)num);
		if (server.action_8 != null)
		{
			server.action_8(array, array2);
		}
	}
}
