using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 文件读写
/// </summary>
public static class OperIO
{
    //    // 读取配置文件
    //        if (File.Exists(Application.StartupPath + @"\配置文件.ini"))
    //        {
    //            string strFilePath = Application.StartupPath + @"\配置文件.ini";
    //    GameWindow_ReadPlacement(strFilePath);
    //    GameExpedition_ReadPlacement(strFilePath);
    //    GameAttack_ReadPlacement(strFilePath);
    //}
    // Convert.ToInt32(OperINI.ReadIni("游戏窗口", "手动偏移X", 0.ToString(), strFilePath)),
    //OperINI.WriteIni("游戏窗口", "手动偏移X", GlobalObject.ClickOffsetXY.X.ToString(), strFilePath);

    /// <summary>
    /// 文件根目录
    /// </summary>
    public static string DirectoryPath { get; private set; } = string.Empty;
    /// <summary>
    /// 配置文件路径
    /// </summary>
    public static string IniPath { get; private set; } = string.Empty;
    /// <summary>
    /// 日志文件路径
    /// </summary>
    public static string LogPath { get; private set; } = string.Empty;


    /// <summary>
    /// 读取键值
    /// </summary>
    /// <param name="lpAppName">小节</param>
    /// <param name="lpKeyName">键名</param>
    /// <param name="lpDefault">默认键值</param>
    /// <param name="lpReturnedString">接收INI文件中的值</param>
    /// <param name="nSize">缓存器的大小</param>
    /// <param name="lpFileName">文件路径</param>
    /// <returns></returns>
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
    /// <summary>
    /// 写入键值
    /// </summary>
    /// <param name="lpAppName">小节</param>
    /// <param name="lpKeyName">键名</param>
    /// <param name="lpString">键值</param>
    /// <param name="lpFileName">文件路径</param>
    /// <returns></returns>
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

    /// <summary>
    /// 读取键值
    /// </summary>
    /// <param name="section">小节</param>
    /// <param name="key">键</param>
    /// <param name="defValue">默认键值</param>
    /// <param name="filePath">文件路径</param>
    /// <returns>读取的键值</returns>
    public static string ReadIni(string section, string key, string defValue, string filePath = null)
    {
        try
        {
            if (filePath == null) filePath = IniPath;
            StringBuilder retValue = new StringBuilder(500);
            GetPrivateProfileString(section, key, defValue, retValue, 500, filePath);
            return retValue.ToString();
        }
        catch (Exception e)
        {
            WriteLog("INI文件读取失败。" + e.Message);
            return defValue;
        }
    }
    /// <summary>
    /// 写入键值
    /// </summary>
    /// <param name="section">小节</param>
    /// <param name="key">键</param>
    /// <param name="value">键值</param>
    /// <param name="filePath">文件路径</param>
    /// <returns>布尔值</returns>
    public static bool WriteIni(string section, string key, string value, string filePath = null)
    {
        if (filePath == null) filePath = IniPath;
        return WritePrivateProfileString(section, key, value, filePath);
    }
    /// <summary>
    /// 删除节
    /// </summary>
    /// <param name="section">小节</param>
    /// <param name="filePath">文件路径</param>
    /// <returns></returns>
    public static bool DeleteSection(string section, string filePath)
    { return WritePrivateProfileString(section, null, null, filePath); }
    /// <summary>
    /// 删除键
    /// </summary>
    /// <param name="section">小节</param>
    /// <param name="key">键</param>
    /// <param name="filePath">文件路径</param>
    /// <returns></returns>
    public static bool DeleteKey(string section, string key, string filePath)
    { return WritePrivateProfileString(section, key, null, filePath); }

    /// <summary>
    /// 写入日志
    /// </summary>
    /// <param name="text"></param>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static bool WriteLog(string text, string filePath = null)
    {
        try
        {
            if (filePath == null) filePath = LogPath;
            //new StreamReader(LogPath, Encoding.Unicode);
            var log = new StreamWriter(LogPath, true, Encoding.Unicode);
            log.WriteLine($"{DateTime.Now.ToShortTimeString()}  {text}");
            log.Close();
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }

    static OperIO()
    {
        //DirectoryPath = CQApp.Instance.CQS_getAppDirectory();
        IniPath = DirectoryPath + @"绅提无舰@群秘书舰.ini";
        LogPath = DirectoryPath + @"Log.log";

        if (!Directory.Exists(OperIO.DirectoryPath))
            Directory.CreateDirectory(OperIO.DirectoryPath);
    }
}
