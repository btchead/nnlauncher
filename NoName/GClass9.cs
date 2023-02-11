using System;
using System.Collections.Generic;

public class GClass9
{
	public static void smethod_0(ClientServerMessageFlags messageFlag, MessageHandlerDelegate gdelegate0_0)
	{
		dictionary_0[messageFlag] = gdelegate0_0;
	}

	public static bool smethod_1(BinaryMessageReader gclass10_0, Server gclass12_0, ClientServerMessageFlags messageFlag)
	{
		try
		{
			if (dictionary_0.ContainsKey(messageFlag))
			{
				dictionary_0[messageFlag](gclass10_0, gclass12_0);
				return true;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
		return false;
	}

	public static Dictionary<ClientServerMessageFlags, MessageHandlerDelegate> dictionary_0 = new Dictionary<ClientServerMessageFlags, MessageHandlerDelegate>();

	public delegate void MessageHandlerDelegate(BinaryMessageReader packet, Server server);
}
