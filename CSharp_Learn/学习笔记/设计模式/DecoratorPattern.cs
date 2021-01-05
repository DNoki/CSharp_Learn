using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 装饰模式是在不必改变原类文件和使用继承的情况下，动态地扩展一个对象的功能。它是通过创建一个包装对象，也就是装饰来包裹真实的对象。
    //1. 需要扩展一个类的功能，或给一个类添加附加职责。
    //2. 需要动态的给一个对象添加功能，这些功能可以再动态的撤销。
    //3. 需要增加由一些基本功能的排列组合而产生的非常大量的功能，从而使继承关系变的不现实。
    //4. 当不能采用生成子类的方法进行扩充时。一种情况是，可能有大量独立的扩展，为支持每一种组合将产生大量的子类，使得子类数目呈爆炸性增长。另一种情况可能是因为类定义被隐藏，或类定义不能用于生成子类。
    /// <summary>
    /// 装饰者模式
    /// </summary>
    public class DecoratorPattern
    {
        /// <summary>
        /// 抽象组件类
        /// </summary>
        public abstract class Component
        {
            /// <summary>
            /// 抽象行为
            /// </summary>
            public abstract void Operation();
        }

        /// <summary>
        /// 被装饰的对象
        /// </summary>
        public class ConcreteComponent : Component
        {
            public override void Operation() { }
        }
        /// <summary>
        /// 装饰抽象类
        /// </summary>
        public abstract class Decorator : Component
        {
            private Component component;

            public override void Operation()
            {
                if (this.component != null)
                {
                    component.Operation();
                }
            }

            /// <summary>
            /// 装饰者的实现需要传入被装饰的对象
            /// </summary>
            /// <param name="component"></param>
            public Decorator(Component component)
            {
                this.component = component;
            }
        }

        /// <summary>
        /// 具体装饰
        /// </summary>
        public class ConcreteDecoratorA : Decorator
        {
            public override void Operation()
            {
                base.Operation();

                // 添加新的行为
                AddOperation();
            }

            /// <summary>
            /// 新的行为方法
            /// </summary>
            public void AddOperation() { }

            public ConcreteDecoratorA(Component component) : base(component) { }
        }
        /// <summary>
        /// 具体装饰B
        /// </summary>
        public class ConcreteDecoratorB : Decorator
        {
            public override void Operation()
            {
                base.Operation();

                // 添加新的行为
                AddOperation();
            }

            /// <summary>
            /// 新的行为方法
            /// </summary>
            public void AddOperation() { }

            public ConcreteDecoratorB(Component component) : base(component) { }
        }
    }

    public partial class Client
    {
        public void UseDecorator()
        {
            // 被装饰的对象
            var component = new DecoratorPattern.ConcreteComponent();

            // 装饰好的对象
            var decoratorA = new DecoratorPattern.ConcreteDecoratorA(component);
            var decoratorB = new DecoratorPattern.ConcreteDecoratorB(component);

            decoratorA.Operation();
            decoratorB.Operation();

            // 合并装饰好的对象
            var decorator = new DecoratorPattern.ConcreteDecoratorB(decoratorA) as DecoratorPattern.Decorator;
        }
    }
}
