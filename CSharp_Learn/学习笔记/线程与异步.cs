using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAndAsyn
{
    class 线程与异步
    {
        /*
            如无需返回值，则使用ThreadPool
            如需要更多控制，使用Task
         
            #BeginInvoke、ThreadPool、Task三类异步方法的区别和速度比较
            https://www.cnblogs.com/hnsongbiao/p/5064760.html
        */

        public static int AsynTime = 4;
        public static int MainTime = 3;

        public static int GlobalVar = 0;

        public static void Main()
        {
            var watch = new Stopwatch(); // 使用 Stopwatch类 对程序部分代码进行计时
            DelegateProcess();
            Console.Read();
        }

        public static void AsynMethod()
        {
            for (var i = 0; i < AsynTime; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"{GlobalVar++}.. \t\t异步线程已经过 {i + 1} 秒。");
            }
        }
        public static void AsynMethod(string text)
        {
            for (var i = 0; i < AsynTime; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"\t\t异步线程已经过 {i + 1} 秒。输入的文本：{text}");
            }
        }
        public static string AsynMethodReturn()
        {
            for (var i = 0; i < AsynTime; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"\t\t带结果异步线程已经过 {i + 1} 秒。");
            }
            return "返回的结果";
        }
        public static async Task<string> AsynTaskReturn()
        {
            Console.WriteLine($"\t\t开始执行异步任务。");
            //await Task.Delay(1000);
            await Task.Run(AsynMethod);
            return "返回的结果";
        }


        /// <summary>
        /// 使用线程池
        /// </summary>
        public static void ThreadPoolProcess()
        {
            //进程的建立是需要时间的，在进程上开线程也是需要消耗CPU时间,操作系统需要分配给新开的线程地址空间、栈空间、寄存器等，在线程结束的时候，操作系统又将这些东西回收（着同样需要消耗时间）。
            //所以我们在多线程的处理中如果遇到要很多次地开启线程去处理一些很简单但是要求应答速度快的任务。
            //我们就可以把以前用过的线程拿出来重新使用，而不用每次都创建分别那些地址空间和寄存器。所以我们的任务如果对线程创建的效率要求很高的话（比如服务器对客户端的应答），就可以考虑使用线程池。

            //你无需自己建立线程，只需把你要做的工作写成函数，然后作为参数传递给ThreadPool.QueueUserWorkItem()方法就行了，传递的方法就是依靠WaitCallback代理对象，而线程的建立、管理、运行等工作都是由系统自动完成的，你无须考虑那些复杂的细节问题。

            var result = 0;
            ThreadPool.QueueUserWorkItem(obj => AsynMethod());
            ThreadPool.QueueUserWorkItem(obj => AsynMethod("666"));
            ThreadPool.QueueUserWorkItem(obj => result = 233 + 433);
            for (var i = 0; i < MainTime; i++)
            {
                Thread.Sleep(750);
                Console.WriteLine($"主线程已经过 {(i + 1) * 0.75f} 秒。{GlobalVar++}");
            }
            Console.WriteLine($"主线程已经结束。");
            Console.WriteLine(result);
        }

        /// <summary>
        /// 使用Task
        /// </summary>
        public static void TaskProcess()
        {
            // 相比于线程池
            // ThreadPool不支持线程的取消、完成、失败通知等交互性操作
            // ThreadPool不支持线程执行的先后次序

            // 创建Task
            //var task = new Task<string>(AsynMethodReturn);
            //task.Start();

            //var task = Task.Run(AsynMethodReturn);
            var task = AsynTaskReturn();

            //取消Task
            //{
            //    var tokenSource = new CancellationTokenSource();// 向Task传播取消命令
            //    var token = tokenSource.Token;
            //    Func<string> method = () =>
            //    {
            //        token.ThrowIfCancellationRequested();
            //        return "返回的结果";
            //    };
            //    var task = new Task<string>(method, token);
            //    task.Start();
            //    tokenSource.Cancel();
            //}

            // 创建一个在目标任务完成时异步执行的延续任务
            task.ContinueWith((t) =>
            {
                Console.WriteLine($"异步任务完成。{nameof(t.IsCanceled)} = {t.IsCanceled}。{nameof(t.IsCompleted)} = {t.IsCompleted}。{nameof(t.IsFaulted)} = {t.IsFaulted}");
                if (!t.IsCanceled && !t.IsFaulted) Console.WriteLine(t.Result);
            });

            for (var i = 0; i < MainTime; i++)
            {
                Thread.Sleep(750);
                Console.WriteLine($"{GlobalVar++}.. 主线程已经过 {(i + 1) * 0.75f} 秒。");
            }
            Console.WriteLine($"主线程已经结束。");
            //Console.WriteLine(task.Result);//异步调用的结果
            //var result1 = await task;//异步调用的结果


        }

        /// <summary>
        /// 利用委托实现异步方法
        /// </summary>
        public static void DelegateProcess()
        {
            Action method = AsynMethod;
            var result = method.BeginInvoke(null, null);
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"主线程已经过 {(i + 1) * 0.5f} 秒。");
            }
            Console.WriteLine($"主线程已经结束。");

            method.EndInvoke(result);
        }

        public static void ThreadProcess()
        {
            var thread = new Thread(AsynMethod);
            thread.Name = "Thread Name";
            thread.Start();

            // 强行终止线程
            //thread.Abort();
            //thread.Join();
        }

    }
}
