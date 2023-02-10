using System;
using System.IO;

public class MessageMemoryStream : BinaryWriter
{
    private readonly ClientServerMessageFlags messageFlag;
    private readonly MemoryStream stream;

    public uint MessageLength => (uint)stream.Length + 4;

    public MessageMemoryStream(ClientServerMessageFlags messageFlag)
        : base(new MemoryStream())
    {
        this.messageFlag = messageFlag;
        stream = (MemoryStream)BaseStream;
    }

    public byte[] ReadBytes()
    {
        var header = GetHeader();
        var message = GetMessage();
        return ConcatenateArrays(header, message);
    }

    private byte[] GetHeader()
    {
        var lengthBytes = BitConverter.GetBytes(MessageLength);
        var flagBytes = BitConverter.GetBytes((ushort)messageFlag);

        var header = new byte[4];
        header[0] = flagBytes[0];
        header[1] = lengthBytes[0];
        header[2] = lengthBytes[1];
        header[3] = lengthBytes[2];

        return header;
    }

    private byte[] GetMessage()
    {
        stream.Seek(0, SeekOrigin.Begin);
        var message = new byte[MessageLength];
        int i = 0;
        while (i < stream.Length)
        {
            message[i] = (byte)stream.ReadByte();
            i++;
        }
        return message;
    }

    private byte[] ConcatenateArrays(byte[] first, byte[] second)
    {
        var result = new byte[first.Length + second.Length];
        first.CopyTo(result, 0);
        second.CopyTo(result, first.Length);
        return result;
    }

    public void WriteString(string value, int maxLength)
    {
        for (int i = 0; i < maxLength; i++)
        {
            if (i < value.Length)
            {
                WriteBytes(BitConverter.GetBytes(value[i]));
            }
            else
            {
                WriteUInt16(0);
            }
        }
        base.Write(new byte[2]);
    }

    public void WriteSByte(sbyte value) => base.Write(value);
    public void WriteInt32(int value) => base.Write(value);
    public void WriteByte(byte value) => base.Write(value);
    public void WriteUInt16(ushort value) => base.Write(value);
    public void WriteUInt32(uint value) => base.Write(value);
    public void WriteUInt64(ulong value) => base.Write(value);
    public void WriteBytes(byte[] data) => base.Write(data);

}
