using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x02000019 RID: 25
public class Server
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
    public Server(Action aConnectionLossRoutine = null)
    {
        if (!IsMessageDelegatesSetup)
        {
            MessageFlagDelegateMapper.SetupMessageDelegates();
            IsMessageDelegatesSetup = true;
        }
        this.pConnectionLossRoutine = aConnectionLossRoutine;
    }

    // Token: 0x06000141 RID: 321 RVA: 0x00004BEC File Offset: 0x00002DEC
    public bool IsTcpStreamOpen()
    {
        bool flag;
        try
        {
            Console.WriteLine("Connecting...");
            TcpClient tcpClient = new TcpClient("5.161.63.123", 9050);
            this.openedTcpStream = tcpClient.GetStream();
            this.buffer_2 = new byte[0];
            this.buffer = new byte[4];
            this.size = 4;
            new Thread(new ThreadStart(StreamReadLoopThread)).Start();
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
    public void StreamReadLoopThread()
    {
        openedTcpStream.BeginRead(buffer, 0, size, new AsyncCallback(method_6), null);
    }

    // Token: 0x06000143 RID: 323 RVA: 0x00004CC8 File Offset: 0x00002EC8
    public bool method_2()
    {
        this.size_2 = (BitConverter.ToInt32(this.buffer, 0) >> 8) - 4;
        if (this.size_2 > 0 && this.size_2 <= 16777215)
        {
            this.buffer_2 = new byte[this.size_2];
            return true;
        }
        return false;
    }

    // Token: 0x06000144 RID: 324 RVA: 0x00004D18 File Offset: 0x00002F18
    public void WriteMemoryStream(MessageMemoryStream messageMemoryStream, bool optFlag_1 = false, bool optFlag_2 = false)
    {
        if (messageMemoryStream == null)
        {
            return;
        }
        byte[] messageBytes = messageMemoryStream.ReadBytes(this.byte_0);
        try
        {
            this.openedTcpStream.BeginWrite(messageBytes, 0, messageBytes.Length, new AsyncCallback(StreamWriteEndCallback), openedTcpStream);
        }
        catch (Exception)
        {
            this.CloseConnection();
        }
    }

    // Token: 0x06000145 RID: 325 RVA: 0x000028C2 File Offset: 0x00000AC2
    public void CloseConnection()
    {
        openedTcpStream.Close();
        if (pConnectionLossRoutine != null)
        {
            pConnectionLossRoutine.Invoke();
        }
    }

    // Token: 0x06000146 RID: 326 RVA: 0x000028E2 File Offset: 0x00000AE2
    public void StreamWriteEndCallback(IAsyncResult iasyncResult_0)
    {
        this.openedTcpStream.EndWrite(iasyncResult_0);
    }

    // Token: 0x06000147 RID: 327 RVA: 0x00004D74 File Offset: 0x00002F74
    [CompilerGenerated]
    private void method_6(IAsyncResult asyncResult)
    {
        try
        {
            int bytesRead = this.openedTcpStream.EndRead(asyncResult);
            if (bytesRead < 1)
            {
                CloseConnection();
            }
            else if (this.size > 0)
            {
                this.size -= bytesRead;
                if (this.size == 0)
                {
                    if (this.method_2())
                    {
                        this.openedTcpStream.BeginRead(this.buffer_2, 0, this.size_2, new AsyncCallback(this.method_6), null);
                    }
                    else
                    {
                        this.CloseConnection();
                    }
                }
                else
                {
                    this.openedTcpStream.BeginRead(this.buffer, this.buffer.Length - this.size, this.size, new AsyncCallback(this.method_6), null);
                }
            }
            else
            {
                this.size_2 -= bytesRead;
                if (this.size_2 != 0)
                {
                    this.openedTcpStream.BeginRead(this.buffer_2, this.buffer_2.Length - this.size_2, this.size_2, new AsyncCallback(this.method_6), null);
                }
                else
                {
                    BinaryReaderWrapper gclass = new BinaryReaderWrapper(this.buffer, this.buffer_2, "test", this.byte_0);
                    GClass9.smethod_1(gclass, this, gclass.GEnum0_0);
                    this.buffer_2 = new byte[0];
                    this.buffer = new byte[4];
                    this.size = 4;
                    this.openedTcpStream.BeginRead(this.buffer, 0, this.size, new AsyncCallback(this.method_6), null);
                }
            }
        }
        catch (Exception)
        {
            this.CloseConnection();
        }
    }

    // Token: 0x0400009D RID: 157
    public ulong ulong_0;

    // Token: 0x0400009E RID: 158
    private NetworkStream openedTcpStream;

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
    public int size;

    // Token: 0x040000A4 RID: 164
    public byte[] buffer;

    // Token: 0x040000A5 RID: 165
    public int size_2;

    // Token: 0x040000A6 RID: 166
    public byte[] buffer_2;

    // Token: 0x040000A7 RID: 167
    private Action pConnectionLossRoutine;

    // Token: 0x040000A8 RID: 168
    public List<ulong> list_0;

    // Token: 0x040000A9 RID: 169
    public List<ulong> list_1;

    // Token: 0x040000AA RID: 170
    public byte[] byte_5;

    // Token: 0x040000AB RID: 171
    public byte[] byte_6;

    // Token: 0x040000AC RID: 172
    private static bool IsMessageDelegatesSetup;

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
    public Action<object> WaitForWorldOfWarcraft;

    // Token: 0x040000B8 RID: 184
    public Action<byte[], byte[]> action_8;
}
