using System;
using System.Collections.Generic;

public class MessageProcessor
{
	public static void RegisterMessageHandler(ClientServerMessageFlags messageFlag, MessageHandlerDelegate messageHandlerDelegate)
	{
		_messageHandlers[messageFlag] = messageHandlerDelegate;
	}

	public static void ProcessMessage(BinaryMessageReader binaryMessageReader, Server server, ClientServerMessageFlags messageFlag)
	{
		try
		{
			if (_messageHandlers.ContainsKey(messageFlag))
			{
				_messageHandlers[messageFlag](binaryMessageReader, server);
			}
		}
		catch (Exception ex)
		{
			Logger.Error("Exception thrown while processing message handler: ", ex);
		}
	}

	public static Dictionary<ClientServerMessageFlags, MessageHandlerDelegate> _messageHandlers = new Dictionary<ClientServerMessageFlags, MessageHandlerDelegate>();

	public delegate void MessageHandlerDelegate(BinaryMessageReader packet, Server server);
}
