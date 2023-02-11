public class MessageHandlerSetup
{
	public static void SetupMessageHandlers()
	{
		MessageProcessor.RegisterMessageHandler(ClientServerMessageFlags.SMSG_AUTH_STATUS, new MessageProcessor.MessageHandlerDelegate(GClass6.smethod_1));
		MessageProcessor.RegisterMessageHandler(ClientServerMessageFlags.SMSG_KEY, new MessageProcessor.MessageHandlerDelegate(GClass6.smethod_0));
		MessageProcessor.RegisterMessageHandler(ClientServerMessageFlags.SMSG_BROADCAST, new MessageProcessor.MessageHandlerDelegate(GClass6.smethod_3));
		MessageProcessor.RegisterMessageHandler(ClientServerMessageFlags.SMSG_WARDEN_UPLOAD_RSP, new MessageProcessor.MessageHandlerDelegate(GClass6.smethod_2));
		MessageProcessor.RegisterMessageHandler(ClientServerMessageFlags.SMSG_OFFSETS, new MessageProcessor.MessageHandlerDelegate(GClass6.smethod_7));
		MessageProcessor.RegisterMessageHandler(ClientServerMessageFlags.SMSG_APAYLOAD, new MessageProcessor.MessageHandlerDelegate(GClass6.smethod_4));
		MessageProcessor.RegisterMessageHandler(ClientServerMessageFlags.SMSG_REQUES_GAMEMODULE, new MessageProcessor.MessageHandlerDelegate(GClass6.smethod_9));
		MessageProcessor.RegisterMessageHandler(ClientServerMessageFlags.SMSG_NEEDLE_PAYLOAD, new MessageProcessor.MessageHandlerDelegate(GClass6.smethod_5));
		MessageProcessor.RegisterMessageHandler(ClientServerMessageFlags.SMSG_HOOK_PAYLOAD, new MessageProcessor.MessageHandlerDelegate(GClass6.smethod_6));
		MessageProcessor.RegisterMessageHandler(ClientServerMessageFlags.SMSG_TOOL_OFFSETS, new MessageProcessor.MessageHandlerDelegate(GClass6.smethod_8));
	}
}
	