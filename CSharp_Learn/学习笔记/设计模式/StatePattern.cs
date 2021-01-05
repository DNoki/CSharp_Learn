using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 允许一个对象在其内部状态改变时自动改变其行为，对象看起来就像是改变了它的类。
    /// <summary>
    /// 状态模式
    /// </summary>
    public class StatePattern
    {
        /// <summary>
        /// 抽象状态
        /// </summary>
        public abstract class State
        {
            public abstract void Handle();
        }

        /// <summary>
        /// 具体状态
        /// </summary>
        public class ConcreteStateA:State
        {
            public override void Handle()
            {
            }
        }
        public class ConcreteStateB : State
        {
            public override void Handle()
            {
            }
        }

        /// <summary>
        /// 环境角色
        /// </summary>
        public class Context
        {
            public State State { get; set; }

            public void Request()
            {
                this.State.Handle();
            }
        }

    }
}
