using System;
using System.Collections.Generic;
using System.Text;

public static class MathExtension
{
    /// <summary>
    /// 将数字从一个范围重新映射到另一范围。
    /// </summary>
    /// <param name="value"></param>
    /// <param name="oldMin"></param>
    /// <param name="oldMax"></param>
    /// <param name="newMin"></param>
    /// <param name="newMax"></param>
    /// <returns></returns>
    public static double Remap(double value, double oldMin, double oldMax, double newMin, double newMax)
    {
        return Math.Clamp((value - oldMin) / (oldMax - oldMin) * (newMax - newMin) + newMin, newMin, newMax);
    }
}