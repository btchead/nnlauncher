public class MessageFlagDelegateMapper
{
	public static void SetupMessageDelegates()
	{
		GClass9.smethod_0(ClientServerMessageFlags.SMSG_AUTH_STATUS, new GClass9.MessageHandlerDelegate(GClass6.smethod_1));
		GClass9.smethod_0(ClientServerMessageFlags.SMSG_KEY, new GClass9.MessageHandlerDelegate(GClass6.smethod_0));
		GClass9.smethod_0(ClientServerMessageFlags.SMSG_BROADCAST, new GClass9.MessageHandlerDelegate(GClass6.smethod_3));
		GClass9.smethod_0(ClientServerMessageFlags.SMSG_WARDEN_UPLOAD_RSP, new GClass9.MessageHandlerDelegate(GClass6.smethod_2));
		GClass9.smethod_0(ClientServerMessageFlags.SMSG_OFFSETS, new GClass9.MessageHandlerDelegate(GClass6.smethod_7));
		GClass9.smethod_0(ClientServerMessageFlags.SMSG_APAYLOAD, new GClass9.MessageHandlerDelegate(GClass6.smethod_4));
		GClass9.smethod_0(ClientServerMessageFlags.SMSG_REQUES_GAMEMODULE, new GClass9.MessageHandlerDelegate(GClass6.smethod_9));
		GClass9.smethod_0(ClientServerMessageFlags.SMSG_NEEDLE_PAYLOAD, new GClass9.MessageHandlerDelegate(GClass6.smethod_5));
		GClass9.smethod_0(ClientServerMessageFlags.SMSG_HOOK_PAYLOAD, new GClass9.MessageHandlerDelegate(GClass6.smethod_6));
		GClass9.smethod_0(ClientServerMessageFlags.SMSG_TOOL_OFFSETS, new GClass9.MessageHandlerDelegate(GClass6.smethod_8));
	}
}
