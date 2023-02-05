using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000019 RID: 25
public class GClass12
{
	// Token: 0x1700000E RID: 14
	// (get) Token: 0x0600013E RID: 318 RVA: 0x00002850 File Offset: 0x00000A50
	// (set) Token: 0x0600013F RID: 319 RVA: 0x00002858 File Offset: 0x00000A58
	public object Object_0
	{
		get
		{
			return this.object_0;
		}
		set
		{
			this.object_0 = value;
		}
	}

	// Token: 0x06000140 RID: 320 RVA: 0x00002861 File Offset: 0x00000A61
	public GClass12(Action action_9 = null)
	{
		if (!GClass12.bool_0)
		{
			GClass8.smethod_0();
			GClass12.bool_0 = true;
		}
		this.action_0 = action_9;
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00004BEC File Offset: 0x00002DEC
	public bool method_0()
	{
		bool flag;
		try
		{
			Console.WriteLine("Connecting...");
			TcpClient tcpClient = new TcpClient("5.161.63.123", 9050);
			this.networkStream_0 = tcpClient.GetStream();
			this.byte_4 = new byte[0];
			this.byte_3 = new byte[4];
			this.int_0 = 4;
			new Thread(new ThreadStart(this.method_1)).Start();
			return true;
		}
		catch (Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Error: " + ex.Message);
			if (ex.GetType() == typeof(SocketException) && ((SocketException)ex).SocketErrorCode == SocketError.ConnectionRefused)
			{
				Console.WriteLine("Is TOR running!?");
			}
			Console.ForegroundColor = ConsoleColor.Gray;
			flag = false;
		}
		return flag;
	}

	// Token: 0x06000142 RID: 322 RVA: 0x0000289A File Offset: 0x00000A9A
	public void method_1()
	{
		this.networkStream_0.BeginRead(this.byte_3, 0, this.int_0, new AsyncCallback(this.method_6), null);
	}

	// Token: 0x06000143 RID: 323 RVA: 0x00004CC8 File Offset: 0x00002EC8
	public bool method_2()
	{
		this.int_1 = (BitConverter.ToInt32(this.byte_3, 0) >> 8) - 4;
		if (this.int_1 > 0 && this.int_1 <= 16777215)
		{
			this.byte_4 = new byte[this.int_1];
			return true;
		}
		return false;
	}

	// Token: 0x06000144 RID: 324 RVA: 0x00004D18 File Offset: 0x00002F18
	public void method_3(GClass11 gclass11_0, bool bool_1 = false, bool bool_2 = false)
	{
		if (gclass11_0 == null)
		{
			return;
		}
		byte[] array = gclass11_0.method_0(this.byte_0);
		try
		{
			this.networkStream_0.BeginWrite(array, 0, array.Length, new AsyncCallback(this.method_5), this.networkStream_0);
		}
		catch (Exception)
		{
			this.method_4();
		}
	}

	// Token: 0x06000145 RID: 325 RVA: 0x000028C2 File Offset: 0x00000AC2
	public void method_4()
	{
		this.networkStream_0.Close();
		if (this.action_0 != null)
		{
			this.action_0();
		}
	}

	// Token: 0x06000146 RID: 326 RVA: 0x000028E2 File Offset: 0x00000AE2
	public void method_5(IAsyncResult iasyncResult_0)
	{
		this.networkStream_0.EndWrite(iasyncResult_0);
	}

	// Token: 0x06000147 RID: 327 RVA: 0x00004D74 File Offset: 0x00002F74
	[CompilerGenerated]
	private void method_6(IAsyncResult iasyncResult_0)
	{
		try
		{
			int num = this.networkStream_0.EndRead(iasyncResult_0);
			if (num < 1)
			{
				this.method_4();
			}
			else if (this.int_0 > 0)
			{
				this.int_0 -= num;
				if (this.int_0 == 0)
				{
					if (this.method_2())
					{
						this.networkStream_0.BeginRead(this.byte_4, 0, this.int_1, new AsyncCallback(this.method_6), null);
					}
					else
					{
						this.method_4();
					}
				}
				else
				{
					this.networkStream_0.BeginRead(this.byte_3, this.byte_3.Length - this.int_0, this.int_0, new AsyncCallback(this.method_6), null);
				}
			}
			else
			{
				this.int_1 -= num;
				if (this.int_1 != 0)
				{
					this.networkStream_0.BeginRead(this.byte_4, this.byte_4.Length - this.int_1, this.int_1, new AsyncCallback(this.method_6), null);
				}
				else
				{
					GClass10 gclass = new GClass10(this.byte_3, this.byte_4, "test", this.byte_0);
					GClass9.smethod_1(gclass, this, gclass.GEnum0_0);
					this.byte_4 = new byte[0];
					this.byte_3 = new byte[4];
					this.int_0 = 4;
					this.networkStream_0.BeginRead(this.byte_3, 0, this.int_0, new AsyncCallback(this.method_6), null);
				}
			}
		}
		catch (Exception)
		{
			this.method_4();
		}
	}

	// Token: 0x06000148 RID: 328 RVA: 0x00002568 File Offset: 0x00000768
	static void smethod_0(Array array_0, RuntimeFieldHandle runtimeFieldHandle_0)
	{
		RuntimeHelpers.InitializeArray(array_0, runtimeFieldHandle_0);
	}

	// Token: 0x06000149 RID: 329 RVA: 0x000022B2 File Offset: 0x000004B2
	static void smethod_1(string string_0)
	{
		Console.WriteLine(string_0);
	}

	// Token: 0x0600014A RID: 330 RVA: 0x000028F0 File Offset: 0x00000AF0
	static TcpClient smethod_2(string string_0, int int_2)
	{
		return new TcpClient(string_0, int_2);
	}

	// Token: 0x0600014B RID: 331 RVA: 0x000028F9 File Offset: 0x00000AF9
	static NetworkStream smethod_3(TcpClient tcpClient_0)
	{
		return tcpClient_0.GetStream();
	}

	// Token: 0x0600014C RID: 332 RVA: 0x000021DA File Offset: 0x000003DA
	static Thread smethod_4(ThreadStart threadStart_0)
	{
		return new Thread(threadStart_0);
	}

	// Token: 0x0600014D RID: 333 RVA: 0x000021E2 File Offset: 0x000003E2
	static void smethod_5(Thread thread_0)
	{
		thread_0.Start();
	}

	// Token: 0x0600014E RID: 334 RVA: 0x000022D3 File Offset: 0x000004D3
	static void smethod_6(ConsoleColor consoleColor_0)
	{
		Console.ForegroundColor = consoleColor_0;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x00002901 File Offset: 0x00000B01
	static string smethod_7(Exception exception_0)
	{
		return exception_0.Message;
	}

	// Token: 0x06000150 RID: 336 RVA: 0x000021B4 File Offset: 0x000003B4
	static string smethod_8(string string_0, string string_1)
	{
		return string_0 + string_1;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x00002909 File Offset: 0x00000B09
	static Type smethod_9(Exception exception_0)
	{
		return exception_0.GetType();
	}

	// Token: 0x06000152 RID: 338 RVA: 0x000024C7 File Offset: 0x000006C7
	static Type smethod_10(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	// Token: 0x06000153 RID: 339 RVA: 0x00002911 File Offset: 0x00000B11
	static bool smethod_11(Type type_0, Type type_1)
	{
		return type_0 == type_1;
	}

	// Token: 0x06000154 RID: 340 RVA: 0x0000291A File Offset: 0x00000B1A
	static SocketError smethod_12(SocketException socketException_0)
	{
		return socketException_0.SocketErrorCode;
	}

	// Token: 0x06000155 RID: 341 RVA: 0x00002922 File Offset: 0x00000B22
	static IAsyncResult smethod_13(Stream stream_0, byte[] byte_8, int int_2, int int_3, AsyncCallback asyncCallback_0, object object_1)
	{
		return stream_0.BeginRead(byte_8, int_2, int_3, asyncCallback_0, object_1);
	}

	// Token: 0x06000156 RID: 342 RVA: 0x00002931 File Offset: 0x00000B31
	static int smethod_14(byte[] byte_8, int int_2)
	{
		return BitConverter.ToInt32(byte_8, int_2);
	}

	// Token: 0x06000157 RID: 343 RVA: 0x0000293A File Offset: 0x00000B3A
	static IAsyncResult smethod_15(Stream stream_0, byte[] byte_8, int int_2, int int_3, AsyncCallback asyncCallback_0, object object_1)
	{
		return stream_0.BeginWrite(byte_8, int_2, int_3, asyncCallback_0, object_1);
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00002949 File Offset: 0x00000B49
	static void smethod_16(Stream stream_0)
	{
		stream_0.Close();
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00002951 File Offset: 0x00000B51
	static void smethod_17(Stream stream_0, IAsyncResult iasyncResult_0)
	{
		stream_0.EndWrite(iasyncResult_0);
	}

	// Token: 0x0600015A RID: 346 RVA: 0x0000295A File Offset: 0x00000B5A
	static int smethod_18(Stream stream_0, IAsyncResult iasyncResult_0)
	{
		return stream_0.EndRead(iasyncResult_0);
	}

	// Token: 0x0400009D RID: 157
	public ulong ulong_0;

	// Token: 0x0400009E RID: 158
	private NetworkStream networkStream_0;

	// Token: 0x0400009F RID: 159
	public byte[] byte_0;

	// Token: 0x040000A0 RID: 160
	public byte byte_1;

	// Token: 0x040000A1 RID: 161
	private object object_0;

	// Token: 0x040000A2 RID: 162
	private byte[] byte_2 = new byte[]
	{
		6, 244, 101, 122, 80, 234, 107, 104, 74, 173,
		37, 125, 1, 238, 121, 121, 5, 235, 103, 60,
		91, 244, 117, 127, 67, 250, 126, 62, 82, 175,
		124, 122, 0, 251, 39, 97, 67, 227, 115, 124,
		86, 243, 117, 123, 70, 232, 107, 58, 88, 252,
		123, 127, 81, byte.MaxValue, 104, 109, 29, 246, 127, 96,
		92, 247
	};

	// Token: 0x040000A3 RID: 163
	public int int_0;

	// Token: 0x040000A4 RID: 164
	public byte[] byte_3;

	// Token: 0x040000A5 RID: 165
	public int int_1;

	// Token: 0x040000A6 RID: 166
	public byte[] byte_4;

	// Token: 0x040000A7 RID: 167
	private Action action_0;

	// Token: 0x040000A8 RID: 168
	public List<ulong> list_0;

	// Token: 0x040000A9 RID: 169
	public List<ulong> list_1;

	// Token: 0x040000AA RID: 170
	public byte[] byte_5;

	// Token: 0x040000AB RID: 171
	public byte[] byte_6;

	// Token: 0x040000AC RID: 172
	private static bool bool_0;

	// Token: 0x040000AD RID: 173
	public uint uint_0;

	// Token: 0x040000AE RID: 174
	public ushort ushort_0;

	// Token: 0x040000AF RID: 175
	public byte[] byte_7;

	// Token: 0x040000B0 RID: 176
	public ushort ushort_1;

	// Token: 0x040000B1 RID: 177
	public Action action_1;

	// Token: 0x040000B2 RID: 178
	public Action action_2;

	// Token: 0x040000B3 RID: 179
	public Action action_3;

	// Token: 0x040000B4 RID: 180
	public Action<byte[], int> action_4;

	// Token: 0x040000B5 RID: 181
	public Action<byte[], int> action_5;

	// Token: 0x040000B6 RID: 182
	public Action action_6;

	// Token: 0x040000B7 RID: 183
	public Action<object> action_7;

	// Token: 0x040000B8 RID: 184
	public Action<byte[], byte[]> action_8;
}
