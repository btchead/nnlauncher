using System;
using System.Collections.Generic;
using System.IO;

public class MessageMemoryStream : BinaryWriter
{
    public uint UInt32_0
    {
        get
        {
            return this.UInt32_1 + 4U;
        }
    }

    public uint UInt32_1
    {
        get
        {
            return (uint)this.BaseStream.Length;
        }
    }

    public MessageMemoryStream(ClientServerMessageFlags messageFlag)
        : base(new MemoryStream())
    {
        this.messageFlag = messageFlag;
    }

    public byte[] ReadBytes(byte[] byte_1 = null)
    {
        byte[] array = new byte[4];
        byte[] bytes = BitConverter.GetBytes(this.UInt32_0);
        byte[] bytes2 = BitConverter.GetBytes((ushort)this.messageFlag);
        array[0] = bytes2[0];
        array[1] = bytes[0];
        array[2] = bytes[1];
        array[3] = bytes[2];
        byte[] array2 = new byte[this.UInt32_1];
        this.Seek(0, SeekOrigin.Begin);
        int num = 0;
        while ((long)num < (long)((ulong)this.UInt32_1))
        {
            array2[num] = (byte)this.BaseStream.ReadByte();
            num++;
        }
        List<byte> list = new List<byte>();
        list.AddRange(array);
        list.AddRange(array2);
        return list.ToArray();
    }

    public void WriteSByte(sbyte value)
    {
        base.Write(value);
    }

    public void WriteInt32(int value)
    {
        base.Write(value);
    }

    public void WriteByte(byte value)
    {
        base.Write(value);
    }

    public void WriteUInt16(ushort value)
    {
        base.Write(value);
    }

    public void WriteUInt32(uint value)
    {
        base.Write(value);
    }

    public void WriteUInt64(ulong value)
    {
        base.Write(value);
    }

    public void WriteString(string value, int maxLength)
    {
        for (int i = 0; i < maxLength; i++)
        {
            if (i < value.Length)
            {
                byte[] bytes = BitConverter.GetBytes(value[i]);
                WriteBytes(bytes);
            }
            else
            {
                WriteUInt16(0);
            }
        }
        base.Write(new byte[2]);
    }

    public void WriteBytes(byte[] data)
    {
        base.Write(data);
    }

    private static readonly byte[] byte_0 = new byte[]
    {
        204, 204, 204, 117, 0, 114, 0, 32, 0, 109,
        0, 111, 0, 109, 0, 32, 0, 103, 0, 97,
        0, 121, 0, 147, 1, 0, 1, 197, 157, 28,
        129, 144, 0
    };

    public ClientServerMessageFlags messageFlag;
}
