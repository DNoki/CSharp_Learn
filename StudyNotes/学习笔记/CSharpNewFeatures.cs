using System;
using System.Collections.Generic;

namespace CSharp_NewFeatures_9_0
{
    // record关键字：记录是一个语法糖，本质上还是class或者struct，它只编译时生效，运行时并没有记录这个东西

    // 使用关键字 record 声明一个记录类型，这是一个引用类型
    public record RecordClass(string Name, int Age);

    public record RecordClassCustom(string Name, int Age)
    {
        // 自定义构造函数
        public RecordClassCustom() : this("Zhangsan", 1) { }

        // 覆盖构造函数中的 Age
        public int Age { get; set; } = Age;

        // 额外的自定义属性
        public DateTime Birth { get; set; }
    }


    // init-only 属性
    public class InitOnlyProperty
    {
        public string Name { get; init; }

        public void Test()
        {
            // 允许在创建对象是初始化属性值
            var obj = new InitOnlyProperty() { Name = "MyName", };

            // 不允许修改
            //obj.Name = "MyName";
        }
    }


    // 类型推导强化
    public class Sample
    {
        public void Test()
        {
            // 从目标推导 new 的类型：允许省去 new T() 的 T 的部分
            Dictionary<string, List<(int x, int y)>> cache = new();

            // 条件运算符目标类型推导
            var b = true;
            int? i = b ? 1 : null; // 明确 int? 则允许编译
        }
    }


    // 返回值类型支持协变
    abstract class Food { }
    class Meat : Food { }
    abstract class Animal
    {
        public abstract Food GetFood();
    }
    class Tiger : Animal
    {
        public override Meat GetFood() { return new Meat(); }
    }


    // 其他
    public class Other
    {
        public void Test()
        {
            // 本地大小的整型，这两种类型的大小是32还是64取决于平台
            nint x;
            nuint y;

            // Lambda 弃元参数
            Func<int, int, int> lambda = (_, _) => 0;

            // 静态匿名函数
            int a = 0;
            Func<int, int> OK = static x => x * x;
            // Func<int, int> NG = static x => a * x;

        }

    }
}

namespace CSharp_NewFeatures_10_0
{
    using CSharp_NewFeatures_9_0;

    // record struct

    // 等价于 public record RecordClass(string Name, int Age);
    public record class RecordClass2(string Name, int Age);

    // 使用 record struct 声明结构体记录类型
    public record struct RecordStruct(string Name, int Age);
    // 声明只读结构体记录类型
    public readonly record struct ReadonlyRecordStruct(string Name, int Age);
}
