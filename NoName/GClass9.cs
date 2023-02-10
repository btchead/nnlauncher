using System;
using System.Collections.Generic;

public class GClass9
{
	public static void smethod_0(ClientServerMessageFlags messageFlag, GDelegate0 gdelegate0_0)
	{
		dictionary_0[messageFlag] = gdelegate0_0;
	}

	public static bool smethod_1(BinaryReaderWrapper gclass10_0, Server gclass12_0, ClientServerMessageFlags genum0_0)
	{
		try
		{
			if (dictionary_0.ContainsKey(genum0_0))
			{
				dictionary_0[genum0_0](gclass10_0, gclass12_0);
				return true;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
		return false;
	}

	public static Dictionary<ClientServerMessageFlags, GDelegate0> dictionary_0 = new Dictionary<ClientServerMessageFlags, GDelegate0>();

	public delegate void GDelegate0(BinaryReaderWrapper packet, Server server);
}
