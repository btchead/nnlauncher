﻿using System;

// Token: 0x02000010 RID: 16
public class MessageFactory
{
    // Token: 0x060000C9 RID: 201 RVA: 0x00004544 File Offset: 0x00002744
    public static MessageMemoryStream CreateClientAuthMsg(string string_0, string string_1)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_AUTH);
        messageMemoryStream.WriteBytes(new byte[] { 7, 1 });
        messageMemoryStream.WriteString(string_0, 32);
        messageMemoryStream.WriteUInt16(105);
        messageMemoryStream.WriteString(string_1, 32);
        return messageMemoryStream;
    }

    // Token: 0x060000CA RID: 202 RVA: 0x00004588 File Offset: 0x00002788
    public static MessageMemoryStream CreateClientKeyMsg(byte[] byte_0)
    {
        return new MessageMemoryStream(ClientServerMessageFlags.CMSG_KEY);
    }

    // Token: 0x060000CB RID: 203 RVA: 0x000045A0 File Offset: 0x000027A0
    public static MessageMemoryStream CreateClientRequestOffsetsMsg(string string_0, ulong ulong_0, string string_1)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_REQUEST_OFFSETS);
        messageMemoryStream.WriteUInt16((ushort)string_0.Length);
        messageMemoryStream.WriteString(string_0, string_0.Length);
        messageMemoryStream.WriteUInt64(ulong_0);
        messageMemoryStream.WriteUInt16((ushort)string_1.Length);
        messageMemoryStream.WriteString(string_1, string_1.Length);
        return messageMemoryStream;
    }

    // Token: 0x060000CC RID: 204 RVA: 0x000045F4 File Offset: 0x000027F4
    public static MessageMemoryStream CreateClientRequestToolOffsetsMsg(string string_0)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_REQUEST_TOOL_OFFSETS);
        messageMemoryStream.WriteUInt16((ushort)string_0.Length);
        messageMemoryStream.WriteString(string_0, string_0.Length);
        return messageMemoryStream;
    }

    // Token: 0x060000CD RID: 205 RVA: 0x00004624 File Offset: 0x00002824
    public static MessageMemoryStream CreateClientRequestPayloadMsg(string fileVersion, ulong moduleBaseAddress, ulong allocatedMemory, string punaniString, string path)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_REQEUEST_APAYLOAD);
        messageMemoryStream.WriteUInt16((ushort)fileVersion.Length);
        messageMemoryStream.WriteString(fileVersion, fileVersion.Length);
        messageMemoryStream.WriteUInt64(moduleBaseAddress);
        messageMemoryStream.WriteUInt64(allocatedMemory);
        messageMemoryStream.WriteUInt16((ushort)punaniString.Length);
        messageMemoryStream.WriteString(punaniString, punaniString.Length);
        messageMemoryStream.WriteUInt16((ushort)path.Length);
        messageMemoryStream.WriteString(path, path.Length);
        return messageMemoryStream;
    }

    // Token: 0x060000CE RID: 206 RVA: 0x0000469C File Offset: 0x0000289C
    public static MessageMemoryStream CreateClientUploadGameModuleMsg(string string_0, byte[] byte_0, int int_0, int int_1)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_UPLOAD_GAMEMODULE);
        ushort num = (ushort)string_0.Length;
        messageMemoryStream.WriteUInt16(num);
        messageMemoryStream.WriteString(string_0, (int)num);
        messageMemoryStream.WriteInt32(byte_0.Length);
        messageMemoryStream.WriteInt32(int_0);
        messageMemoryStream.WriteInt32(int_1);
        messageMemoryStream.WriteBytes(byte_0);
        return messageMemoryStream;
    }

    // Token: 0x060000CF RID: 207 RVA: 0x000046E8 File Offset: 0x000028E8
    public static MessageMemoryStream CreateClientRequestScriptsMsg(string string_0)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_REQUEST_SCRIPTS);
        ushort num = (ushort)string_0.Length;
        messageMemoryStream.WriteUInt16(num);
        messageMemoryStream.WriteString(string_0, (int)num);
        return messageMemoryStream;
    }

    // Token: 0x060000D0 RID: 208 RVA: 0x00004718 File Offset: 0x00002918
    public static MessageMemoryStream CreateClientRequestDownloadScriptMsg(uint uint_0)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_DOWNLOAD_SCRIPT_REQUEST);
        messageMemoryStream.WriteUInt32(uint_0);
        return messageMemoryStream;
    }
}