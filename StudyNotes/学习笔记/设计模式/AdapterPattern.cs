using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 把一个类的接口变换成客户端所期待的另一种接口，从而使原本接口不匹配而无法一起工作的两个类能够在一起工作。
    //* 你想使用一个已经存在的类，而它的接口不符合你的需求。
    //* 你想创建一个可以复用的类，该类可以与其他不相关的类或不可预见的类（即那些接口可能不一定兼容的类）协同工作。
    //* （仅适用于对象Adapter）你想使用一些已经存在的子类，但是不可能对每一个都进行子类化以匹配它们的接口。对象适配器可以适配它的父类接口。
    /// <summary>
    /// 类的适配器模式
    /// </summary>
    public class AdapterPattern
    {
        /// <summary>
        /// 类的适配器
        /// </summary>
        public class AdapterForClass : Adaptee, ITarget
        {
            /// <summary>
            /// 实现目标接口的方法
            /// </summary>
            public void Request()
            {
                this.SpecificRequest();
            }
        }
        /// <summary>
        /// 对象的适配器
        /// </summary>
        public class AdapterForObject : ITarget
        {
            /// <summary>
            /// 引用需要适配的类的实例
            /// </summary>
            private Adaptee Adaptee = new Adaptee();

            /// <summary>
            /// 实现目标接口的方法
            /// </summary>
            public void Request()
            {
                this.Adaptee.SpecificRequest();
            }
        }

        /// <summary>
        /// 需要适配的类
        /// </summary>
        public class Adaptee
        {
            public void SpecificRequest() { }
        }
        /// <summary>
        /// 目标接口
        /// </summary>
        public interface ITarget
        {
            /// <summary>
            /// 目标方法
            /// </summary>
            void Request();
        }
    }


    public partial class Client
    {
        public void UseAdapter()
        {
            // 生成适配器
            var adapter = new AdapterPattern.AdapterForClass();
            // 通过适配器使用目标类的方法
            adapter.Request();
        }
    }
}
