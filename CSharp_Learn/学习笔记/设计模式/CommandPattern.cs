using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 命令模式属于对象的行为型模式。命令模式是把一个操作或者行为抽象为一个对象中，通过对命令的抽象化来使得发出命令的责任和执行命令的责任分隔开。命令模式的实现可以提供命令的撤销和恢复功能。
    /// <summary>
    /// 命令模式
    /// </summary>
    public class CommandPattern
    {
        /// <summary>
        /// 调用者，接受高层命令并执行
        /// </summary>
        public class Invoker
        {
            public Command Command;

            public void Go()
            {
                this.Command.Execute();
            }

            public Invoker(Command command)
            {
                this.Command = command;
            }
        }

        /// <summary>
        /// 抽象的命令
        /// </summary>
        public abstract class Command
        {
            /// <summary>
            /// 命令接收者
            /// </summary>
            protected Receiver Receiver;

            /// <summary>
            /// 命令执行方法
            /// </summary>
            public abstract void Execute();

            public Command(Receiver receiver)
            {
                this.Receiver = receiver;
            }
        }

        /// <summary>
        /// 具体命令
        /// </summary>
        public class ConcreteCommand : Command
        {
            /// <summary>
            /// 调用命令
            /// </summary>
            public override void Execute()
            {
                this.Receiver.Action();
            }

            public ConcreteCommand(Receiver receiver) : base(receiver) { }
        }

        /// <summary>
        /// 接受者，接受调用者的命令并执行，实际干活的
        /// </summary>
        public class Receiver
        {
            public void Action() { }
        }
    }

    public partial class Client
    {
        public void UseCommand()
        {
            // 初始化
            var receiver = new CommandPattern.Receiver();
            var command = new CommandPattern.ConcreteCommand(receiver);
            var invoker = new CommandPattern.Invoker(command);

            // 发出命令
            invoker.Go();
        }
    }
}
