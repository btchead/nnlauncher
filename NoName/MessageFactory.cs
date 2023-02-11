using System;

public class MessageFactory
{
    public static MessageMemoryStream CreateClientAuthMessageStream(string licenseKey, string machineIdentifier)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_AUTH);
        messageMemoryStream.WriteBytes(new byte[] { 7, 1 });
        messageMemoryStream.WriteString(licenseKey, 32);
        messageMemoryStream.WriteUInt16(105);
        messageMemoryStream.WriteString(machineIdentifier, 32);
        return messageMemoryStream;
    }

    public static MessageMemoryStream CreateClientKeyMessageStream(byte value)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_KEY);
        messageMemoryStream.WriteByte(value);
        return messageMemoryStream;
    }

    public static MessageMemoryStream CreateClientRequestOffsetsMessageStream(string string_0, ulong ulong_0, string string_1)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_REQUEST_OFFSETS);
        messageMemoryStream.WriteUInt16((ushort)string_0.Length);
        messageMemoryStream.WriteString(string_0, string_0.Length);
        messageMemoryStream.WriteUInt64(ulong_0);
        messageMemoryStream.WriteUInt16((ushort)string_1.Length);
        messageMemoryStream.WriteString(string_1, string_1.Length);
        return messageMemoryStream;
    }

    public static MessageMemoryStream CreateClientRequestToolOffsetsMessageStream(string string_0)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_REQUEST_TOOL_OFFSETS);
        messageMemoryStream.WriteUInt16((ushort)string_0.Length);
        messageMemoryStream.WriteString(string_0, string_0.Length);
        return messageMemoryStream;
    }

    public static MessageMemoryStream CreateClientRequestPayloadMessageStream(string fileVersion, ulong moduleBaseAddress, ulong allocatedMemory, string punaniString, string path)
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

    public static MessageMemoryStream CreateClientWardenUploadMessageStream(byte[] uploadData)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_WARDEN_UPLOAD);
        messageMemoryStream.WriteInt32(uploadData.Length);
        messageMemoryStream.WriteBytes(uploadData);
        return messageMemoryStream;
    }

    public static MessageMemoryStream CreateClientRequestNeedlePayload(string string_0, long[] long_0, byte[] byte_0, ulong ulong_0, string string_1)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_REQUEST_NEEDLE_PAYLOAD);
        messageMemoryStream.WriteUInt64(ulong_0);
        messageMemoryStream.WriteSByte((sbyte)long_0.Length);
        for (int i = 0; i < long_0.Length; i++)
        {
            messageMemoryStream.WriteUInt64((ulong)long_0[i]);
        }
        messageMemoryStream.WriteUInt32((uint)byte_0.Length);
        messageMemoryStream.WriteBytes(byte_0);
        messageMemoryStream.WriteUInt16((ushort)string_0.Length);
        messageMemoryStream.WriteString(string_0, string_0.Length);
        messageMemoryStream.WriteUInt16((ushort)string_1.Length);
        messageMemoryStream.WriteString(string_1, string_1.Length);
        return messageMemoryStream;
    }

    public static MessageMemoryStream CreateClientRequestHookPayloadMessageStream(string string_0, long[] long_0, byte[] byte_0, ulong ulong_0)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_REQUEST_HOOK_PAYLOAD);
        messageMemoryStream.WriteUInt64(ulong_0);
        messageMemoryStream.WriteSByte((sbyte)long_0.Length);
        for (int i = 0; i < long_0.Length; i++)
        {
            messageMemoryStream.WriteUInt64((ulong)long_0[i]);
        }
        messageMemoryStream.WriteUInt32((uint)byte_0.Length);
        messageMemoryStream.WriteBytes(byte_0);
        messageMemoryStream.WriteUInt16((ushort)string_0.Length);
        messageMemoryStream.WriteString(string_0, string_0.Length);
        return messageMemoryStream;
    }

    public static MessageMemoryStream CreateClientUploadGameModuleMessageStream(string fileVersion, byte[] chunk, int length, int i)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_UPLOAD_GAMEMODULE);
        ushort fileVersionLength = (ushort)fileVersion.Length;
        messageMemoryStream.WriteUInt16(fileVersionLength);
        messageMemoryStream.WriteString(fileVersion, (int)fileVersionLength);
        messageMemoryStream.WriteInt32(chunk.Length);
        messageMemoryStream.WriteInt32(length);
        messageMemoryStream.WriteInt32(i);
        messageMemoryStream.WriteBytes(chunk);
        return messageMemoryStream;
    }

    [Obsolete("This method is never used in original source, use with caution - detection vector")]
    public static MessageMemoryStream CreateClientRequestScriptsMessageStream(string string_0)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_REQUEST_SCRIPTS);
        ushort num = (ushort)string_0.Length;
        messageMemoryStream.WriteUInt16(num);
        messageMemoryStream.WriteString(string_0, (int)num);
        return messageMemoryStream;
    }

    [Obsolete("This method is never used in original source, use with caution - detection vector")]
    public static MessageMemoryStream CreateClientRequestDownloadScriptMessageStream(uint uint_0)
    {
        MessageMemoryStream messageMemoryStream = new MessageMemoryStream(ClientServerMessageFlags.CMSG_DOWNLOAD_SCRIPT_REQUEST);
        messageMemoryStream.WriteUInt32(uint_0);
        return messageMemoryStream;
    }
}
