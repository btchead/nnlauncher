using System;

// Token: 0x02000012 RID: 18
public enum GEnum1
{
	// Token: 0x04000045 RID: 69
	pLuaTaintGetDecryptedPtr,
	// Token: 0x04000046 RID: 70
	pFramescriptRegisterGadget,
	// Token: 0x04000047 RID: 71
	fLuaIsString,
	// Token: 0x04000048 RID: 72
	fLuaIsNumber,
	// Token: 0x04000049 RID: 73
	fLuaToInteger,
	// Token: 0x0400004A RID: 74
	fLuaTolString,
	// Token: 0x0400004B RID: 75
	fLuaToBoolean,
	// Token: 0x0400004C RID: 76
	fLuaPushString,
	// Token: 0x0400004D RID: 77
	fLuaPushlString,
	// Token: 0x0400004E RID: 78
	fLuaPushInteger,
	// Token: 0x0400004F RID: 79
	fLuaPushNil,
	// Token: 0x04000050 RID: 80
	fLuaPushBoolean,
	// Token: 0x04000051 RID: 81
	fLuaPushNumber,
	// Token: 0x04000052 RID: 82
	fLuaToNumber,
	// Token: 0x04000053 RID: 83
	fLuaCreateTable,
	// Token: 0x04000054 RID: 84
	fLuaType,
	// Token: 0x04000055 RID: 85
	fLuaTaintSetEncrypted,
	// Token: 0x04000056 RID: 86
	fLuaTaint,
	// Token: 0x04000057 RID: 87
	fLuaFirstTaint,
	// Token: 0x04000058 RID: 88
	fLuaState,
	// Token: 0x04000059 RID: 89
	fLuaSetTable,
	// Token: 0x0400005A RID: 90
	fLuaSetField,
	// Token: 0x0400005B RID: 91
	fLuaGetField,
	// Token: 0x0400005C RID: 92
	fLuaSetTop,
	// Token: 0x0400005D RID: 93
	fLuaCall,
	// Token: 0x0400005E RID: 94
	fLuaCStep,
	// Token: 0x0400005F RID: 95
	fLuaHNew,
	// Token: 0x04000060 RID: 96
	fLuaToPointer,
	// Token: 0x04000061 RID: 97
	script_RunScript,
	// Token: 0x04000062 RID: 98
	fPlaceholder03,
	// Token: 0x04000063 RID: 99
	fPlaceholder04,
	// Token: 0x04000064 RID: 100
	fPlaceholder05,
	// Token: 0x04000065 RID: 101
	fPlaceholder06,
	// Token: 0x04000066 RID: 102
	fScriptSecurecall,
	// Token: 0x04000067 RID: 103
	fSpoofLuaPtr,
	// Token: 0x04000068 RID: 104
	fHookLuaPtr,
	// Token: 0x04000069 RID: 105
	fClntObjMgrObjectPtr,
	// Token: 0x0400006A RID: 106
	fCGUnit_C__SetTrackingDirection,
	// Token: 0x0400006B RID: 107
	pCallSpoofRsp18,
	// Token: 0x0400006C RID: 108
	pCallSpoofTable,
	// Token: 0x0400006D RID: 109
	pWorldTraceLine,
	// Token: 0x0400006E RID: 110
	pStopFallClient,
	// Token: 0x0400006F RID: 111
	pStopFallServer,
	// Token: 0x04000070 RID: 112
	m_focusGUID,
	// Token: 0x04000071 RID: 113
	m_mouseoverGUID,
	// Token: 0x04000072 RID: 114
	m_lastHardwareAction,
	// Token: 0x04000073 RID: 115
	m_accName,
	// Token: 0x04000074 RID: 116
	s_ObjMgr,
	// Token: 0x04000075 RID: 117
	m_world,
	// Token: 0x04000076 RID: 118
	m_corpse,
	// Token: 0x04000077 RID: 119
	m_camera,
	// Token: 0x04000078 RID: 120
	pcurl_easy_init,
	// Token: 0x04000079 RID: 121
	pcurl_easy_strerror,
	// Token: 0x0400007A RID: 122
	pcurl_easy_getinfo,
	// Token: 0x0400007B RID: 123
	pcurl_easy_perform,
	// Token: 0x0400007C RID: 124
	pcurl_easy_cleanup,
	// Token: 0x0400007D RID: 125
	pcurl_easy_setopt,
	// Token: 0x0400007E RID: 126
	pcurl_cmalloc,
	// Token: 0x0400007F RID: 127
	pcurl_calloc,
	// Token: 0x04000080 RID: 128
	pcurl_crealloc,
	// Token: 0x04000081 RID: 129
	pcurl_cfree,
	// Token: 0x04000082 RID: 130
	fSendMovementHeartbeat,
	// Token: 0x04000083 RID: 131
	pkernel32_CreateThread,
	// Token: 0x04000084 RID: 132
	pkernel32_RemoveDirectoryW,
	// Token: 0x04000085 RID: 133
	pkernel32_WriteFile,
	// Token: 0x04000086 RID: 134
	pkernel32_GetFileAttributesW,
	// Token: 0x04000087 RID: 135
	pkernel32_ReadFile,
	// Token: 0x04000088 RID: 136
	pkernel32_GetCurrentDirectoryW,
	// Token: 0x04000089 RID: 137
	pkernel32_CreateFileW,
	// Token: 0x0400008A RID: 138
	pkernel32_FindNextFileW,
	// Token: 0x0400008B RID: 139
	pkernel32_OpenFile,
	// Token: 0x0400008C RID: 140
	pkernel32_CreateDirectoryW,
	// Token: 0x0400008D RID: 141
	pkernel32_FindFirstFileW,
	// Token: 0x0400008E RID: 142
	pkernel32_CloseHandle,
	// Token: 0x0400008F RID: 143
	pkernel32_MultiByteToWideChar,
	// Token: 0x04000090 RID: 144
	pkernel32_WideCharToMultiByte,
	// Token: 0x04000091 RID: 145
	pkernel32_GetFileSizeEx,
	// Token: 0x04000092 RID: 146
	pkernel32_DeleteFileW,
	// Token: 0x04000093 RID: 147
	puser32_GetKeyState,
	// Token: 0x04000094 RID: 148
	puser32_GetAsyncKeyState,
	// Token: 0x04000095 RID: 149
	m_isMacClientPtr
}
