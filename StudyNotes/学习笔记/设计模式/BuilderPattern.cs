using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 将一个复杂对象的构造与它的表示分离，使得同样的构建过程可以创建不同的表示
    // 适用性
    // *当创建复杂对象的算法应该独立于该对象的组成部分以及它们的装配方式时。
    // *当构造过程必须允许被构造的对象有不同的表示时。
    /// <summary>
    /// 创建者模式
    /// </summary>
    public class BuilderPattern
    {
        /// <summary>
        /// 创建者
        /// </summary>
        public abstract class Builder
        {
            public abstract void BuildPart1();
            public abstract void BuildPart2();
            public abstract IProduct GetProduct { get; }
        }
        /// <summary>
        /// 具体创建者A
        /// </summary>
        public class ConcreteBuilderA : Builder
        {
            private ConcreteProductA productA;

            public override IProduct GetProduct => this.productA;

            public override void BuildPart1() { }
            public override void BuildPart2() { }
        }
        /// <summary>
        /// 具体创建者B
        /// </summary>
        public class ConcreteBuilderB : Builder
        {
            private ConcreteProductA productB;

            public override IProduct GetProduct => this.productB;

            public override void BuildPart1() { }
            public override void BuildPart2() { }
        }

        /// <summary>
        /// 指挥者
        /// </summary>
        public class Director
        {
            /// <summary>
            /// 构造产品
            /// </summary>
            /// <returns></returns>
            public void Construct(Builder builder)
            {
                builder.BuildPart1();
                builder.BuildPart2();
            }
        }

        /// <summary>
        /// 产品抽象类
        /// </summary>
        public interface IProduct { }
        /// <summary>
        /// 具体产品A
        /// </summary>
        public class ConcreteProductA : IProduct { }
        /// <summary>
        /// 具体产品B
        /// </summary>
        public class ConcreteProductB : IProduct { }

    }



    public partial class Client
    {
        public void UseBuilder()
        {
            // 生成指挥者与创建者
            var direcotr = new BuilderPattern.Director();
            var builderA = new BuilderPattern.ConcreteBuilderA();
            var builderB = new BuilderPattern.ConcreteBuilderB();

            // 调用指挥者组装产品
            direcotr.Construct(builderA);
            // 获取产品A
            var productA = builderA.GetProduct;

            direcotr.Construct(builderB);
            var productB = builderB.GetProduct;
        }
    }
}
