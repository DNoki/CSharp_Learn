using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 工厂方法模式通过面向对象编程中的多态性来将对象的创建延迟到具体工厂中，从而解决了简单工厂模式中存在的问题，也很好地符合了开放封闭原则（即对扩展开发，对修改封闭）。
    /// <summary>
    /// 工厂方法模式
    /// </summary>
    public class FactoryMethodPattern
    {
        /// <summary>
        /// 抽象工厂类
        /// </summary>
        public abstract class Creator
        {
            public abstract IProduct FactoryMethod();
        }
        /// <summary>
        /// 用于生产产品1的工厂
        /// </summary>
        public class ConcreteFactory1 : Creator
        {
            public override IProduct FactoryMethod()
            {
                return new ConcreteProduct1();
            }
        }
        /// <summary>
        /// 用于生产产品2的工厂
        /// </summary>
        public class ConcreteFactory2 : Creator
        {
            public override IProduct FactoryMethod()
            {
                return new ConcreteProduct2();
            }
        }

        /// <summary>
        /// 产品
        /// </summary>
        public interface IProduct { }
        /// <summary>
        /// 具体产品1
        /// </summary>
        public class ConcreteProduct1 : IProduct { }
        /// <summary>
        /// 具体产品2
        /// </summary>
        public class ConcreteProduct2 : IProduct { }
    }



    public partial class Client
    {
        /// <summary>
        /// 使用工厂方法
        /// </summary>
        public void UseFactoryMethod()
        {
            // 初始化工厂
            FactoryMethodPattern.Creator factory1 = new FactoryMethodPattern.ConcreteFactory1();
            FactoryMethodPattern.Creator factory2 = new FactoryMethodPattern.ConcreteFactory2();

            // 产生对象
            var product1 = factory1.FactoryMethod();
            var product2 = factory2.FactoryMethod();
        }
    }

}
