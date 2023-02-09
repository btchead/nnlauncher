using System;
using System.Collections.Generic;

// Token: 0x02000009 RID: 9
public class MessageHandler
{
    // Token: 0x17000001 RID: 1
    // (get) Token: 0x06000068 RID: 104 RVA: 0x00002384 File Offset: 0x00000584
    public ushort UInt16_0
    {
        get
        {
            return this.server.ushort_1;
        }
    }

    // Token: 0x17000002 RID: 2
    // (set) Token: 0x06000069 RID: 105 RVA: 0x00002391 File Offset: 0x00000591
    public Action Action_0
    {
        set
        {
            this.server.action_6 = value;
        }
    }

    // Token: 0x17000003 RID: 3
    // (set) Token: 0x0600006A RID: 106 RVA: 0x0000239F File Offset: 0x0000059F
    public Action<byte[], int> Action_1
    {
        set
        {
            this.server.action_5 = value;
        }
    }

    // Token: 0x17000004 RID: 4
    // (set) Token: 0x0600006B RID: 107 RVA: 0x000023AD File Offset: 0x000005AD
    public Action<byte[], int> Action_2
    {
        set
        {
            this.server.action_4 = value;
        }
    }

    // Token: 0x17000005 RID: 5
    // (set) Token: 0x0600006C RID: 108 RVA: 0x000023BB File Offset: 0x000005BB
    public Action<object> WaitForWorldOfWarcraft
    {
        set
        {
            this.server.WaitForWorldOfWarcraft = value;
        }
    }

    // Token: 0x17000006 RID: 6
    // (set) Token: 0x0600006D RID: 109 RVA: 0x000023C9 File Offset: 0x000005C9
    public Action<byte[], byte[]> Action_4
    {
        set
        {
            this.server.action_8 = value;
        }
    }

    // Token: 0x0600006E RID: 110 RVA: 0x000023D7 File Offset: 0x000005D7
    public void WriteMemoryStreamToServer(MessageMemoryStream messageMemoryStream)
    {
        this.server.WriteMemoryStream(messageMemoryStream, false, false);
    }

    // Token: 0x17000007 RID: 7
    // (get) Token: 0x0600006F RID: 111 RVA: 0x000023E7 File Offset: 0x000005E7
    public List<ulong> List_0
    {
        get
        {
            return this.server.list_1;
        }
    }

    // Token: 0x17000008 RID: 8
    // (get) Token: 0x06000070 RID: 112 RVA: 0x000023F4 File Offset: 0x000005F4
    public byte[] Byte_0
    {
        get
        {
            return this.server.byte_5;
        }
    }

    // Token: 0x17000009 RID: 9
    // (get) Token: 0x06000071 RID: 113 RVA: 0x00002401 File Offset: 0x00000601
    public byte[] Byte_1
    {
        get
        {
            return this.server.byte_6;
        }
    }

    // Token: 0x06000072 RID: 114 RVA: 0x0000240E File Offset: 0x0000060E
    public MessageHandler(Server serverInstance)
    {
        this.server = serverInstance;
    }

    // Token: 0x06000073 RID: 115 RVA: 0x00003690 File Offset: 0x00001890
    public bool SendClientKeyMsg()
    {
        if (!server.IsTcpStreamOpen())
        {
            return false;
        }
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_KEY);
        messageMemoryStream.mWriteByte(1);
        server.WriteMemoryStream(messageMemoryStream, false, false);
        return true;
    }

    public void WriteClientAuthMessageToServer(string licenseKey, string machineIdentifier)
    {
        WriteMemoryStreamToServer(MessageFactory.CreateClientAuthMsg(licenseKey, machineIdentifier));
    }

    // Token: 0x06000075 RID: 117 RVA: 0x000036CC File Offset: 0x000018CC
    public bool SendWardenUploadMessage(byte[] uploadData)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_WARDEN_UPLOAD);
        messageMemoryStream.method_4(uploadData.Length);
        messageMemoryStream.method_15(uploadData);
        server.WriteMemoryStream(messageMemoryStream, false, false);
        return false;
    }

    // Token: 0x06000076 RID: 118 RVA: 0x00003700 File Offset: 0x00001900
    public bool SendClientRequestNeedlePayloadMsg(string string_0, long[] long_0, byte[] byte_0, ulong ulong_0, string string_1)
    {
        MessageMemoryStream gclass = new MessageMemoryStream(ClientServerMessageFlags.CMSG_REQUEST_NEEDLE_PAYLOAD);
        gclass.method_9(ulong_0);
        gclass.method_2((sbyte)long_0.Length);
        for (int i = 0; i < long_0.Length; i++)
        {
            gclass.method_9((ulong)long_0[i]);
        }
        gclass.method_8((uint)byte_0.Length);
        gclass.method_15(byte_0);
        gclass.method_7((ushort)string_0.Length);
        gclass.method_14(string_0, string_0.Length);
        gclass.method_7((ushort)string_1.Length);
        gclass.method_14(string_1, string_1.Length);
        server.WriteMemoryStream(gclass, false, false);
        return true;
    }

    // Token: 0x06000077 RID: 119 RVA: 0x00003794 File Offset: 0x00001994
    public bool IsClientRequestHookPayloadMsg_Sent(string string_0, long[] long_0, byte[] byte_0, ulong ulong_0)
    {
        MessageMemoryStream gclass = new MessageMemoryStream(ClientServerMessageFlags.CMSG_REQUEST_HOOK_PAYLOAD);
        gclass.method_9(ulong_0);
        gclass.method_2((sbyte)long_0.Length);
        for (int i = 0; i < long_0.Length; i++)
        {
            gclass.method_9((ulong)long_0[i]);
        }
        gclass.method_8((uint)byte_0.Length);
        gclass.method_15(byte_0);
        gclass.method_7((ushort)string_0.Length);
        gclass.method_14(string_0, string_0.Length);
        this.server.WriteMemoryStream(gclass, false, false);
        return true;
    }

    // Token: 0x06000078 RID: 120 RVA: 0x0000242C File Offset: 0x0000062C
    public void method_6(string string_0, string string_1, ulong ulong_0, Action action_0)
    {
        this.server.WriteMemoryStream(MessageFactory.CreateClientRequestOffsetsMsg(string_0, ulong_0, string_1), false, false);
        this.server.action_1 = action_0;
    }

    // Token: 0x06000079 RID: 121 RVA: 0x00002450 File Offset: 0x00000650
    public void method_7(string string_0, Action action_0)
    {
        this.server.WriteMemoryStream(MessageFactory.CreateClientRequestToolOffsetsMsg(string_0), false, false);
        this.server.action_2 = action_0;
    }

    // Token: 0x0600007A RID: 122 RVA: 0x00002471 File Offset: 0x00000671
    public void method_8(string string_0, ulong ulong_0, ulong ulong_1, string string_1, string string_2, Action action_0)
    {
        this.server.WriteMemoryStream(MessageFactory.CreateClientRequestPayloadMsg(string_0, ulong_0, ulong_1, string_1, string_2), false, false);
        this.server.action_3 = action_0;
    }

    // Token: 0x0400001D RID: 29
    private Server server;
}
