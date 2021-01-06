using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 简单工厂模式又叫静态方法模式（因为工厂类都定义了一个静态方法），由一个工厂类根据传入的参数决定创建出哪一种产品类的实例
    /// <summary>
    /// 简单工厂模式
    /// </summary>
    public class SimpleFactoryPattern
    {        /// <summary>
             /// 简单工厂
             /// </summary>
        public class SimpleFactory
        {
            /// <summary>
            /// 根据名称产生对象
            /// </summary>
            /// <param name="productName">类型名称</param>
            /// <returns></returns>
            public static IProduct Creator(string productName)
            {
                IProduct product = null;
                if (productName == "SimpleFactoryProduct1")
                {
                    product = new Product1();
                }
                else if (productName == "SimpleFactoryProduct2")
                {
                    product = new Product2();
                }
                return product;
            }
        }

        /// <summary>
        /// 简单工厂的产品
        /// </summary>
        public interface IProduct { }
        /// <summary>
        /// 简单工厂的商品1
        /// </summary>
        public class Product1 : IProduct { }
        /// <summary>
        /// 简单工厂的商品2
        /// </summary>
        public class Product2 : IProduct { }
    }


    public partial class Client
    {
        /// <summary>
        /// 使用简单工厂
        /// </summary>
        public void UseSimpleFactory()
        {
            // 使用简单工厂产生对象
            var product1 = SimpleFactoryPattern.SimpleFactory.Creator("SimpleFactoryProduct1");
            var product2 = SimpleFactoryPattern.SimpleFactory.Creator("SimpleFactoryProduct2");
        }
    }
}
