using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Others
{
    /// <summary>
    /// Unicode编码（将Unicode字符转为十六进制）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string EnUnicode(string str)
    {
        StringBuilder strResult = new StringBuilder();
        if (!string.IsNullOrEmpty(str))
        {
            for (int i = 0; i < str.Length; i++)
            {
                strResult.Append("\\u");
                strResult.Append(((int)str[i]).ToString("x").PadLeft(4, '0'));
            }
        }
        return strResult.ToString();
    }

    /// <summary>
    /// Unicode解码（将十六进制转为Unicode字符）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string DeUnicode(string str)
    {
        //最直接的方法Regex.Unescape(str);
        Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
        return reg.Replace(str, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
    }
}