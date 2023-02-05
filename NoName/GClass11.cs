using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

// Token: 0x02000018 RID: 24
public class GClass11 : BinaryWriter
{
	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000111 RID: 273 RVA: 0x00002751 File Offset: 0x00000951
	public uint UInt32_0
	{
		get
		{
			return this.UInt32_1 + 4U;
		}
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000112 RID: 274 RVA: 0x0000275B File Offset: 0x0000095B
	public uint UInt32_1
	{
		get
		{
			return (uint)this.BaseStream.Length;
		}
	}

	// Token: 0x06000113 RID: 275 RVA: 0x00002769 File Offset: 0x00000969
	public GClass11(ClientServerMessageFlags genum0_1)
		: base(new MemoryStream())
	{
		this.genum0_0 = genum0_1;
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00004A98 File Offset: 0x00002C98
	public byte[] method_0(byte[] byte_1 = null)
	{
		byte[] array = new byte[4];
		byte[] bytes = BitConverter.GetBytes(this.UInt32_0);
		byte[] bytes2 = BitConverter.GetBytes((ushort)this.genum0_0);
		array[0] = bytes2[0];
		array[1] = bytes[0];
		array[2] = bytes[1];
		array[3] = bytes[2];
		byte[] array2 = new byte[this.UInt32_1];
		this.Seek(0, SeekOrigin.Begin);
		int num = 0;
		while ((long)num < (long)((ulong)this.UInt32_1))
		{
			array2[num] = (byte)this.BaseStream.ReadByte();
			num++;
		}
		List<byte> list = new List<byte>();
		list.AddRange(array);
		list.AddRange(array2);
		return list.ToArray();
	}

	// Token: 0x06000115 RID: 277 RVA: 0x0000277D File Offset: 0x0000097D
	public void method_1(int int_0)
	{
		base.Seek(int_0, SeekOrigin.Begin);
	}

	// Token: 0x06000116 RID: 278 RVA: 0x00002788 File Offset: 0x00000988
	public void method_2(sbyte sbyte_0)
	{
		base.Write(sbyte_0);
	}

	// Token: 0x06000117 RID: 279 RVA: 0x00002791 File Offset: 0x00000991
	public void method_3(short short_0)
	{
		base.Write(short_0);
	}

	// Token: 0x06000118 RID: 280 RVA: 0x0000279A File Offset: 0x0000099A
	public void method_4(int int_0)
	{
		base.Write(int_0);
	}

	// Token: 0x06000119 RID: 281 RVA: 0x000027A3 File Offset: 0x000009A3
	public void method_5(long long_0)
	{
		base.Write(long_0);
	}

	// Token: 0x0600011A RID: 282 RVA: 0x000027AC File Offset: 0x000009AC
	public void method_6(byte byte_1)
	{
		base.Write(byte_1);
	}

	// Token: 0x0600011B RID: 283 RVA: 0x000027B5 File Offset: 0x000009B5
	public void method_7(ushort ushort_0)
	{
		base.Write(ushort_0);
	}

	// Token: 0x0600011C RID: 284 RVA: 0x000027BE File Offset: 0x000009BE
	public void method_8(uint uint_0)
	{
		base.Write(uint_0);
	}

	// Token: 0x0600011D RID: 285 RVA: 0x000027C7 File Offset: 0x000009C7
	public void method_9(ulong ulong_0)
	{
		base.Write(ulong_0);
	}

	// Token: 0x0600011E RID: 286 RVA: 0x000027D0 File Offset: 0x000009D0
	public void method_10(float float_0)
	{
		base.Write(float_0);
	}

	// Token: 0x0600011F RID: 287 RVA: 0x000027D9 File Offset: 0x000009D9
	public void method_11(double double_0)
	{
		base.Write(double_0);
	}

	// Token: 0x06000120 RID: 288 RVA: 0x00004B38 File Offset: 0x00002D38
	public void method_12(string string_0)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(string_0);
		this.method_27(bytes);
		base.Write(0);
	}

	// Token: 0x06000121 RID: 289 RVA: 0x00004B60 File Offset: 0x00002D60
	public void method_13(string string_0, int int_0)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(string_0);
		for (int i = 0; i < int_0; i++)
		{
			if (i < bytes.Length)
			{
				this.method_21(bytes[i]);
			}
			else
			{
				this.method_21(0);
			}
		}
	}

	// Token: 0x06000122 RID: 290 RVA: 0x00004BA0 File Offset: 0x00002DA0
	public void method_14(string string_0, int int_0)
	{
		for (int i = 0; i < int_0; i++)
		{
			if (i < string_0.Length)
			{
				byte[] bytes = BitConverter.GetBytes(string_0[i]);
				this.method_27(bytes);
			}
			else
			{
				this.method_22(0);
			}
		}
		base.Write(new byte[2]);
	}

	// Token: 0x06000123 RID: 291 RVA: 0x000027E2 File Offset: 0x000009E2
	public void method_15(byte[] byte_1)
	{
		base.Write(byte_1);
	}

	// Token: 0x06000125 RID: 293 RVA: 0x00002804 File Offset: 0x00000A04
	static Stream smethod_0(BinaryWriter binaryWriter_0)
	{
		return binaryWriter_0.BaseStream;
	}

	// Token: 0x06000126 RID: 294 RVA: 0x00002695 File Offset: 0x00000895
	static long smethod_1(Stream stream_0)
	{
		return stream_0.Length;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x0000280C File Offset: 0x00000A0C
	static MemoryStream smethod_2()
	{
		return new MemoryStream();
	}

	// Token: 0x06000128 RID: 296 RVA: 0x00002813 File Offset: 0x00000A13
	static byte[] smethod_3(uint uint_0)
	{
		return BitConverter.GetBytes(uint_0);
	}

	// Token: 0x06000129 RID: 297 RVA: 0x0000281B File Offset: 0x00000A1B
	static byte[] smethod_4(ushort ushort_0)
	{
		return BitConverter.GetBytes(ushort_0);
	}

	// Token: 0x0600012A RID: 298 RVA: 0x00002823 File Offset: 0x00000A23
	static long smethod_5(BinaryWriter binaryWriter_0, int int_0, SeekOrigin seekOrigin_0)
	{
		return binaryWriter_0.Seek(int_0, seekOrigin_0);
	}

	// Token: 0x0600012B RID: 299 RVA: 0x0000282D File Offset: 0x00000A2D
	static int smethod_6(Stream stream_0)
	{
		return stream_0.ReadByte();
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00002835 File Offset: 0x00000A35
	long method_16(int int_0, SeekOrigin seekOrigin_0)
	{
		return base.Seek(int_0, seekOrigin_0);
	}

	// Token: 0x0600012D RID: 301 RVA: 0x00002788 File Offset: 0x00000988
	void method_17(sbyte sbyte_0)
	{
		base.Write(sbyte_0);
	}

	// Token: 0x0600012E RID: 302 RVA: 0x00002791 File Offset: 0x00000991
	void method_18(short short_0)
	{
		base.Write(short_0);
	}

	// Token: 0x0600012F RID: 303 RVA: 0x0000279A File Offset: 0x0000099A
	void method_19(int int_0)
	{
		base.Write(int_0);
	}

	// Token: 0x06000130 RID: 304 RVA: 0x000027A3 File Offset: 0x000009A3
	void method_20(long long_0)
	{
		base.Write(long_0);
	}

	// Token: 0x06000131 RID: 305 RVA: 0x000027AC File Offset: 0x000009AC
	void method_21(byte byte_1)
	{
		base.Write(byte_1);
	}

	// Token: 0x06000132 RID: 306 RVA: 0x000027B5 File Offset: 0x000009B5
	void method_22(ushort ushort_0)
	{
		base.Write(ushort_0);
	}

	// Token: 0x06000133 RID: 307 RVA: 0x000027BE File Offset: 0x000009BE
	void method_23(uint uint_0)
	{
		base.Write(uint_0);
	}

	// Token: 0x06000134 RID: 308 RVA: 0x000027C7 File Offset: 0x000009C7
	void method_24(ulong ulong_0)
	{
		base.Write(ulong_0);
	}

	// Token: 0x06000135 RID: 309 RVA: 0x000027D0 File Offset: 0x000009D0
	void method_25(float float_0)
	{
		base.Write(float_0);
	}

	// Token: 0x06000136 RID: 310 RVA: 0x000027D9 File Offset: 0x000009D9
	void method_26(double double_0)
	{
		base.Write(double_0);
	}

	// Token: 0x06000137 RID: 311 RVA: 0x00002550 File Offset: 0x00000750
	static Encoding smethod_7()
	{
		return Encoding.ASCII;
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00002557 File Offset: 0x00000757
	static byte[] smethod_8(Encoding encoding_0, string string_0)
	{
		return encoding_0.GetBytes(string_0);
	}

	// Token: 0x06000139 RID: 313 RVA: 0x000022F9 File Offset: 0x000004F9
	static int smethod_9(string string_0)
	{
		return string_0.Length;
	}

	// Token: 0x0600013A RID: 314 RVA: 0x0000283F File Offset: 0x00000A3F
	static char smethod_10(string string_0, int int_0)
	{
		return string_0[int_0];
	}

	// Token: 0x0600013B RID: 315 RVA: 0x00002848 File Offset: 0x00000A48
	static byte[] smethod_11(char char_0)
	{
		return BitConverter.GetBytes(char_0);
	}

	// Token: 0x0600013C RID: 316 RVA: 0x000027E2 File Offset: 0x000009E2
	void method_27(byte[] byte_1)
	{
		base.Write(byte_1);
	}

	// Token: 0x0600013D RID: 317 RVA: 0x00002568 File Offset: 0x00000768
	static void smethod_12(Array array_0, RuntimeFieldHandle runtimeFieldHandle_0)
	{
		RuntimeHelpers.InitializeArray(array_0, runtimeFieldHandle_0);
	}

	// Token: 0x0400009B RID: 155
	private static readonly byte[] byte_0 = new byte[]
	{
		204, 204, 204, 117, 0, 114, 0, 32, 0, 109,
		0, 111, 0, 109, 0, 32, 0, 103, 0, 97,
		0, 121, 0, 147, 1, 0, 1, 197, 157, 28,
		129, 144, 0
	};

	// Token: 0x0400009C RID: 156
	public ClientServerMessageFlags genum0_0;
}
