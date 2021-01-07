// dllmain.cpp : 定义 DLL 应用程序的入口点。
#include "pch.h"

#pragma execution_character_set("utf-8")

#include <iostream>

using namespace std;

BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

// 以C语言接口的方式导出
extern "C" _declspec(dllexport) void SampleCFunction()
{
    cout << "执行 void SampleCFunction()" << endl;
}

// 以模块定义文件的方式导出
// 在Source.def文件的 EXPORTS 下，添加该函数
void SampleFunction()
{
    cout << "执行 void SampleFunction()" << endl;
}

// 平台调用数据类型
// https://docs.microsoft.com/zh-cn/previous-versions/dotnet/netframework-4.0/ac7ay120(v=vs.100)
void SampleBaseType(
    void* _void_P,
    short _short,
    unsigned short _ushort,
    int _int,
    unsigned int _uint,
    long _long,
    unsigned long _ulong,
    bool _bool,
    float _float,
    double _double,
    char _char,
    unsigned char _uchar,
    wchar_t _wchar_t,
    char* _char_P,
    const char* _C_char_P,
    wchar_t* _wchar_t_P,
    const wchar_t* _C_wchar_t_P
    )
{
    cout << "SampleBaseType()" << endl;
    cout << _void_P << endl;
    cout << _short << endl;
    cout << _ushort << endl;
    cout << _int << endl;
    cout << _uint << endl;
    cout << _long << endl;
    cout << _ulong << endl;
    cout << _bool << endl;
    cout << _float << endl;
    cout << _double << endl;
    cout << _char << endl;
    cout << _uchar << endl;
    cout << _wchar_t << endl;
    cout << _char_P << endl;
    cout << _C_char_P << endl;
    cout << _wchar_t_P << endl;
    cout << _C_wchar_t_P << endl;
}