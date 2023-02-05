using System;

// Token: 0x02000010 RID: 16
public class GClass7
{
	// Token: 0x060000C9 RID: 201 RVA: 0x00004544 File Offset: 0x00002744
	public static GClass11 smethod_0(string string_0, string string_1)
	{
		GClass11 gclass = new GClass11(GEnum0.CMSG_AUTH);
		gclass.method_15(new byte[] { 7, 1 });
		gclass.method_14(string_0, 32);
		gclass.method_7(105);
		gclass.method_14(string_1, 32);
		return gclass;
	}

	// Token: 0x060000CA RID: 202 RVA: 0x00004588 File Offset: 0x00002788
	public static GClass11 smethod_1(byte[] byte_0)
	{
		return new GClass11(GEnum0.CMSG_KEY);
	}

	// Token: 0x060000CB RID: 203 RVA: 0x000045A0 File Offset: 0x000027A0
	public static GClass11 smethod_2(string string_0, ulong ulong_0, string string_1)
	{
		GClass11 gclass = new GClass11(GEnum0.CMSG_REQUEST_OFFSETS);
		gclass.method_7((ushort)string_0.Length);
		gclass.method_14(string_0, string_0.Length);
		gclass.method_9(ulong_0);
		gclass.method_7((ushort)string_1.Length);
		gclass.method_14(string_1, string_1.Length);
		return gclass;
	}

	// Token: 0x060000CC RID: 204 RVA: 0x000045F4 File Offset: 0x000027F4
	public static GClass11 smethod_3(string string_0)
	{
		GClass11 gclass = new GClass11(GEnum0.CMSG_REQUEST_TOOL_OFFSETS);
		gclass.method_7((ushort)string_0.Length);
		gclass.method_14(string_0, string_0.Length);
		return gclass;
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00004624 File Offset: 0x00002824
	public static GClass11 smethod_4(string string_0, ulong ulong_0, ulong ulong_1, string string_1, string string_2)
	{
		GClass11 gclass = new GClass11(GEnum0.CMSG_REQEUEST_APAYLOAD);
		gclass.method_7((ushort)string_0.Length);
		gclass.method_14(string_0, string_0.Length);
		gclass.method_9(ulong_0);
		gclass.method_9(ulong_1);
		gclass.method_7((ushort)string_1.Length);
		gclass.method_14(string_1, string_1.Length);
		gclass.method_7((ushort)string_2.Length);
		gclass.method_14(string_2, string_2.Length);
		return gclass;
	}

	// Token: 0x060000CE RID: 206 RVA: 0x0000469C File Offset: 0x0000289C
	public static GClass11 smethod_5(string string_0, byte[] byte_0, int int_0, int int_1)
	{
		GClass11 gclass = new GClass11(GEnum0.CMSG_UPLOAD_GAMEMODULE);
		ushort num = (ushort)string_0.Length;
		gclass.method_7(num);
		gclass.method_14(string_0, (int)num);
		gclass.method_4(byte_0.Length);
		gclass.method_4(int_0);
		gclass.method_4(int_1);
		gclass.method_15(byte_0);
		return gclass;
	}

	// Token: 0x060000CF RID: 207 RVA: 0x000046E8 File Offset: 0x000028E8
	public static GClass11 smethod_6(string string_0)
	{
		GClass11 gclass = new GClass11(GEnum0.CMSG_REQUEST_SCRIPTS);
		ushort num = (ushort)string_0.Length;
		gclass.method_7(num);
		gclass.method_14(string_0, (int)num);
		return gclass;
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00004718 File Offset: 0x00002918
	public static GClass11 smethod_7(uint uint_0)
	{
		GClass11 gclass = new GClass11(GEnum0.CMSG_DOWNLOAD_SCRIPT_REQUEST);
		gclass.method_8(uint_0);
		return gclass;
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x000022F9 File Offset: 0x000004F9
	static int smethod_8(string string_0)
	{
		return string_0.Length;
	}
}
