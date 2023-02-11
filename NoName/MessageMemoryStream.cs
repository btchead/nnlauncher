using System;
using System.Collections.Generic;
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
        byte[] header = new byte[4];
        byte[] lengthBytes = BitConverter.GetBytes(MessageLength);
        byte[] messageFlagBytes = BitConverter.GetBytes((ushort)this.messageFlag);
        header[0] = messageFlagBytes[0];
        header[1] = lengthBytes[0];
        header[2] = lengthBytes[1];
        header[3] = lengthBytes[2];
        byte[] content = new byte[MessageLength - 4];
        this.Seek(0, SeekOrigin.Begin);
        int index = 0;
        while ((long)index < (long)((ulong)MessageLength - 4))
        {
            content[index] = (byte)this.BaseStream.ReadByte();
            index++;
        }
        List<byte> result = new List<byte>(header.Length + content.Length);
        result.AddRange(header);
        result.AddRange(content);
        return result.ToArray();
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
