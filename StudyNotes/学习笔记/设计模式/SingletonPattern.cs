using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 单例模式：确保一个类只有一个实例，并提供一个访问它的全局访问点
    public class SingletonPattern
    {
        /// <summary>
        /// 单例模式
        /// </summary>
        public class Singleton
        {
            /// <summary>
            /// 唯一实例
            /// </summary>
            private static volatile Singleton uniqueInstance;// volatile确保实例始终为最新值 // 可以被多个线程访问
                                                             /// <summary>
                                                             /// 定义一个标识确保线程同步
                                                             /// </summary>
            private static readonly object locker = new object();

            /// <summary>
            /// 单例对象的全局访问点
            /// </summary>
            public static Singleton GetInstance
            {
                get
                {
                    // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
                    // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
                    // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
                    // 双重锁定只需要一句判断就可以了
                    if (uniqueInstance == null)
                    {
                        lock (locker)
                        {
                            // 如果类的实例不存在则创建，否则直接返回
                            if (uniqueInstance == null)
                            {
                                uniqueInstance = new Singleton();
                            }
                        }
                    }
                    return uniqueInstance;
                }
            }


            /// <summary>
            /// 禁止外部生成实例
            /// </summary>
            private Singleton() { }
        }

        /// <summary>
        /// 泛型单例模式(指定类型的单例对象)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Singleton<T> where T : class, new()//new()约束要求泛型类型参数必须提供一个无参数的构造函数。
        {
            private static volatile T instance;
            private static readonly object locker = new object();

            /// <summary>
            /// 单例对象的全局访问点
            /// </summary>
            public static T GetInstance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (locker)
                        {
                            // 如果类的实例不存在则创建，否则直接返回
                            if (instance == null)
                            {
                                instance = new T();
                            }
                        }
                    }
                    return instance;
                }
            }

            /// <summary>
            /// 禁止外部生成实例
            /// </summary>
            private Singleton() { }
        }
    }


    public partial class Client
    {
        /// <summary>
        /// 使用单例模式
        /// </summary>
        public void UseSingleton()
        {
            var instance = SingletonPattern.Singleton.GetInstance;
            var instance2 = SingletonPattern.Singleton<object>.GetInstance;
        }
    }
}
