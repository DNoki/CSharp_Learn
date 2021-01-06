using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 给某一个对象提供一个代理，并由代理对象控制对原对象的引用。
    /// <summary>
    /// 代理模式
    /// </summary>
    public class ProxyPattern
    {
        /// <summary>
        /// 抽象主题
        /// </summary>
        public abstract class Subject
        {
            public abstract void Request();
        }

        /// <summary>
        /// 被代理的对象
        /// </summary>
        public class RealSubject : Subject
        {
            public override void Request() { }
        }

        /// <summary>
        /// 代理类
        /// </summary>
        public class Proxy : Subject
        {
            RealSubject realSubject;

            public override void Request()
            {
                if (this.realSubject == null)
                {
                    this.realSubject = new RealSubject();
                }

                // 代理角色通常在将客户端调用传递到真实主题之前或之后，都要执行一些其他的操作，而不是单纯地将调用传递给真实主题对象。
                // 在这里插入一些操作……

                // 调用委托请求
                realSubject.Request();

                // 在这里插入一些操作……
            }
        }
    }


    public partial class Client
    {
        /// <summary>
        /// 使用代理模式
        /// </summary>
        public void UseProxy()
        {
            // 创建一个代理对象并发出请求
            ProxyPattern.Proxy proxy = new ProxyPattern.Proxy();
            proxy.Request();
        }
    }
}
