using System;
using System.IO;
using System.Text;

public class BinaryMessageReader
{
    public ClientServerMessageFlags ClientServerMessageFlag => (ClientServerMessageFlags)messageHeaderStruct.messageFlag;

    public BinaryMessageReader(byte[] messageFlagBytes, byte[] messageDataBytes)
    {
        binaryReader = new BinaryReader(new MemoryStream(messageDataBytes));

        ushort messageFlagValue = messageFlagBytes[0];
        uint messageLength = BitConverter.ToUInt32(messageFlagBytes, 0) & 0x00FFFFFF;

        messageHeaderStruct = new MessageHeaderStruct
        {
            messageFlag = messageFlagValue,
            messageLength = messageLength - 4
        };

        byte[] messageBytes = ReadBytes((int)messageHeaderStruct.messageLength);
        binaryReader = new BinaryReader(new MemoryStream(messageBytes));
    }

    public string ReadString(int stringLength)
    {
        byte[] byteArray = ReadBytes(stringLength * 2 + 2);
        byte[] cleanedByteArray = new byte[stringLength * 2 + 2];
        for (int i = 0; i < stringLength * 2; i++)
        {
            if (byteArray[i] != 0)
            {
                cleanedByteArray[i] = byteArray[i];
            }
        }
        return Encoding.Unicode.GetString(cleanedByteArray).Split(new char[1])[0];
    }

    public int ReadInt32() => binaryReader.ReadInt32();

    public byte ReadByte() => binaryReader.ReadByte();

    public ushort ReadUInt16() => binaryReader.ReadUInt16();

    public uint ReadUInt32() => binaryReader.ReadUInt32();

    public ulong ReadUInt64() => binaryReader.ReadUInt64();

    public byte[] ReadBytes(int count) => binaryReader.ReadBytes(count);

    private MessageHeaderStruct messageHeaderStruct;

    private readonly BinaryReader binaryReader;
}
