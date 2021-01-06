using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 组合模式，将对象组合成树形结构以表示“部分-整体”的层次结构，组合模式使得用户对单个对象和组合对象的使用具有一致性。
    /// <summary>
    /// 组合模式
    /// </summary>
    public class CompositePattern
    {
        /// <summary>
        /// 对象接口定义
        /// </summary>
        public abstract class Component
        {
            public abstract void Operation();
            public abstract void Add(Component component);
            public abstract void Remove(Component component);
            public abstract Component GetChild(int number);
        }

        /// <summary>
        /// 叶节点
        /// </summary>
        public class Leaf : Component
        {
            /// <summary>
            /// 叶节点的行为
            /// </summary>
            public override void Operation() { }

            public override void Add(Component component)
            {
                throw new Exception("不能向叶节点添加节点");
            }
            public override void Remove(Component component)
            {
                throw new Exception("不能从叶节点移除节点");
            }
            public override Component GetChild(int number)
            {
                throw new Exception("不能从叶节点获取节点");
            }
        }

        /// <summary>
        /// 复合节点
        /// </summary>
        public class Composite : Component
        {
            private List<Component> children = new List<Component>();

            /// <summary>
            /// 子节点的行为
            /// </summary>
            public override void Operation()
            {
                foreach (var child in children)
                {
                    child.Operation();
                }
            }

            public override void Add(Component component) => children.Add(component);
            public override void Remove(Component component) => children.Remove(component);
            public override Component GetChild(int number) => children[number];
        }
    }


    public partial class Client
    {
        public void UseComposite()
        {
            // 创建一个复合模型
            CompositePattern.Component component = new CompositePattern.Composite();
            // 添加一个复合节点
            component.Add(new CompositePattern.Composite());
            // 为刚添加的复合节点添加叶节点
            component.GetChild(0).Add(new CompositePattern.Leaf());
            // 使用叶节点的行为
            component.GetChild(0).GetChild(0).Operation();
        }
    }
}
