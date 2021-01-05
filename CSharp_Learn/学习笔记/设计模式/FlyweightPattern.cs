using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 运用共享技术有效地支持大量细粒度的对象。享元模式主要用来解决由于大量的细粒度对象所造成的内存开销的问题，它在实际的开发中并不常用，可以作为底层的提升性能的一种手段。
    //当以下所有的条件都满足时，可以考虑使用享元模式：
    //* 一个应用程序使用了大量的对象。
    //* 完全由于使用大量的对象，造成很大的存储开销。
    //* 对象的大多数状态都可变为外部状态。
    //* 如果删除对象的外部状态，那么可以用相对较少的共享对象取代很多组对象。
    //* 应用程序不依赖于对象标识。由于Flyweight对象可以被共享，对于概念上明显有别的对象，标识测试将返回真值。
    //
    // 使用享元模式需要维护一个记录了系统已有的所有享元的表，而这需要耗费资源。因此，应当在有足够多的享元实例可供共享时才值得使用享元模式。
    //
    //享元模式可以避免大量相似类的开销，在软件开发中如果需要生成大量细粒度的类实例来表示数据，
    //如果这些实例除了几个参数外基本上都是相同的，这时候就可以使用享元模式来大幅度减少需要实例化类的数量。
    //如果能把这些参数（指的这些类实例不同的参数）移动类实例外面，在方法调用时将他们传递进来，
    //这样就可以通过共享大幅度地减少单个实例的数目。（这个也是享元模式的实现要领）,然而我们把类实例外面的参数称为享元对象的外部状态，把在享元对象内部定义称为内部状态。具体享元对象的内部状态与外部状态的定义为：
    //内部状态：在享元对象的内部并且不会随着环境的改变而改变的共享部分
    //外部状态：随环境改变而改变的，不可以共享的状态。

    /// <summary>
    /// 享元模式
    /// </summary>
    public class FlyweightPattern
    {
        /// <summary>
        /// 创建并管理flyweight对象。它需要确保合理地共享flyweight；当用户请求一个flyweight时，FlyweightFactory对象提供一个已创建的实例，如果请求的实例不存在的情况下，就新创建一个实例；
        /// </summary>
        public class FlyweightFactory
        {
            public Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();

            public Flyweight GetFlyweight(string key)
            {
                Flyweight flyweight = this.flyweights[key] as Flyweight;
                if (flyweights == null)
                {
                    // 驻留池中不存在key
                    flyweight = new ConcreteFlyweight(key);
                }
                return flyweight;
            }

            public FlyweightFactory()
            {
                flyweights.Add("Flyweight1", new ConcreteFlyweight("Flyweight1"));
                flyweights.Add("Flyweight2", new ConcreteFlyweight("Flyweight2"));
            }
        }

        public abstract class Flyweight
        {
            /// <summary>
            /// 抽象享元类，提供享元类具有的方法
            /// </summary>
            /// <param name="extrinsicState">外部状态</param>
            public abstract void Operation(int extrinsicState);
        }

        /// <summary>
        /// 具体享元类
        /// </summary>
        public class ConcreteFlyweight : Flyweight
        {
            /// <summary>
            /// 内部状态
            /// </summary>
            private string intrinsicState;

            public override void Operation(int extrinsicState)
            {
                // 具体方法
                var result = intrinsicState + extrinsicState;
            }

            public ConcreteFlyweight(string innerState)
            {
                this.intrinsicState = innerState;
            }
        }
    }


    public partial class Client
    {
        public void UseFlyweight()
        {
            // 初始化享元工厂
            FlyweightPattern.FlyweightFactory flyweightFactory = new FlyweightPattern.FlyweightFactory();

            // 外部状态
            int externalState = 0;

            // 判断是否存在Flyweight1，如果已经创建就直接使用创建的对象
            FlyweightPattern.Flyweight flyweight = flyweightFactory.GetFlyweight("Flyweight1");
            // 把外部状态作为享元对象的方法调用参数
            flyweight.Operation(externalState);
        }
    }
}
