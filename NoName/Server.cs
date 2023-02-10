using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;

public class Server
{
    public object Object_0
    {
        get
        {
            return object_0;
        }
        set
        {
            object_0 = value;
        }
    }

    public Server(Action onConnectionLost = null)
    {
        if (!IsMessageDelegatesSetup)
        {
            MessageFlagDelegateMapper.SetupMessageDelegates();
            IsMessageDelegatesSetup = true;
        }
        this.onConnectionLost = onConnectionLost;
    }

    public bool OpenStream()
    {
        bool isConnected;
        try
        {
            Console.WriteLine("Connecting...");
            TcpClient tcpClient = new TcpClient("5.161.63.123", 9050);
            connectionStream = tcpClient.GetStream();

            messageBuffer = new byte[0];
            headerBuffer = new byte[4];
            headerSize = 4;
            new Thread(new ThreadStart(ReadMessageHeaderAsync)).Start();
            return true;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + ex.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
            isConnected = false;
        }
        return isConnected;
    }

    private void ReadMessageHeaderAsync()
    {
        connectionStream.BeginRead(headerBuffer, 0, headerSize, new AsyncCallback(ReadHeaderCallback), null);
    }

    public bool ValidateMessageHeader()
    {
        messageSize = (BitConverter.ToInt32(headerBuffer, 0) >> 8) - 4;
        if (messageSize > 0 && messageSize <= 16777215)
        {
            messageBuffer = new byte[messageSize];
            return true;
        }
        return false;
    }

    public void WriteMemoryStream(MessageMemoryStream messageMemoryStream, bool optFlag_1 = false, bool optFlag_2 = false)
    {
        if (messageMemoryStream == null) return;

        byte[] messageBytes = messageMemoryStream.ReadBytes();
        try
        {
            connectionStream.BeginWrite(messageBytes, 0, messageBytes.Length, new AsyncCallback(StreamWriteEndCallback), connectionStream);
        }
        catch (Exception)
        {
            CloseConnection();
        }
    }

    public void CloseConnection()
    {
        connectionStream.Close();
        if (onConnectionLost != null)
        {
            onConnectionLost.Invoke();
        }
    }

    public void StreamWriteEndCallback(IAsyncResult iasyncResult_0)
    {
        this.connectionStream.EndWrite(iasyncResult_0);
    }

    [CompilerGenerated]
    private void ReadHeaderCallback(IAsyncResult asyncResult)
    {
        try
        {
            int bytesRead = connectionStream.EndRead(asyncResult);
            if (bytesRead < 1)
            {
                CloseConnection();
            }
            else if (headerSize > 0)
            {
                headerSize -= bytesRead;
                if (headerSize == 0)
                {
                    if (ValidateMessageHeader())
                    {
                        connectionStream.BeginRead(messageBuffer, 0, messageSize, new AsyncCallback(ReadHeaderCallback), null);
                    }
                    else
                    {
                        CloseConnection();
                    }
                }
                else
                {
                    connectionStream.BeginRead(headerBuffer, headerBuffer.Length - headerSize, headerSize, new AsyncCallback(ReadHeaderCallback), null);
                }
            }
            else
            {
                messageSize -= bytesRead;
                if (messageSize != 0)
                {
                    connectionStream.BeginRead(messageBuffer, messageBuffer.Length - messageSize, messageSize, new AsyncCallback(ReadHeaderCallback), null);
                }
                else
                {
                    BinaryReaderWrapper gclass = new BinaryReaderWrapper(headerBuffer, messageBuffer, "test", byte_0);
                    GClass9.smethod_1(gclass, this, gclass.messageFlagsEnum);
                    messageBuffer = new byte[0];
                    headerBuffer = new byte[4];
                    headerSize = 4;
                    connectionStream.BeginRead(headerBuffer, 0, headerSize, new AsyncCallback(ReadHeaderCallback), null);
                }
            }
        }
        catch (Exception)
        {
            CloseConnection();
        }
    }

    public ulong ulong_0;

    private NetworkStream connectionStream;

    public byte[] byte_0;

    public byte byte_1;

    private object object_0;

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

    public int headerSize;

    public byte[] headerBuffer;

    public int messageSize;

    public byte[] messageBuffer;

    private Action onConnectionLost;

    public List<ulong> list_0;

    public List<ulong> list_1;

    public byte[] byte_5;

    public byte[] byte_6;

    private static bool IsMessageDelegatesSetup;

    public uint uint_0;

    public ushort ushort_0;

    public byte[] byte_7;

    public ushort ushort_1;

    public Action action_1;

    public Action action_2;

    public Action action_3;

    public Action<byte[], int> action_4;

    public Action<byte[], int> action_5;

    public Action action_6;

    public Action<object> WaitForWorldOfWarcraft;

    public Action<byte[], byte[]> action_8;
}
