using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TestProgram
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // 用于准确地测量运行时间
            var timer = new Stopwatch();
            timer.Restart();

            Method();

            timer.Stop();
            Console.WriteLine("");
            Console.WriteLine($"Run Time:{timer.ElapsedMilliseconds}ms");
            Console.ReadLine();
        }

        public static void Method()
        {

        }
    }
}
