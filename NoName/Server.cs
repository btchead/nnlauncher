using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

public class Server
{
    public Server(Action onConnectionLost = null)
    {
        if (!IsMessageHandlersSetup)
        {
            MessageHandlerSetup.SetupMessageHandlers();
            IsMessageHandlersSetup = true;
        }
        this.onConnectionLost = onConnectionLost;
    }

    public bool OpenStream()
    {
        try
        {
            Console.WriteLine("Connecting...");
            TcpClient tcpClient = new TcpClient("5.161.63.123", 9050);
            connectionStream = tcpClient.GetStream();

            messageBuffer = new byte[0];
            headerBuffer = new byte[4];
            headerSize = 4;
            new Thread(ReadMessageHeaderAsync).Start();

            Console.WriteLine("Connected.");
            return true;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + ex.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
            return false;
        }
    }

    private void ReadMessageHeaderAsync()
    {
        connectionStream.BeginRead(headerBuffer, 0, headerSize, new AsyncCallback(ReadHeaderCallback), null);
    }

    public bool ValidateMessageHeader()
    {
        messageSize = (BitConverter.ToInt32(headerBuffer, 0) >> 8) - 4;
        bool isValidMessageSize = messageSize > 0 && messageSize <= 16777215;
        messageBuffer = isValidMessageSize ? new byte[messageSize] : new byte[0];
        return isValidMessageSize;
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
        connectionStream.EndWrite(iasyncResult_0);
    }

    private void ReadHeaderCallback(IAsyncResult asyncResult)
    {
        try
        {
            int bytesRead = connectionStream.EndRead(asyncResult);
            if (bytesRead < 1)
            {
                CloseConnection();
                return;
            }

            if (headerSize > 0)
            {
                ProcessHeaderBytes(bytesRead);
            }
            else
            {
                ProcessMessageBytes(bytesRead);
            }
        }
        catch (Exception)
        {
            CloseConnection();
        }
    }

    private void ProcessHeaderBytes(int bytesRead)
    {
        headerSize -= bytesRead;

        if (headerSize == 0)
        {
            if (ValidateMessageHeader())
            {
                BeginReadingMessage();
            }
            else
            {
                CloseConnection();
            }
        }
        else
        {
            BeginReadingHeader();
        }
    }

    private void ProcessMessageBytes(int bytesRead)
    {
        messageSize -= bytesRead;

        if (messageSize == 0)
        {
            ProcessCompleteMessage();
        }
        else
        {
            BeginReadingMessage();
        }
    }

    private void BeginReadingHeader()
    {
        connectionStream.BeginRead(headerBuffer, headerBuffer.Length - headerSize, headerSize, new AsyncCallback(ReadHeaderCallback), null);
    }

    private void BeginReadingMessage()
    {
        connectionStream.BeginRead(messageBuffer, messageBuffer.Length - messageSize, messageSize, new AsyncCallback(ReadHeaderCallback), null);
    }

    private void ProcessCompleteMessage()
    {
        BinaryMessageReader binaryMessageReader = new BinaryMessageReader(headerBuffer, messageBuffer);
        MessageProcessor.ProcessMessage(binaryMessageReader, this, binaryMessageReader.ClientServerMessageFlag);
        messageBuffer = new byte[0];
        headerBuffer = new byte[4];
        headerSize = 4;
        BeginReadingHeader();
    }

    public ulong ulong_0;

    private NetworkStream connectionStream;

    public byte[] byte_0;

    public byte byte_1;

    public int headerSize;

    public byte[] headerBuffer;

    public int messageSize;

    public byte[] messageBuffer;

    private Action onConnectionLost;

    public List<ulong> list_0;

    public List<ulong> list_1;

    public byte[] byte_5;

    public byte[] byte_6;

    private static bool IsMessageHandlersSetup;

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

    public Action<object> action_7;

    public Action<byte[], byte[]> action_8;
}
