﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Flags特性的枚举
{
    [Flags]
    public enum MyFlags
    {
        Flag1 = 1,       // 1  
        Flag2 = 2,       // 10  
        Flag3 = 4,       // 100  
        Flag4 = 8,       // 1000
        Flag5 = 16,      // 10000
        Flag6 = 32,      // 100000
        Flag7 = 64,      // 1000000
        Flag8 = 128,     // 10000000
        Flag9 = 0b1_0000_0000 // 2进制数表示法
    }

    public static void 使用Flags特性的枚举()
    {
        // 使用或运算组合多个枚举状态
        MyFlags myFlags = MyFlags.Flag1 | MyFlags.Flag2 | MyFlags.Flag3;

        // 使用且运算判断变量是否包含该枚举项
        if ((myFlags & MyFlags.Flag4) == MyFlags.Flag4)
            Console.WriteLine("该变量包含 Flag4");
        if ((myFlags & MyFlags.Flag4) != 0)
            Console.WriteLine("该变量包含 Flag4");
        // 简单方法
        if (myFlags.HasFlag(MyFlags.Flag4)) Console.WriteLine("该变量包含 Flag4");

        // 使用且+取反来去掉其中一个状态
        myFlags = myFlags & (~MyFlags.Flag1);

        foreach (var name in System.Enum.GetNames(typeof(MyFlags)))
        {
            // 遍历枚举项
        }
    }
}

