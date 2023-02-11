using System;
using System.Collections.Generic;
using System.Threading;

public class GClass6
{
	public static void smethod_0(BinaryMessageReader binaryReaderWrapper, Server server)
	{
		binaryReaderWrapper.ReadBytes(8);
	}

	public static void smethod_1(BinaryMessageReader binaryReaderWrapper, Server server)
	{
		server.ushort_1 = binaryReaderWrapper.ReadUInt16();
		server.byte_7 = binaryReaderWrapper.ReadBytes(16);
		new Thread(new ParameterizedThreadStart(server.WaitForWorldOfWarcraft.Invoke)).Start(server.ushort_1);
	}

	public static void smethod_2(BinaryMessageReader binaryReaderWrapper, Server server)
	{
		ConsoleColor consoleColor = (ConsoleColor)binaryReaderWrapper.ReadByte();
		ushort num = binaryReaderWrapper.ReadUInt16();
		string text = binaryReaderWrapper.ReadString((int)num);
		ConsoleColor foregroundColor = Console.ForegroundColor;
		Console.ForegroundColor = consoleColor;
		Console.WriteLine(text);
		Console.ForegroundColor = foregroundColor;
	}

	public static void smethod_3(BinaryMessageReader binaryReaderWrapper, Server server)
	{
		ConsoleColor consoleColor = (ConsoleColor)binaryReaderWrapper.ReadByte();
		ushort num = binaryReaderWrapper.ReadUInt16();
        string text = binaryReaderWrapper.ReadString((int)num);
        ConsoleColor foregroundColor = Console.ForegroundColor;
		Console.ForegroundColor = consoleColor;
		Console.WriteLine(text);
		Console.ForegroundColor = foregroundColor;
	}

	public static void smethod_4(BinaryMessageReader binaryReaderWrapper, Server server)
	{
		int num = binaryReaderWrapper.ReadInt32();
		server.byte_5 = binaryReaderWrapper.ReadBytes(num);
		num = binaryReaderWrapper.ReadInt32();
		server.byte_6 = binaryReaderWrapper.ReadBytes(num);
		if (server.action_3 != null)
		{
			server.action_3();
		}
	}

	public static void smethod_5(BinaryMessageReader binaryReaderWrapper, Server server)
	{
		int num = binaryReaderWrapper.ReadInt32();
		byte[] array = binaryReaderWrapper.ReadBytes(num);
		int num2 = binaryReaderWrapper.ReadInt32();
		if (server.action_4 != null)
		{
			server.action_4(array, num2);
		}
	}

	public static void smethod_6(BinaryMessageReader binaryReaderWrapper, Server server)
	{
		int num = binaryReaderWrapper.ReadInt32();
		byte[] array = binaryReaderWrapper.ReadBytes(num);
		int num2 = binaryReaderWrapper.ReadInt32();
		if (server.action_5 != null)
		{
			server.action_5(array, num2);
		}
	}

	public static void smethod_7(BinaryMessageReader binaryReaderWrapper, Server server)
	{
		uint num = binaryReaderWrapper.ReadUInt32();
		server.list_0 = new List<ulong>();
		int num2 = 0;
		while ((long)num2 < (long)((ulong)num))
		{
			server.list_0.Add(binaryReaderWrapper.ReadUInt64());
			num2++;
		}
		if (server.action_1 != null)
		{
			server.action_1();
		}
	}

	public static void smethod_8(BinaryMessageReader binaryReaderWrapper, Server server)
	{
		uint num = binaryReaderWrapper.ReadUInt32();
		server.list_1 = new List<ulong>();
		int num2 = 0;
		while ((long)num2 < (long)((ulong)num))
		{
			server.list_1.Add(binaryReaderWrapper.ReadUInt64());
			num2++;
		}
		if (server.action_2 != null)
		{
			server.action_2();
		}
	}

	public static void smethod_9(BinaryMessageReader binaryReaderWrapper, Server server)
	{
		binaryReaderWrapper.ReadUInt32();
		server.action_6();
	}

	public static void smethod_10(BinaryMessageReader binaryReaderWrapper, Server server)
	{
	}

	public static void smethod_11(BinaryMessageReader binaryReaderWrapper, Server server)
	{
		uint num = binaryReaderWrapper.ReadUInt32();
		byte[] array = binaryReaderWrapper.ReadBytes(16);
		byte[] array2 = binaryReaderWrapper.ReadBytes((int)num);
		if (server.action_8 != null)
		{
			server.action_8(array, array2);
		}
	}
}
