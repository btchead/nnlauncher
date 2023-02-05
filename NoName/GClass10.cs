using System;
using System.IO;
using System.Text;

// Token: 0x02000017 RID: 23
public class GClass10
{
	// Token: 0x1700000A RID: 10
	// (get) Token: 0x060000DF RID: 223 RVA: 0x000025C1 File Offset: 0x000007C1
	public ClientServerMessageFlags GEnum0_0
	{
		get
		{
			return (ClientServerMessageFlags)this.gstruct0_0.ushort_0;
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x060000E0 RID: 224 RVA: 0x000025CE File Offset: 0x000007CE
	public uint UInt32_0
	{
		get
		{
			return this.gstruct0_0.uint_0;
		}
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00004854 File Offset: 0x00002A54
	public GClass10(byte[] byte_0, byte[] byte_1, string string_0, byte[] byte_2)
	{
		this.binaryReader_0 = new BinaryReader(new MemoryStream(byte_1));
		uint num = BitConverter.ToUInt32(byte_0, 0);
		this.gstruct0_0 = new GStruct0
		{
			ushort_0 = (ushort)byte_0[0],
			uint_0 = (num & 16777215U) >> 8
		};
		this.binaryReader_0 = new BinaryReader(new MemoryStream(this.method_13((int)(this.gstruct0_0.uint_0 - 4U))));
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

	// Token: 0x060000F2 RID: 242 RVA: 0x00002674 File Offset: 0x00000874
	static MemoryStream smethod_0(byte[] byte_0)
	{
		return new MemoryStream(byte_0);
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x0000267C File Offset: 0x0000087C
	static BinaryReader smethod_1(Stream stream_0)
	{
		return new BinaryReader(stream_0);
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x00002684 File Offset: 0x00000884
	static uint smethod_2(byte[] byte_0, int int_0)
	{
		return BitConverter.ToUInt32(byte_0, int_0);
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0000268D File Offset: 0x0000088D
	static Stream smethod_3(BinaryReader binaryReader_1)
	{
		return binaryReader_1.BaseStream;
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x00002695 File Offset: 0x00000895
	static long smethod_4(Stream stream_0)
	{
		return stream_0.Length;
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x0000269D File Offset: 0x0000089D
	static long smethod_5(Stream stream_0)
	{
		return stream_0.Position;
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x000026A5 File Offset: 0x000008A5
	static int smethod_6(Stream stream_0, byte[] byte_0, int int_0, int int_1)
	{
		return stream_0.Read(byte_0, int_0, int_1);
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x000026B0 File Offset: 0x000008B0
	static void smethod_7(Stream stream_0, long long_0)
	{
		stream_0.Position = long_0;
	}

	// Token: 0x060000FA RID: 250 RVA: 0x000026B9 File Offset: 0x000008B9
	static sbyte smethod_8(BinaryReader binaryReader_1)
	{
		return binaryReader_1.ReadSByte();
	}

	// Token: 0x060000FB RID: 251 RVA: 0x000026C1 File Offset: 0x000008C1
	static short smethod_9(BinaryReader binaryReader_1)
	{
		return binaryReader_1.ReadInt16();
	}

	// Token: 0x060000FC RID: 252 RVA: 0x000026C9 File Offset: 0x000008C9
	static int smethod_10(BinaryReader binaryReader_1)
	{
		return binaryReader_1.ReadInt32();
	}

	// Token: 0x060000FD RID: 253 RVA: 0x000026D1 File Offset: 0x000008D1
	static long smethod_11(BinaryReader binaryReader_1)
	{
		return binaryReader_1.ReadInt64();
	}

	// Token: 0x060000FE RID: 254 RVA: 0x000026D9 File Offset: 0x000008D9
	static byte smethod_12(BinaryReader binaryReader_1)
	{
		return binaryReader_1.ReadByte();
	}

	// Token: 0x060000FF RID: 255 RVA: 0x000026E1 File Offset: 0x000008E1
	static ushort smethod_13(BinaryReader binaryReader_1)
	{
		return binaryReader_1.ReadUInt16();
	}

	// Token: 0x06000100 RID: 256 RVA: 0x000026E9 File Offset: 0x000008E9
	static uint smethod_14(BinaryReader binaryReader_1)
	{
		return binaryReader_1.ReadUInt32();
	}

	// Token: 0x06000101 RID: 257 RVA: 0x000026F1 File Offset: 0x000008F1
	static ulong smethod_15(BinaryReader binaryReader_1)
	{
		return binaryReader_1.ReadUInt64();
	}

	// Token: 0x06000102 RID: 258 RVA: 0x000026F9 File Offset: 0x000008F9
	static float smethod_16(BinaryReader binaryReader_1)
	{
		return binaryReader_1.ReadSingle();
	}

	// Token: 0x06000103 RID: 259 RVA: 0x00002701 File Offset: 0x00000901
	static double smethod_17(BinaryReader binaryReader_1)
	{
		return binaryReader_1.ReadDouble();
	}

	// Token: 0x06000104 RID: 260 RVA: 0x00002709 File Offset: 0x00000909
	static StringBuilder smethod_18()
	{
		return new StringBuilder();
	}

	// Token: 0x06000105 RID: 261 RVA: 0x00002710 File Offset: 0x00000910
	static char smethod_19(BinaryReader binaryReader_1)
	{
		return binaryReader_1.ReadChar();
	}

	// Token: 0x06000106 RID: 262 RVA: 0x00002718 File Offset: 0x00000918
	static Encoding smethod_20()
	{
		return Encoding.UTF8;
	}

	// Token: 0x06000107 RID: 263 RVA: 0x0000271F File Offset: 0x0000091F
	static string smethod_21(Encoding encoding_0, byte[] byte_0)
	{
		return encoding_0.GetString(byte_0);
	}

	// Token: 0x06000108 RID: 264 RVA: 0x00002728 File Offset: 0x00000928
	static char smethod_22(string string_0)
	{
		return Convert.ToChar(string_0);
	}

	// Token: 0x06000109 RID: 265 RVA: 0x0000253F File Offset: 0x0000073F
	static StringBuilder smethod_23(StringBuilder stringBuilder_0, char char_0)
	{
		return stringBuilder_0.Append(char_0);
	}

	// Token: 0x0600010A RID: 266 RVA: 0x0000221E File Offset: 0x0000041E
	static string smethod_24(object object_0)
	{
		return object_0.ToString();
	}

	// Token: 0x0600010B RID: 267 RVA: 0x00002730 File Offset: 0x00000930
	static Encoding smethod_25()
	{
		return Encoding.Unicode;
	}

	// Token: 0x0600010C RID: 268 RVA: 0x00002737 File Offset: 0x00000937
	static string[] smethod_26(string string_0, char[] char_0)
	{
		return string_0.Split(char_0);
	}

	// Token: 0x0600010D RID: 269 RVA: 0x00002740 File Offset: 0x00000940
	static byte[] smethod_27(BinaryReader binaryReader_1, int int_0)
	{
		return binaryReader_1.ReadBytes(int_0);
	}

	// Token: 0x0600010E RID: 270 RVA: 0x00002749 File Offset: 0x00000949
	static void smethod_28(Array array_0)
	{
		Array.Reverse(array_0);
	}

	// Token: 0x0600010F RID: 271 RVA: 0x00002550 File Offset: 0x00000750
	static Encoding smethod_29()
	{
		return Encoding.ASCII;
	}

	// Token: 0x06000110 RID: 272 RVA: 0x00002560 File Offset: 0x00000760
	static string smethod_30(string[] string_0)
	{
		return string.Concat(string_0);
	}

	// Token: 0x04000099 RID: 153
	private GStruct0 gstruct0_0;

	// Token: 0x0400009A RID: 154
	private BinaryReader binaryReader_0;
}
