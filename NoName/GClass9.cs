using System;
using System.Collections.Generic;

// Token: 0x02000014 RID: 20
public class GClass9
{
	// Token: 0x060000D5 RID: 213 RVA: 0x000025A7 File Offset: 0x000007A7
	public static void smethod_0(ClientServerMessageFlags genum0_0, GClass9.GDelegate0 gdelegate0_0)
	{
		GClass9.dictionary_0[genum0_0] = gdelegate0_0;
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00004800 File Offset: 0x00002A00
	public static bool smethod_1(GClass10 gclass10_0, GClass12 gclass12_0, ClientServerMessageFlags genum0_0)
	{
		try
		{
			if (GClass9.dictionary_0.ContainsKey(genum0_0))
			{
				GClass9.dictionary_0[genum0_0](gclass10_0, gclass12_0);
				return true;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
		return false;
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x0000221E File Offset: 0x0000041E
	static string smethod_2(object object_0)
	{
		return object_0.ToString();
	}

	// Token: 0x060000DA RID: 218 RVA: 0x000022B2 File Offset: 0x000004B2
	static void smethod_3(string string_0)
	{
		Console.WriteLine(string_0);
	}

	// Token: 0x04000096 RID: 150
	public static Dictionary<ClientServerMessageFlags, GClass9.GDelegate0> dictionary_0 = new Dictionary<ClientServerMessageFlags, GClass9.GDelegate0>();

	// Token: 0x02000015 RID: 21
	// (Invoke) Token: 0x060000DC RID: 220
	public delegate void GDelegate0(GClass10 packet, GClass12 server);
}
