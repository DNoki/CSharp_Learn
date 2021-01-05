using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 通过给出一个原型对象来指明所要创建的对象类型，然后用复制这个对象的方法来创建出更多的同类型对象。
    //• 当要实例化的类是在运行时刻指定时，例如，通过动态装载；
    //• 为了避免创建一个与产品类层次平行的工厂类层次时；
    //• 当一个类的实例只能有几个不同状态组合中的一种时。建立相应数目的原型并克隆它们可能比每次用合适的状态手工实例化该类更方便一些。
    /// <summary>
    /// 原型模式
    /// </summary>
    public class PrototypePattern
    {
        /// <summary>
        /// 抽象原型
        /// </summary>
        public abstract class Prototype
        {
            /// <summary>
            /// 原型抽象类提供一个克隆方法
            /// </summary>
            /// <returns></returns>
            public abstract Prototype Clone();
        }

        /// <summary>
        /// 具体的原型
        /// </summary>
        public class ConcretePrototypeA : Prototype
        {
            /// <summary>
            /// 调用MemberwiseClone方法创建浅拷贝
            /// </summary>
            /// <returns></returns>
            public override Prototype Clone() => this.MemberwiseClone() as Prototype;
        }
        public class ConcretePrototypeB : Prototype
        {
            public override Prototype Clone() => this.MemberwiseClone() as Prototype;
        }
    }


    public partial class Client
    {
        public void UsePrototype()
        {
            // 创建原型对象
            var prototypeA = new PrototypePattern.ConcretePrototypeA();
            // 克隆原型对象
            var clonePrototypeA = prototypeA.Clone();
        }
    }
}
