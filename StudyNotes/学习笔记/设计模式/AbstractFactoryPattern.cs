using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 抽象工厂模式：提供一个创建产品的接口来负责创建相关或依赖的对象，而不具体明确指定具体类
    // 抽象工厂允许客户使用抽象的接口来创建一组相关产品，而不需要知道或关心实际生产出的具体产品是什么。这样客户就可以从具体产品中被解耦。
    /*三种工厂模式的对比：
        简单工厂模式：
        只有一个工厂类一个生产方法，根据参数不同生产不同的产品。

        工厂方法模式：
        每一个工厂类只负责一个产品生产，不生成其它产品。好比一条生产线只生产一个产品线。

        抽象工厂模式：
        每一个工厂类提供多个方法，可以生产不同的产品。好比多条生产线可以生产多家产品。
         */
    /// <summary>
    /// 抽象工厂模式
    /// </summary>
    public class AbstractoryPattern
    {
        /// <summary>
        /// 抽象工厂
        /// </summary>
        public abstract class AbstractFactory
        {
            public abstract IProductA CreateA();
            public abstract IProductB CreateB();
        }
        /// <summary>
        /// 工厂1生产自己的1系列产品
        /// </summary>
        public class ConcreteFactory1 : AbstractFactory
        {
            public override IProductA CreateA() => new ProductA1();
            public override IProductB CreateB() => new ProductB1();
        }
        /// <summary>
        /// 工厂2生产自己的2系列产品
        /// </summary>
        public class ConcreteFactory2 : AbstractFactory
        {
            public override IProductA CreateA() => new ProductA2();
            public override IProductB CreateB() => new ProductB2();
        }

        /// <summary>
        /// 抽象产品A
        /// </summary>
        public interface IProductA { }
        /// <summary>
        /// 具体产品A1
        /// </summary>
        public class ProductA1 : IProductA { }
        /// <summary>
        /// 具体产品A2
        /// </summary>
        public class ProductA2 : IProductA { }

        /// <summary>
        /// 抽象产品B
        /// </summary>
        public interface IProductB { }
        /// <summary>
        /// 具体产品B1
        /// </summary>
        public class ProductB1 : IProductB { }
        /// <summary>
        /// 具体产品B2
        /// </summary>
        public class ProductB2 : IProductB { }
    }



    public partial class Client
    {
        /// <summary>
        /// 使用抽象工厂
        /// </summary>
        public void UseAbstractFactory()
        {
            // 初始化工厂
            var factory1 = new AbstractoryPattern.ConcreteFactory1();
            var factory2 = new AbstractoryPattern.ConcreteFactory2();

            var productA1 = factory1.CreateA();
            var productA2 = factory2.CreateA();
            var productB1 = factory1.CreateB();
            var productB2 = factory2.CreateB();
        }
    }
}
