using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


/// <summary>
/// 与非托管代码交互操作
/// </summary>
public class InteroperationWithUnmanagedCode
{
    public const string DLL_PATH = "../../../../x64/Debug/Cpp_Learn.dll";

    /// <summary>
    /// 加载动态库
    /// </summary>
    /// <param name="lpFileName"></param>
    /// <returns></returns>
    [DllImport("kernel32.dll")]
    private static extern IntPtr LoadLibrary(string lpFileName);
    /// <summary>
    /// 获取函数地址
    /// </summary>
    /// <param name="hModule"></param>
    /// <param name="lpProcName"></param>
    /// <returns></returns>
    [DllImport("kernel32.dll")]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
    /// <summary>
    /// 释放动态库
    /// </summary>
    /// <param name="hModule"></param>
    /// <returns></returns>
    [DllImport("kernel32.dll")]
    private static extern bool FreeLibrary(IntPtr hModule);


    /// <summary>
    /// 对话框的内容和行为。
    /// </summary>
    public enum MsgBoxCheckFlags : uint
    {
        MB_OK = 0x00000000u,
        MB_OKCANCEL,
        MB_ABORTRETRYIGNORE,
        MB_YESNOCANCEL,
        MB_YESNO,
        MB_RETRYCANCEL,
        MB_CANCELTRYCONTINUE,
    }
    /// <summary>
    /// 显示一个模式对话框，其中包含系统图标，一组按钮以及特定于应用程序的简短消息，例如状态或错误信息。该消息框返回一个整数值，该整数值指示用户单击了哪个按钮。
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-messagebox
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="lpText"></param>
    /// <param name="lpCaption"></param>
    /// <param name="uType"></param>
    /// <returns></returns>
    [DllImport("User32.dll", EntryPoint = "MessageBox", CharSet = CharSet.Auto)]
    private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, MsgBoxCheckFlags uType);

    /// <summary>
    /// DllImport声明动态库中的函数
    /// </summary>
    [DllImport(DLL_PATH)]
    private static extern void SampleCFunction();
    /// <summary>
    /// 定义 EntryPoint 可以重命名函数
    /// </summary>
    [DllImport(DLL_PATH, EntryPoint = "SampleFunction")]
    private static extern void SampleFunctionChangedName();

    /// <summary>
    /// 基本类型传递
    /// </summary>
    /// <param name="_void_P"></param>
    /// <param name="_short"></param>
    /// <param name="_ushort"></param>
    /// <param name="_int"></param>
    /// <param name="_uint"></param>
    /// <param name="_long"></param>
    /// <param name="_ulong"></param>
    /// <param name="_bool"></param>
    /// <param name="_float"></param>
    /// <param name="_double"></param>
    /// <param name="_char"></param>
    /// <param name="_uchar"></param>
    /// <param name="_wchar_t"></param>
    /// <param name="_char_P"></param>
    /// <param name="_C_char_P"></param>
    /// <param name="_wchar_t_P"></param>
    /// <param name="_C_wchar_t_P"></param>
    [DllImport(DLL_PATH)]
    private static extern void SampleBaseType(
        IntPtr _void_P,
        short _short,
        ushort _ushort,
        int _int,
        uint _uint,
        long _long,
        ulong _ulong,
        bool _bool,
        float _float,
        double _double,
        char _char,
        byte _uchar,
        char _wchar_t,
        string _char_P,
        string _C_char_P,
        string _wchar_t_P,
        string _C_wchar_t_P
        );


    public static void TestRun()
    {
        // 调用 WindowsAPI User32.dll 的 MsgBox 函数
        //var result = MessageBox(IntPtr.Zero, "Text", "Caption", MsgBoxCheckFlags.MB_YESNOCANCEL);
        //Console.WriteLine(result);

        SampleCFunction();
        SampleFunctionChangedName();

        // 动态加载dll
        {
            var dllPtr = LoadLibrary(DLL_PATH);
            var funPtr = GetProcAddress(dllPtr, "SampleFunction");

            var action = Marshal.GetDelegateForFunctionPointer<Action>(funPtr);
            action.Invoke();

            Console.WriteLine($"释放dll：{FreeLibrary(dllPtr)}");
        }

        SampleBaseType(
            IntPtr.MaxValue,
            short.MaxValue,
            ushort.MaxValue,
            int.MaxValue,
            uint.MaxValue,
            long.MaxValue,
            ulong.MaxValue,
            default(bool),
            float.MaxValue,
            double.MaxValue,
            'C',
            (byte)'C',
            'C',
            "_char_P",
            "_C_char_P",
            "_wchar_t_P",
            "_C_wchar_t_P"
            );
    }
}
