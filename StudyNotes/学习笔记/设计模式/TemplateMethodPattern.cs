using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 定义一个操作中的算法的骨架，而将一些步骤延迟到子类中。Template Method使得子类可以不改变一个算法的结构即可重定义该算法的某些特定步骤。
    /// <summary>
    /// 模板方法模式
    /// </summary>
    public class TemplateMethodPattern
    {
        /// <summary>
        /// 抽象类，定义了一个模板方法，调用子类的方法来完成具体的算法步骤
        /// </summary>
        public abstract class AbstractClass
        {
            /// <summary>
            /// 模板方法，设为不可重写，以避免派生类更改流程的执行顺序
            /// </summary>
            public void TemplateMethod()
            {
                // 模板方法执行顺序
                this.PrimitiveOperation1();
                this.PrimitiveOperation2();
            }

            public virtual void PrimitiveOperation1() { }
            public virtual void PrimitiveOperation2() { }
        }

        /// <summary>
        /// 具体类
        /// </summary>
        public class ConcreteClass : AbstractClass
        {
            /// <summary>
            /// 重写的方法
            /// </summary>
            public override void PrimitiveOperation1() => base.PrimitiveOperation1();
            public override void PrimitiveOperation2() => base.PrimitiveOperation2();
        }
    }

    public partial class Client
    {
        public void UseTemplateMethod()
        {
            // 创建一个模板方法
            var templateMethod = new TemplateMethodPattern.ConcreteClass();
            // 调用模板方法
            templateMethod.TemplateMethod();
        }
    }
}
