using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 将抽象部分与它的实现部分分离，使它们都可以独立地变化。
    /// <summary>
    /// 桥接模式 
    /// </summary>
    public class BridgePattern
    {
        /// <summary>
        /// 抽象化
        /// </summary>
        public abstract class Abstraction
        {
            /// <summary>
            /// 分离的实现部分
            /// </summary>
            public Implementor Implementor { get; set; }

            /// <summary>
            /// 抽象化行为，不再提供实现而是调用实现类中的实现
            /// </summary>
            public virtual void Operation()
            {
                Implementor.OperationImp();
            }
        }
        /// <summary>
        /// 提炼的抽象
        /// </summary>
        public class RefinedAbstration : Abstraction
        {
            public override void Operation()
            {
                base.Operation();
            }
        }


        /// <summary>
        /// 实现化
        /// </summary>
        public abstract class Implementor
        {
            public abstract void OperationImp();
        }
        /// <summary>
        /// 具体实现A
        /// </summary>
        public class ConcreteImplementorA : Implementor
        {
            /// <summary>
            /// 提供具体的实现
            /// </summary>
            public override void OperationImp() { }
        }
        /// <summary>
        /// 具体实现B
        /// </summary>
        public class ConcreteImplementorB : Implementor
        {
            public override void OperationImp() { }
        }
    }



    public partial class Client
    {
        public void UseBridge()
        {
            // 创建对象
            BridgePattern.Abstraction abstraction = new BridgePattern.RefinedAbstration();
            // 实现行为
            abstraction.Implementor = new BridgePattern.ConcreteImplementorA();

            // 调用实现的行为
            abstraction.Operation();
        }
    }
}
