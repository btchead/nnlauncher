using System;
using System.Collections.Generic;

public class MessageHandler
{
    public Action Action_0
    {
        set
        {
            server.action_6 = value;
        }
    }

    public Action<byte[], int> Action_1
    {
        set
        {
            server.action_5 = value;
        }
    }

    public Action<byte[], int> Action_2
    {
        set
        {
            server.action_4 = value;
        }
    }

    public Action<object> WaitForWorldOfWarcraft
    {
        set
        {
            server.WaitForWorldOfWarcraft = value;
        }
    }

    public MessageHandler(Server serverInstance)
    {
        server = serverInstance;
    }

    public void WriteMemoryStreamToServer(MessageMemoryStream messageMemoryStream)
    {
        server.WriteMemoryStream(messageMemoryStream, false, false);
    }

    public bool SendKeyMessage()
    {
        if (!server.OpenStream())
        {
            return false;
        }
        MessageMemoryStream messageMemoryStream = MessageFactory.CreateClientKeyMessageStream(1);
        server.WriteMemoryStream(messageMemoryStream, false, false);
        return true;
    }

    public void SendAuthMessage(string licenseKey, string machineIdentifier)
    {
        MessageMemoryStream messageMemoryStream = MessageFactory.CreateClientAuthMessageStream(licenseKey, machineIdentifier);
        server.WriteMemoryStream(messageMemoryStream, false, false);
    }

    public void SendWardenUploadMessage(byte[] uploadData)
    {
        MessageMemoryStream messageMemoryStream = MessageFactory.CreateClientWardenUploadMessageStream(uploadData);
        server.WriteMemoryStream(messageMemoryStream, false, false);
    }

    public void SendClientRequestNeedlePayloadMsg(string string_0, long[] long_0, byte[] byte_0, ulong ulong_0, string string_1)
    {
        MessageMemoryStream messageMemoryStream = MessageFactory.CreateClientRequestNeedlePayload(string_0, long_0, byte_0, ulong_0, string_1);
        server.WriteMemoryStream(messageMemoryStream, false, false);
    }

    public void SendClientRequestHookPayloadMsg(string string_0, long[] long_0, byte[] byte_0, ulong ulong_0)
    {
        MessageMemoryStream messageMemoryStream = MessageFactory.CreateClientRequestHookPayloadMessageStream(string_0, long_0, byte_0, ulong_0);
        server.WriteMemoryStream(messageMemoryStream, false, false);
    }

    public void SendClientRequestOffsetsMessage(string string_0, string string_1, ulong ulong_0, Action action_0)
    {
        MessageMemoryStream messageMemoryStream = MessageFactory.CreateClientRequestOffsetsMessageStream(string_0, ulong_0, string_1);
        server.WriteMemoryStream(messageMemoryStream, false, false);
        server.action_1 = action_0;
    }

    public void SendClientRequestToolOffsetsMessage(string fileVersion, Action action_0)
    {
        MessageMemoryStream messageMemoryStream = MessageFactory.CreateClientRequestToolOffsetsMessageStream(fileVersion);
        server.WriteMemoryStream(messageMemoryStream, false, false);
        server.action_2 = action_0;
    }

    public void SendClientRequestPayloadMessage(string fileVersion, ulong moduleBaseAddress, ulong allocatedMemory, string punaniString, string path, Action callback)
    {
        MessageMemoryStream messageMemoryStream = MessageFactory.CreateClientRequestPayloadMessageStream(fileVersion, moduleBaseAddress, allocatedMemory, punaniString, path);
        server.WriteMemoryStream(messageMemoryStream);
        server.action_3 = callback;
    }

    private Server server;
    
    [Obsolete("This field is never used in original source")]
    public ushort UInt16_0 => server.ushort_1;
    
    public List<ulong> List_0 => server.list_1;
    
    public byte[] Byte_0 => server.byte_5;

    public byte[] Byte_1 => server.byte_6;
}
