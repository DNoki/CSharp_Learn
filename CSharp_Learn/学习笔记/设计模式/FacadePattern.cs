using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 由外观类去保存各个子系统的引用，实现由一个统一的外观类去包装多个子系统类，然而客户端只需要引用这个外观类，然后由外观类来调用各个子系统中的方法。
    /// <summary>
    /// 外观模式
    /// </summary>
    public class FacadePattern
    {
        /// <summary>
        /// 外观类
        /// </summary>
        public class Facade
        {
            private SubSystem1 subSystem1 = new SubSystem1();
            private SubSystem2 subSystem2 = new SubSystem2();

            /// <summary>
            /// 为子系统提供一个共同的对外接口
            /// </summary>
            public void MethodA()
            {
                subSystem1.Method();
                subSystem2.Method();
            }
        }

        public class SubSystem1
        {
            public void Method() { }
        }
        public class SubSystem2
        {
            public void Method() { }
        }
    }


    public partial class Client
    {
        public void UseFacade()
        {
            // 生成外观类
            FacadePattern.Facade facade = new FacadePattern.Facade();
            // 使用对外接口
            facade.MethodA();
        }
    }
}
