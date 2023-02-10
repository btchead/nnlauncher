using System;
using System.IO;
using System.Text;

public class BinaryReaderWrapper
{
	public ClientServerMessageFlags messageFlagsEnum
	{
		get
		{
			return (ClientServerMessageFlags)this.messagePacketLength.messageFlag;
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x060000E0 RID: 224 RVA: 0x000025CE File Offset: 0x000007CE
	public uint UInt32_0
	{
		get
		{
			return this.messagePacketLength.messageLength;
		}
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00004854 File Offset: 0x00002A54
	public BinaryReaderWrapper(byte[] messageFlag, byte[] byte_1, string string_0, byte[] byte_2)
	{
		this.binaryReader_0 = new BinaryReader(new MemoryStream(byte_1));
		uint num = BitConverter.ToUInt32(messageFlag, 0);
		this.messagePacketLength = new MessageHeaderStruct
		{
			messageFlag = (ushort)messageFlag[0],
			messageLength = (num & 16777215U) >> 8
		};
		this.binaryReader_0 = new BinaryReader(new MemoryStream(this.method_13((int)(this.messagePacketLength.messageLength - 4U))));
		byte[] array = new byte[(int)this.binaryReader_0.BaseStream.Length];
		long position = this.binaryReader_0.BaseStream.Position;
		this.binaryReader_0.BaseStream.Read(array, 0, (int)this.binaryReader_0.BaseStream.Length);
		this.binaryReader_0.BaseStream.Position = position;
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x000025DB File Offset: 0x000007DB
	public sbyte method_0()
	{
		return this.binaryReader_0.ReadSByte();
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x000025E8 File Offset: 0x000007E8
	public short method_1()
	{
		return this.binaryReader_0.ReadInt16();
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x000025F5 File Offset: 0x000007F5
	public int method_2()
	{
		return this.binaryReader_0.ReadInt32();
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x00002602 File Offset: 0x00000802
	public long method_3()
	{
		return this.binaryReader_0.ReadInt64();
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x0000260F File Offset: 0x0000080F
	public byte method_4()
	{
		return this.binaryReader_0.ReadByte();
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x0000261C File Offset: 0x0000081C
	public ushort method_5()
	{
		return this.binaryReader_0.ReadUInt16();
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x00002629 File Offset: 0x00000829
	public uint method_6()
	{
		return this.binaryReader_0.ReadUInt32();
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x00002636 File Offset: 0x00000836
	public ulong method_7()
	{
		return this.binaryReader_0.ReadUInt64();
	}

	// Token: 0x060000EA RID: 234 RVA: 0x00002643 File Offset: 0x00000843
	public float method_8()
	{
		return this.binaryReader_0.ReadSingle();
	}

	// Token: 0x060000EB RID: 235 RVA: 0x00002650 File Offset: 0x00000850
	public double method_9()
	{
		return this.binaryReader_0.ReadDouble();
	}

	// Token: 0x060000EC RID: 236 RVA: 0x0000492C File Offset: 0x00002B2C
	public string method_10(byte byte_0 = 0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		char c = this.binaryReader_0.ReadChar();
		char c2 = Convert.ToChar(Encoding.UTF8.GetString(new byte[] { byte_0 }));
		while (c != c2)
		{
			stringBuilder.Append(c);
			c = this.binaryReader_0.ReadChar();
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060000ED RID: 237 RVA: 0x0000265D File Offset: 0x0000085D
	public string method_11()
	{
		return this.method_10(0);
	}

	// Token: 0x060000EE RID: 238 RVA: 0x00004988 File Offset: 0x00002B88
	public string method_12(int int_0)
	{
		byte[] array = this.method_13(int_0 * 2 + 2);
		byte[] array2 = new byte[int_0 * 2 + 2];
		for (int i = 0; i < int_0 * 2; i++)
		{
			if (array[i] != 0)
			{
				array2[i] = array[i];
			}
		}
		return Encoding.Unicode.GetString(array2).Split(new char[1])[0];
	}

	// Token: 0x060000EF RID: 239 RVA: 0x00002666 File Offset: 0x00000866
	public byte[] method_13(int int_0)
	{
		return this.binaryReader_0.ReadBytes(int_0);
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x000049E0 File Offset: 0x00002BE0
	public string method_14(int int_0)
	{
		byte[] array = this.binaryReader_0.ReadBytes(int_0);
		Array.Reverse(array);
		return Encoding.ASCII.GetString(array);
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x00004A0C File Offset: 0x00002C0C
	public string method_15()
	{
		byte[] array = new byte[4];
		for (int i = 0; i < 4; i++)
		{
			array[i] = this.method_4();
		}
		return string.Concat(new string[]
		{
			array[0].ToString(),
			".",
			array[1].ToString(),
			".",
			array[2].ToString(),
			".",
			array[3].ToString()
		});
	}

	// Token: 0x04000099 RID: 153
	private MessageHeaderStruct messagePacketLength;

	// Token: 0x0400009A RID: 154
	private BinaryReader binaryReader_0;
}
