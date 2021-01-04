//C#

#if false
 面向对象三大基本特性：封装,继承,多态

 ┄┄┄┄┄┄┄┄┄┄┄┄┄┄┄┄┄┄┄
 封装

 继承─┬─继承（泛化）─┬─实现继承
       │                └─可视继承
       └─组合（聚合）─┬─接口继承
                         └─纯虚类

 多态─┬─覆盖─┬─虚函数
       │        └─接口
       └─重载───同名函数
 ┄┄┄┄┄┄┄┄┄┄┄┄┄┄┄┄┄┄┄
 ────────────────────────────────────────────────────────────
 封装：
     隐藏内部功能的具体实现，只保留和外部交流数据的借口。就好比电视机，用一个外壳把内部零部件及控制电路封装起来，只提供按钮或者遥控器接口供人使用。
     封装可以隐藏实现细节，使得代码模块化。

   封装成类或结构：
     类和结构实际上是创建对象的模板，每个对象都包含数据，并提供了处理和访问数据的方法。
     类是存储在堆（heap）上的引用类型，而结构是存储在堆栈（stack）上的值类型
     在语法上，结构和类非常相似，主要的区别是使用关键字struct代替class来声明结构，在c#中，可以把结构看做是缩小的类。

     类（class）
     （1）类定义了每个类对象（实例）可以包含什么数据和功能。举例来说，如果一个类表示客户，我们就可以定义字段customerId,name和address，以包含该客户的信息，还可以定义处理存储在这些字段中的数据的功能。接着，如我们常写的那样，new一下实例化对象，以表示某个客户，并为这个实例设置这些字段，使用其功能。
     （2）类成员
        类中的数据和函数称为类的成员。类成员可以分为数据成员和函数成员。
        数据成员包含了类的数据——字段、常量和事件。
        函数成员提供了操作类中数据的某些功能，包括方法，构造函数，属性和终结器（finalizer）、运算符和索引器。
     （3）特殊的类
        在封装类的时候，我们可能会按照实际的需要构造一些“特殊”的类（比如静态类，抽象类等），下面简要介绍说明一下常见的特殊的类。
        <1>、静态类
          如果类只包含静态的方法和属性，该类就可以是静态的。静态类在功能上与使用私有静态构造函数创建的类相同。不能创建静态类的事例。使用static关键字，编译器可以检查以后是否给该类添加了实例成员，如果是，就会产生一个编译错误。
        <2>、密封类
          c#允许把类和方法声明为sealed。对于类来说，这就表示不能继承该类；对于方法来说，这表示不能重写该方法。但是在方法上使用sealed是没有意义的，除非该方法本身是某个基类上另一个方法的重写形式。如果定义一个新方法，但不想让别人重写它，首先就不要把它声明为virtual。但如果要重写某个基类方法，sealed关键字就提供了一种方式，可以确保为方法提供的重写代码是最终的代码，其他人不能再重写它。
        <3>、抽象类
          c#允许把类和方法声明为abstract，抽象类不能被实例化，而抽象函数没有执行代码，必须在非抽象的派生类中重写。
        <4>、部分类
          partial关键字允许把类，结构或接口放在多个文件中。一般情况下，一个类存储在单个文件中。但有时，多个开发人员需要访问一个类，或者某种类型的代码生成器生成了一个类的某部分，所以把类放在多个文件中是有益的。
        <5>、Object类
          众所周知，.net类都派生自System.Object。这个类的方法是所有.net类都实现的方法。

     结构（struct）
       结构在内存中的存储方式、访问方式和一些特征（如结构不支持继承）与类不同。
       在许多方面，可以把c#中的结构看做是缩小的类。它基本上与类相同，但更适合于把一些数据组合起来的场合。
       <1>、结构是值类型
         结构是值类型，它存储在堆栈中或存储为内联（inline）（如果它是另一个对象的一部分，就会保存在堆中），其生存期的限制与简单的数据类型一样。
         注意：因为结构是值类型，所以new运算符和类及其他引用类型的工作方式不同。new一个结构并不分配堆中的内存，而是调用相应的构造函数，根据传递给它的参数，初始化所有的字段。
       <2>、结构不能被继承
         结构不是为继承设计的。不能从一个结构中继承，唯一的例外是结构派生于类System.Object.因此结构也可以访问System.Object的方法。结构的继承链是这样的：每个结构派生于System.ValueType，System.ValueType派生于System.Object。System.ValueType并没有给System.Object添加任何新成员，但提供了一些更适合结构的执行代码。
         注意：结构可以实现接口。也就是说结构并不支持实现继承，但支持接口继承。
         a、结构总是派生于System.ValueType，它们还可以派生于任意多个接口。
         b、类可以派生于用户选择的另一个类，它们还可以派生于任意多个接口。
       <3>、结构的构造函数（结构不能包含显式的无参构造函数）
         为结构定义构造函数的方式与为类定义构造函数的方式相同，但不允许定义无参数的构造函数，其原因影藏在.net运行库的执行方式中。即：.net运行库不能调用用户提供的定制无参数构造函数，因此ms禁止在c#中的结构内使用无参数的构造函数。
 ────────────────────────────────────────────────────────────
 继承：
     继承最大的好处是实现代码的高效重用，也更加形象的描述现实世界中对象的关系。

   继承的使用：
     程序中使用面向对象的继承特性时，主要分为单继承和多继承两种情况
     1．单继承
        单继承一般用于类之间的继承，C#中的类只支持单继承，实现单继承时，使用“子类:基类”格式。
     2．多继承
        如果要使用多继承，需要使用接口，因为C#中的类只支持单继承，而接口支持多继承，实现多继承时，继承的多个接口中间用逗号（,）隔开。

   继承的原则：
     1.除了object类，每个类有且只有一个直接基类，如果没有显示指定类的直接基类，那么它的直接基类就隐含的设置为object。object类没有任何直接或间接基类，它是所有的终极基类。
     2.无论基类成员的可访问性如何，除构造函数和析构函数外，所有其他基类的成员都能被子类继承，然而，有些继承成员在子类中可能是不可访问的，比如，基类的private成员在子类中不可访问，但是，如果将子类的对象作为参数传入基类的方法内，那么在基类的代码内部，就可以通过子类或者子类的对象来访问基类的private成员。
     3.子类可以扩展它的直接基类。
     4.继承是可以传递的，比如C类从B类继承，而B类从A类继承，那么C类就会既继承B类中的成员，又继承A类中的成员。
     5.类不能循环继承，比如A类继承于B类，而B类继承于C类，那么C类就不能再去继承A类，因为它们之间存在了一种循环关系。
     6.类的直接基类必须至少与类本身具有同样的可访问性，比如，如果从private类派生一个public类，将会导致编译时错误。如果从public类派生一个private类则是被允许的。
     7.在子类中可以声明具有相同名称或签名的新成员来隐藏从基类继承而来的成员，但是，隐藏继承而来的成员时并不移除该成员，而只是使被隐藏的成员在子类中不可以直接访问。
     8.类中可以声明虚方法等，而子类可以重写这些虚方法的实现。
     9.C#中只支持类的单一继承，但是支持接口的多重继承。
     10.类的实例包含在该类中及它的所有基类中声明的所有实例字段的集合，并且存在一个从子类到它的任何基类的隐式转换，因此，可以将子类的实例看成是其任何基类的实例的引用。
────────────────────────────────────────────────────────────
 多态：
   即同一个动作作用不同的对象产生不同的具体行为。比如，驾驶是一个动作，但是把驾驶作用在汽车和飞机上时，产生了不同的具体的驾驶操作与过程。它的好处是规范和简化接口的设计。比如，你所见到的电器的开关标记符号基本都是一样的，这样可以方便用户识别和理解。简单来说就是（使用基类或接口变量编程）
   在多态编程中，基类一般都是抽象类，其中拥有一个或多个抽象方法，各个子类可以根据需要重写这些方法。或者使用接口，每个接口都规定了一个或多个抽象方法，实现接口的类根据需要实现这些方法。
   因此，多态的实现分为两大基本类别：继承多态和接口多态。
   当一个派生类对象传入基类类型时，会被视为派生类类型，将会调用派生类的成员。

   应用继承实现对象的统一管理。
   应用接口定义对象的行为特征。
────────────────────────────────────────────────────────────

   扩充【显式接口成员实现】
     如果类实现两个接口，并且这两个接口包含具有相同签名的成员，那么在类中实现该成员时，将导致两个接口都使用该成员作为它们的实现，然而，如果两个接口成员实现不同的功能，那么这可能会导致其中一个接口的实现不正确或两个接口的实现都不正确，这时可以显式地实现接口成员，即创建一个仅通过该接口调用并且特定于该接口的类成员。显式接口成员实现是使用接口名称和一个句点命名该类成员来实现的。
   扩充【接口特征】
     1.接口类似于抽象基类：继承接口的任何非抽象类型都必须实现接口的所有成员；
     2.不能直接实例化接口；
     3.接口可以包含事件、索引器、方法和属性；
     4.接口不包含方法的实现；
     5.类和结构可从多个接口继承；
     6.接口自身可从多个接口继承。
   扩充【声明接口】
     （1）声明接口时，通常以大写字母“I”开头；
     （2）声明接口时，除interface关键字和接口名称外，其它的都是可选项；
     （3）可以使用new 、public、protected、internal和private等修饰符声明接口，但接口成员必须是公共的。
────────────────────────────────────────────────────────────

 面向对象五大基本原则 ：单一职责原则,开放封闭原则,替换原则,依赖原则,接口分离原则

 单一职责原则
   一个类的功能要单一，不能包罗万象。

 开放封闭原则
   一个模块在扩展性方面应该是开放的而在更改性方面应该是封闭的。

 替换原则
   子类应当可以替换父类并出现在父类能够出现的任何地方。

 依赖原则
   具体依赖抽象，上层依赖下层。

 接口分离原则
   模块间要通过抽象接口隔离开，而不是通过具体的类强耦合起来。
────────────────────────────────────────────────────────────
 标识符中常见的命名规则


#endif


//C# 预处理指令
//控制流语句中的条件表达式是在运行时求值的。而C#预处理器指令是在编译时调用的。预处理器指令（preprocessor directive）告诉C#编译器要编译哪些代码，并指出如何处理特定的错误和警告。C#预处理器指令还可以告诉C#编辑器有关代码组织的信息。
#define MyDefine // 使用 #define 定义符号。 当您将符号用作传递给 #if 指令的表达式时，此表达式的计算结果为 true
#undef MyUndef // #undef 使您可以取消符号的定义，以便通过将该符号用作 #if 指令中的表达式，使表达式的计算结果为 false
// 如果 C# 编译器遇到最后面跟有 #endif 指令的 #if 指令，则仅当指定的符号已定义时，它才会编译这两个指令之间的代码。
#if MyDefine
// 这里的代码会被编译
#else
//这里的代码不会被编译
//#warning 使您得以从代码的特定位置生成一级警告。
#warning 这是一段警告
//#error 使您可以从代码中的特定位置生成错误。
#error 这是一个错误
#endif
// #region 使您可以在使用 Visual Studio 代码编辑器的大纲显示功能时指定可展开或折叠的代码块。

#region

// 这里的代码可以被折叠

#endregion

// 取消警告
#pragma warning disable
#pragma warning restore

//using指令
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using Namespace;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Linq.Expressions;

//using StaticClass;// 使用静态方法

//命名空间
namespace Namespace
{
    //程序入口类
    class MainClass
    {
        static void Main(string[] args)
        {
            /*程序入口*/
        }
    }

    //嵌套命名空间
    namespace NestedNamespace
    { /*…*/
    }

    //类
    class Class
    {
        //语句块
        public void Test(int i = 0)
        {
        }

        //嵌套类型 //嵌套类型是在其他类型中声明的类型， 通常用于描述仅由包含它们的类型所使用的对象。
        class NestedClass
        {
        }

        struct NestedStruct
        {
        }

        interface INestedInterface
        {
        }

        //字段	字段是在类范围声明的变量。 字段可以是内置数值类型或其他类的实例。 例如，日历类可能具有一个包含当前日期的字段。
        int _field;
        int? nullableField; //表示可分配有 null 的值类型。等价于 Nullable<T>
        readonly int ReadonlyField; //只读字段只能在初始化期间或在构造函数中赋值。
        int[] array; // 声明数组
        System.Collections.ArrayList arrayList; // 声明ArrayList数组
        List<int> genericList; // 声明List数组（推荐）
        Class objectField = new Class(); //声明对象
        Class objectFieldAndInitialization = new Class() { _field = 0, array = new int[0] }; // 初始化器，声明对象并初始化对象成员
        Generic<Class> genericObject = new Generic<Class>(); //声明泛型对象
        MyDelegateCallBack DelegateMethod; //声明委托实例

        class ExpressionBodiedMembers : Class // 表达式成员 // C#7
        {
            int PropertyExpressionBodied1 // 属性表达式主体定义
            {
                get => _field;
                set => _field = value;
            }

            int PropertyExpressionBodied2 => _field; // get-only 属性表达式主体定义,直接只返回表达式结果的属性

            int this[uint i] // 索引器表达式主体定义
            {
                get => _field;
                set => _field = value;
            }

            int this[long i] => _field; // get-only 索引器表达式主体定义,直接只返回表达式结果的索引器

            event MyEventHandler EventExpressionBodied // 自定义事件访问器表达式主体定义
            {
                add => OnEvent += value;
                remove => OnEvent -= value;
            }

            public static int operator +(ExpressionBodiedMembers param1, int param2) => 0; // 重载运算符表达式主体定义

            int MethodExpressionBodied() => _field; // 函数表达式主体定义

            public ExpressionBodiedMembers() => _field++; // 构造函数表达式主体定义
            ~ExpressionBodiedMembers() => _field--; // 析构函数表达式主体定义
        }

        //常量 常量是在编译时设置其值并且不能更改其值的字段或属性。
        const int CONSTANT = 0;

        // volatile 关键字指示一个字段可以由多个同时执行的线程修改。 声明为 volatile 的字段不受编译器优化（假定由单个线程访问）的限制。 这样可以确保该字段在任何时间呈现的都是最新的值。
        volatile int volatileFiled = 0;

        // 属性 属性是类中可以像类中的字段一样访问的方法。 属性可以为类字段提供保护，以避免字段在对象不知道的情况下被更改。
        // 提示：在VS中输入 propg 可以快速的创建属性
        // 不要也不要让属性获取器抛出异常，避免修改对象状态。这样就意味着需要一种方法而不是属性获取器。
        int Property
        {
            get { return _field; }
            set { _field = value; }
        }

        int AutoProperty { get; set; } = 0; // 自动属性

        //方法 方法定义类可以执行的操作。 方法可以接受提供输入数据的参数，并且可以通过参数返回输出数据。 方法还可以不使用参数而直接返回值。
        void Method()
        {
            // 对象，由于类是引用类型，因此类对象的变量引用该对象在托管堆上的地址。
            Class object1; //声明对象
            object1 = new Class(); //实例化对象
            Class object2 = object1; //如果将同一类型的第二个对象分配给第一个对象，则两个变量都引用该地址的对象。
            Class2 _implicitObject = object1; //隐式转换

            //装箱：将值类型的数据打包到引用类型的实例中
            int v = 0;
            object obj = (object)v;
            //拆箱：从引用数据中提取值类型
            int i = (int)obj;

            // 匿名类型
            var anonymousTypes = new { _field, field1 = 0 };
            // 匿名方法 // 匿名方法返回的是一个委托事件
            // 匿名方法格式：delegate (参数列表) { 语句块 }
            DelegateMethod = delegate () { };
            // Lambda 表达式 // lambda 表达式是一个可用于创建委托或表达式树类型的匿名函数。
            // Lambda表达式的格式:(参数列表)=>表达式或语句块
            DelegateMethod = () => { };
            // 表达式树
            Expression<Func<int, int, int>> exp = (x, y) => x + y;
            exp.Compile()(1, 2);
            // Func<> Action<>泛型委托
            Func<int, int, string> funcMethod = (int param1, int param2) => "";
            Action actMethod = () => { };
            /* 上行代码等价于以下代码 */
#if false
        // 定义委托
        delegate string EventHandler(int param1, int param2);
        void Method()
        {
            // 定义委托实例 // 添加方法
            EventHandler funcMethod = new EventHandler(FuncMethod);
        }
        static string FuncMethod(int param1, int param2)
        { return ""; }
#endif

            // 异常处理语句 try - catch - finally
            try
            {
                try // 可能引发异常的代码块
                {
                    throw new Exception();
                    throw new MyException();
                    /*
                    抛出和重新抛出异常
                    当你希望在更深层次处理一个捕获到的异常时，维护原始异常状态和堆栈对于调试有极大的帮助。需要仔细地平衡，调试和安全注意事项。
                    简单的重新抛出异常也是一个好选择：
                    throw;
                    或者在新的throw中使用异常作为InnerException：
                    throw new CustomException（...，ex）;
                    不要显式地重新抛出捕获的异常，如下所示：
                    throw e;
                    这将复位异常状态到当前行，并且阻止调试。
                    一些异常发生在代码的上下文之外。对于这些情况，你可能需要添加事件的处理程序，如ThreadException或UnhandledException，而不是使用catch块。例如，表单处理程序线程的上下文中引发的Windows窗体异常。
                     */
                }
                catch (MyException) // 捕捉自定义或已知异常
                {
                }
                catch (Exception e) // 捕捉所有异常
                {
                    throw e; // 向上抛出该异常，会由上一级 try - catch 捕获
                    throw new Exception(e.Message, e); // 向上抛出一个新的异常
                    throw; // 等价于 throw new Exception();
                    (this.genericList != null ? "" : throw new Exception()).ToString(); // C# 7.0  可以在任何地方抛出异常
                }
                finally
                {
                    // 正常结束或异常结束后执行该段代码，无论是否出错都会被执行
                    // 即便在 catch 中抛出新的异常，finally 依旧会被执行
                    // 使用 finally 块，可以清理在 Try 中分配的任何资源。catch 和 finally 一起使用的常见方式是：在 try 块中获取并使用资源，在 catch 块中处理异常情况，并在 finally 块中释放资源。
                }

                // try之后的代码
            }
            catch (Exception)
            {
            }

            // 局部函数 // C#7.0
            int f(int param)
            {
                return param;
            }

            // 引用返回和局部引用
            ref int RefMethod(int number, int[] localList)
            {
                return ref localList[number];
            }

            var lList = new int[3];
            ref var temp = ref RefMethod(0, lList); // 局部引用
            lList[0] = 666;
            temp = 666; // 这两句语句是等价的


            // \符号 // 转义符号
            string str = "\"这是一段加了引号的文字\"";
            // @符号 // 强制不转义，取消\的转义属性
            str = @"C:\Windows";
            str = @"""这是一段加了引号的文字"""; // 若要在一个用 @ 引起来的字符串中包括一个双引号，请使用两对双引号
            //  内插字符串 $ // C#7 // 标识字符串文字作为插字符串。
            str = $"在字符串中插入变量{_field}的ToString";

            // 在集合中搜索符合条件的元素
            List<Namespace.ChildClass> list = new List<ChildClass>();
            list.Find(c => c is Namespace.BassClass); // 返回第一个符合条件的元素
            list.FindLast(b => b is Namespace.BassClass); // 返回最后一个符合条件的元素
            list.FindAll(a => a is Namespace.BassClass); // 返回所有符合条件的对象
            list.RemoveAll(item => item is BassClass); // 移除所有符合条件的对象
        }

        void Method /*重载*/(
            // 按值传递,对参数的更改不会影响调用方法中的原始副本
            int param,
            // 值传递引用类型，参数是引用类型的会将地址拷贝到参数中。实际应用时会改变实参地址指向的数据的值，但不会改变实参的地址
            int[] arrParam,
            // 引用传递，将实参对象地址传到形参。形参做的改动同样会改变实参
            ref int refParam, //传递到 ref 参数的参数必须最先初始化。
            out int outParam, //传递到 ref 参数的参数必须在方法中被赋值。
            params object[] _params //使用 params 关键字可以指定采用数目可变的参数的方法参数。
        )
        {
            outParam = 0;
            return;
        }

        [System.Obsolete("这是一个用来说明的方法", true)] //特性
        public static extern void externMethod(); //extern 修饰符用于声明在外部实现的方法。

        public void 元组()
        {
            // 利用元组返回多个返回值
            Tuple<int, int, string> TupleMethod()
            {
                return new Tuple<int, int, string>(0, 0, "");
            }

            (string, int, float) TupleMethodInCSharp7() // C# 7.0 
            {
                return ("", 0, 1f);
                (var v1, var v2, var v3) = TupleMethodInCSharp7(); // 解构
            }

            // 定义一个元组
            (string, int) tuple1;
            (string name, int age) tuple2; // 为元组字段定义名称(左侧指定)
            var tuple3 = (name: "name", age: 0); // 为元组字段定义名称(右侧指定)

            // 元组的解构 // 解构元组就是将元组中的字段值赋值给声明的局部变量
            var tuple = ("", 0, 1f);
            var (item1, item2, item3) = tuple;

            // 对象的解构
            var (name, age) = this;
        }

        /// <summary>
        /// 类中定义Deconstruct方法可以使对象解构
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        private void Deconstruct(out string name, out int age)
        {
            name = "";
            age = 0;
        }


        // LINQ查询表达式
        void LINQ()
        {
            List<int> list = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var result = from a in list
                         join b in list on a equals b into bResult // 若两结果相同则存入到变量中
                         from c in list // 一个查询表达式中可以有1个或多个from子句
                         let cResult = c // 创建一个新的范围变量并通过提供的表达式结果初始化该变量。
                         where c > 0 // 若条件成立则返回
                         orderby a ascending, bResult descending, c
                         group cResult by a
                into g // 对结果进行分组
                         select g // 返回结果
                into r // 将结果保存到变量并再次进行查询
                         select r;

            // from 关键字表示源序列中每个元素的本地范围变量
            // in 关键字指定访问的集合
            // join 用于将来自不同源序列并且在对象模型中没有直接关系的元素相关联
            // on 关键字用于在查询表达式的 join 子句中指定联接条件
            // equals 关键字用于在查询表达式的 join 子句中比较两个序列的元素。equals是object类的需方法
            // into 关键字创建临时标识符，将 group、join 或 select 子句的结果存储至新标识符。
            // let 关键字创建一个新的范围变量并通过提供的表达式结果初始化该变量。
            // where 关键字用于指定将在查询表达式中返回数据源中的哪些元素。
            // orderby 关键字可导致返回的序列或子序列（组）以升序或降序排序。
            // ascending 指定排序顺序为从小到大。此为默认排序
            // descending 指定排序顺序为从大到小。
            // group 关键字返回一个 IGrouping<TKey,TElement> 对象序列，这些对象包含零个或更多与该组的键值匹配的项。对检索的内容进行分组。

            // 1，获取数据源
            List<int> numbers = new List<int>() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            // 2，创建查询
            var numQuery = from num in numbers
                           where num % 2 == 0
                           select num;
            // 3,执行查询
            foreach (var num in numQuery)
            {
                Console.WriteLine("{0,1}", num);
            }

            // 标准查询操作符说明
            // 过滤
            var result0 = numbers.Where(a => a > 3); // 返回给定条件的列表元素
            result0 = from v in numbers where v > 3 select v; // 等价LINQ
            result0 = numbers.OfType<int>(); // 返回指定类型的列表元素
            // 投影
            var result1 = numbers.Select<int, string>(a => a.ToString()); // 将集合中的每个元素投影的新集合中。
            result1 = numbers.SelectMany<int, string>(a => new List<string>()
                {a.ToString()}); // 将序列的每个元素投影到一个序列中，最终把所有的序列合并
        }

        //事件 事件向其他对象提供有关发生的事情（如单击按钮或成功完成某个方法）的通知。 事件是使用委托定义和触发的。
        //event，就相当于委托的“属性”，也就是说，事件就是封装过的委托。
        //- 委托的调用只能在类中进行
        //- 外部只能进行委托的追加/删除
        /*参考解释：事件就是委托的“属性”（事件是封装过的委托实例）
         * 定义事件的委托实例要使用 EventHandler 后缀，即事件处理程序一般以 EventHandler 结尾，且包括 sender 和 e 两个参数
         * 事件用到的参数，名称要带EventArgs后缀
         * (事件数据要继承自 EventArgs)
             */
        delegate void MyEventHandler(object sender, EventArgs args);

        event MyEventHandler OnEvent; //定义事件实例
        private static readonly object objectLocker = new object();

        event MyEventHandler PropertyEvent // 定义事件访问器
        {
            add
            {
                //add 上下文关键字用于定义一个自定义事件访问器，当客户端代码订阅您的事件时将调用该访问器。
                lock (objectLocker) // 自定义类推荐用私有的只读静态对象
                {
                    // lock 关键字将语句块标记为临界区，方法是获取给定对象的互斥锁，执行语句，然后释放该锁。
                    // lock 关键字可确保当一个线程位于代码的临界区时，另一个线程不会进入该临界区。 如果其他线程尝试进入锁定的代码，则它将一直等待（即被阻止），直到该对象被释放。
                    /*
                     * 当某线程执行到代码锁时，lock 会将 objectLocker 锁定，此后访问该区域代码的线程将会挂起等待，直到当前 lock 区域内的代码执行完毕
                     * objectLocker 应当是静态的，也就是说整个程序只有这一个锁，否则不同的锁不会挂起其他线程
                     */
                    OnEvent += value;
                }

                #region 等价代码

                Monitor.Enter(objectLocker);
                try
                {
                    OnEvent += value;
                }
                finally
                {
                    Monitor.Exit(OnEvent);
                }

                #endregion
            }
            remove
            {
                //remove 上下文关键字用于定义一个自定义事件访问器，当客户端代码取消订阅事件时将调用该访问器。
                lock (objectLocker)
                {
                    OnEvent -= value;
                }
            }
        }

        event Action<object, EventArgs> On事件;

        public void 触发事件的函数()
        {
            On事件(this, EventArgs.Empty);
            On事件.Invoke(this, EventArgs.Empty); // 这种触发事件是一个同步执行
        }

        public void 添加事件的函数()
        {
            // 由于在其他类中需要访问 On事件 ，所以其他类需要关联事件所在的类
            On事件 += 当触发事件时要调用的函数1;
        }

        public void 当触发事件时要调用的函数1(object sender, EventArgs e)
        {
            Console.WriteLine("当触发事件时，执行该函数");
        }


        //运算符 重载运算符被视为类成员。 在重载运算符时，在类中将该运算符定义为公共静态方法。 预定义运算符（+、*、< 等）不考虑作为成员。 有关详细信息，请参阅可重载运算符。
        [Obsolete]
        void OperatorMethod<T>()
        {
#if tru
            var _object = new Class();
            var _childObject = new ChildClass();
            int x = 0, y = 0;
            int[] array = new int[] { };
            bool _bool = false;
            //https://msdn.microsoft.com/zh-cn/library/6a71f45d.aspx

            // 以下运算符按最高优先级到最低优先级排列
            // 主要运算符
            _object.field.ToString(); // 成员访问。
            _object?.field.ToString();// null 条件成员访问。 如果左边操作数为 null，则返回 null。
            Method();// 方法和委托调用
            array[x].ToString();// 数组和索引器访问
            array?[x].ToString();// null 条件索引。 如果左边操作数为 null，则返回 null。
            x++;// 后缀递增。 先返回 x 值，然后用加 1（通常加整数 1）后的 x 值更新存储位置。
            x--;// 后缀递减。 先返回 x 值，然后用减 1（通常减整数 1）后的 x 值更新存储位置。
            new Class();// 类型实例化。// 委托实例化
            new Class() { field = 0 };// 具有初始值设定项的对象创建。
            new { member1 = 1, member2 = field }.ToString();// 创建匿名类型
            new Class[x].ToString(); // 创建数组
            typeof(Class).ToString();// 获取 Class 的 System.Type 对象
            checked(x).ToString();// checked 关键字用于对整型算术运算和转换显式启用溢出检查。
            unchecked(x).ToString();// 对整数运算禁用溢出检查。 这是默认的编译器行为。
            default(T).ToString();// 泛型代码中的默认关键字,给定参数化类型 T 的一个变量 t，只有当 T 为引用类型时，语句 t = null 才有效；只有当 T 为数值类型而不是结构时，语句 t = 0 才能正常使用。 解决方案是使用 default 关键字，此关键字对于引用类型会返回 null，对于数值类型会返回零。 对于结构，此关键字将返回初始化为零或 null 的每个结构成员，具体取决于这些结构是值类型还是引用类型。 对于可以为 null 的值类型，默认返回 System.Nullable<T>，它像任何结构一样初始化。
            sizeof(int).ToString(); // 用于获取非托管类型的大小（以字节为单位）。
            nameof(Class).ToString();
            (&_object)->field.ToString();// -> 运算符将指针取消引用与成员访问组合在一起。只能在标记为不安全 unsafe 的代码中使用 -> 运算符。

            // 一元运算符
            (+x).ToString();// 返回 x 值
            (-x).ToString();// 数值求反
            (!_bool).ToString();// 逻辑求反
            (~x).ToString();// 按位求补 // 实际测试（~x==-(x+1)），例如：~9==-10
            ++x;// 前缀递增。 先用加 1（通常加整数 1）后的 x 值更新存储位置，然后返回 x 值。
            --x;// 前缀递减。 先用减 1（通常减整数 1）后的 x 值更新存储位置，然后返回 x 值。
            ((Class1)_object).ToString();//强制转换或类型转换。
            // await // 等待 Task。
            &_object;// 返回操作数的地址 // 只能在标记为不安全 unsafe 的代码中使用
            *(&_object);// 声明指针类型和取消引用指针。 // 只能在标记为不安全 unsafe 的代码中使用

            // 乘法运算符
            (x * y).ToString();//乘法
            (x / y).ToString();// 除法。 如果操作数均为整数，则结果为整数，舍去小数（例如，-7 / 2 is -3）。
            (x % y).ToString();// 取模。 如果操作数均为整数，则返回 x 除以 y 后的余数。 如果 q = x / y 且 r = x % y，则 x = q * y + r。

            // 加法运算符
            (x + y).ToString();// 加法。// 字符串串联、委托组合
            (x - y).ToString();// 减法。// 委托移除

            // 移位运算符
            (x << y).ToString();// 向左移位，右边移出的空位补零。
            (x >> y).ToString();// 向右移位。 如果左操作数是 int 或 long，则左位数补符号位。 如果左操作数是 uint 或 ulong，则左位数补零。

            // 关系和类型测试运算符
            (x < y).ToString();// 小于（如果 x 小于 y，则为 true）。
            (x > y).ToString();// 大于（如果 x 大于 y，则为 true）。
            (x <= y).ToString();// 小于等于。
            (x >= y).ToString();// 大于等于。
            var obj = new object();
            (obj is Class).ToString();// 类型兼容性。检查对象是否与给定类型兼容。 如果求值后的左操作数可以转换为右操作数中指定的类型（静态类型），则返回 true。
            (obj is Class a).ToString();// C#7.1 利用 is 的模式匹配 // 此 is 非彼 is ，这个扩展的 is 其实是 as 和 if 的组合。即它先进行 as 转换再进行 if 判断，判断其结果是否为 null，不等于 null 则执行语句块逻辑
            (_childObject as BassClass).ToString();// 类型转换。可以使用 as 运算符执行转换的某些类型在兼容之间的引用类型或 可以为 null 的类型。 返回左操作数，并将左操作数转换为右操作数中指定的类型（静态类型），若转换失败则返回 null。
            /* 上句等效语句 */
            (_childObject is BassClass ? (BassClass)_childObject : (BassClass)null).ToString();

            // 相等运算符
            (x == y).ToString(); // 相等。 默认情况下，对于 string 以外的引用类型，此运算符返回引用相等（标识测试）。 但是，类型可以重载 ==，因此，如果你想测试标识，最好对 object 使用 ReferenceEquals 方法。
            (x != y).ToString(); // 不相等。 请参阅有关 == 的注释。 如果某个类型重载 ==，则它必须重载 !=。

            // 逻辑、条件和 null 运算符
            (x & y).ToString();// 逻辑 AND 运算符，对于整型，& 计算操作数的逻辑按位“与”。 对于 bool 操作数，& 计算操作数的逻辑“与”；也就是说，当且仅当两个操作数均为 true 时，结果才为 true。
            (x ^ y).ToString();// 逻辑 XOR 运算符，对于整型，^ 将计算操作数的按位“异或”。 对于 bool 操作数，^ 将计算操作数的逻辑“异或”；也就是说，当且仅当只有一个操作数为 true 时，结果才为 true。
            (x | y).ToString();// 逻辑 OR 运算符，对于整型， |计算操作数的按位“或”。 对于 bool 操作数， | 计算操作数的逻辑“或”；也就是说，当且仅当两个操作数均为 false 时，结果才为 false。
            (_bool && _bool).ToString();// 条件 AND 运算符，执行其 bool 操作数的逻辑“与”运算，但仅在必要时才计算第二个操作数。当且仅当两个操作数均为 true 时，结果才为 true。
            (_bool || _bool).ToString();// 条件 OR 运算符，执行其 bool 操作数的逻辑“或”运算，但仅在必要时才计算第二个操作数。当且仅当两个操作数均为 false 时，结果才为 false。
            (_object ?? _object).ToString();// Null 合并运算符，如果此运算符的左操作数不为 null，则此运算符将返回左操作数；否则返回右操作数。
            (_bool ? x : y).ToString();// 条件运算符，如果测试 t 为 true，则求值并返回 x；否则，求值并返回 y。

            // 赋值和 Lambda 运算符
            x = y;// 赋值
            x += y;// 递增。 x 值加 y 值，结果存储在 x 中，并返回新值。
            x -= y;// 递减。 x 值减 y 值，结果存储在 x 中，并返回新值。
            x *= y;// 乘法赋值。 x 值乘以 y 值，结果存储在 x 中，并返回新值。
            x /= y;// 除法赋值。 x 值除以 y 值，结果存储在 x 中，并返回新值。
            x %= y;// 取模赋值。 x 值除以 y 值，余数存储在 x 中，并返回新值。
            x &= y;// AND 赋值。 y 值和 x 值相与，结果存储在 x 中，并返回新值。
            x ^= y;// XOR 赋值。 y 值和 x 值相异或，结果存储在 x 中，并返回新值。
            x |= y;// OR 赋值。 y 值和 x 值相或，结果存储在 x 中，并返回新值。
            x <<= y;// 左移赋值。 将 x 值向左移动 y 位，结果存储在 x 中，并返回新值。
            x >>= y;// 右移赋值。 将 x 值向右移动 y 位，结果存储在 x 中，并返回新值。
            Action<int> _delegate = (int param) => { };// lambda 运算符
#endif
        }

        // 重载运算符，使用 operator 关键字定义静态成员函数，来允许用户定义的类型重载运算符。
        public static int operator +(Class c1, int c2)
        {
            return 666;
        }

        // 声明显式转换， explicit 关键字用于声明必须使用强制转换来调用的用户定义的类型转换运算符。
        public static explicit operator Class1(Class thisValue)
        {
            return new Class1();
        }

        // 声明隐式转换， implicit 关键字用于声明隐式的用户定义类型转换运算符。
        public static implicit operator Class2(Class thisValue)
        {
            return new Class2();
        }

        //索引器 使用索引器可以用类似于数组的方式为对象建立索引。
        public int this[int i]
        {
            /* 索引器概述
             * 使用索引器可以用类似于数组的方式为对象建立索引。
             * get 取值函数返回值。 set 取值函数分配值。
             * this 关键字用于定义索引器。
             * value 关键字用于定义由 set 索引器分配的值。
             * 索引器不必根据整数值进行索引；由你决定如何定义特定的查找机制。
             * 索引器可被重载。
             * 索引器可以有多个形参，例如当访问二维数组时。
             */
            set { genericList[i] = value; }
            get { return genericList[i]; }
        }

        // 迭代器
        public IEnumerable<int> Iterator()
        {
            // 注意点：
            // yield return  迭代器会记录当前位置，下次进入迭代器会从当前位置继续开始
            // 使用 foreach 访问迭代器

            /* yield 关键字向编译器指示它所在的方法、运算符或 get 访问器是迭代器块。
             * yield 关键字用来向 foreach 迭代器返回值。
             * 迭代器的返回类型必须为 IEnumerable 和 IEnumerator 中的任意一种
             * IEnumerable(公开枚举数，该枚举数支持在非泛型集合上进行简单迭代。)
             * IEnumerator(支持对非泛型集合的简单迭代。)
             * 通过 foreach 语句或 LINQ 查询来使用迭代器方法。
             * foreach 循环的每次迭代都会调用迭代器方法。迭代器方法运行到 yield return 语句时，会返回一个 expression（返回值），并保留当前在代码中的位置。 下次调用迭代器函数时，将从该位置重新开始执行。
             * 可以使用 yield break 语句来终止迭代。
             */
            yield return 666;
            yield return 233;
            int result = 2;
            for (int i = 0; i < 20; i++)
            {
                if (i >= 10)
                    yield break;
                yield return result * i;
            }
        }


        //构造函数 构造函数是在第一次创建对象时调用的方法。 它们通常用于初始化对象的数据。
        public Class()
        {
        }

        public Class(int param)
        {
        } //重载构造函数
        //private Class() { }//私有构造函数,通过将构造函数设置为私有构造函数，可以阻止类被实例化

        //析构函数 C# 中极少使用析构函数。 析构函数是当对象即将从内存中移除时由运行时执行引擎调用的方法。 它们通常用来确保任何必须释放的资源都得到适当的处理。
        ~Class()
        {
        }
    }

    //部分类
    partial class PartialClass
    {
    }

    partial class PartialClass
    {
        /*partial 关键字，分部类型定义允许将类、结构或接口的定义拆分到多个文件中。*/
    }

    //静态类
    static class StaticClass
    {
        /*静态类的主要特性：
         * 仅包含静态成员。
         * 无法实例化。
         * 是密封的。不可被继承
         * 不能包含实例构造函数。
         */

        //静态构造函数
        static StaticClass()
        {
        }

        //扩展方法
        public static int ExtendedMethod(this string strParam)
        {
            //扩展方法使你能够向现有类型“添加”方法，而无需创建新的派生类型、重新编译或以其他方式修改原始类型。
            return Convert.ToInt32(strParam);
        }
    }

    //泛型类
    class Generic<T>
    {
        /*泛型概述
         * 使用泛型类型可以最大限度地重用代码、保护类型的安全以及提高性能。
         * 泛型最常见的用途是创建集合类。
         * .NET Framework 类库在 System.Collections.Generic 命名空间中包含几个新的泛型集合类。 应尽可能地使用这些类来代替普通的类，如 System.Collections 命名空间中的 ArrayList。
         * 您可以创建自己的泛型接口、泛型类、泛型方法、泛型事件和泛型委托。
         * 可以对泛型类进行约束以访问特定数据类型的方法。
         * 关于泛型数据类型中使用的类型的信息可在运行时通过使用反射获取。
         */

        T genericField; //字段

        List<T> genericArrayList; //list数组

        //泛型接口
        interface IGenericInterface<TGenericInterfaceParam>
        {
        }

        //泛型方法
        void GenericMethod<TGenericMethodParam>(TGenericMethodParam param)
        {
        }

        //泛型委托
        delegate void GenericDelegateEventHandler<TGenericDelegateParam>(TGenericDelegateParam param);

        class GenericSub<T1, T2> : Class // 泛型类的继承
            // 在泛型类型定义中，where 子句用于指定对下列类型的约束：这些类型可用作泛型声明中定义的类型参数的实参。
            where T1 : List<int>
            where T2 : Class, IInterface // 可以对参数类型进行类或接口的约束
                                         //.NET支持的类型参数约束有以下五种：
                                         //where T : struct              | T必须是一个结构类型
                                         //where T : class               | T必须是一个Class类型
                                         //where T : new()               | T必须要有一个无参构造函数
                                         //where T : NameOfBaseClass     | T必须继承名为NameOfBaseClass的类
                                         //where T : NameOfInterface     | T必须实现名为NameOfInterface的接口
        {
        }
    }

    class Generic<T1, T2>
    {
    } //多参数泛型

    //结构
    // 尽量避免写到结构体。将它们视为不可变的，能够防止混淆的发生，并且在共享内存的场景（如多线程应用程序）下更安全。相反，在创建结构体时使用初始化对象，如果需要更改值，则创建新的实例。
    struct Struct
    {
        //在结构声明中，除非字段被声明为 const 或 static，否则无法初始化。
        //结构不能声明默认构造函数（没有参数的构造函数）或析构函数。
        //结构在赋值时进行复制。 将结构赋值给新变量时，将复制所有数据，并且对新副本所做的任何修改不会更改原始副本的数据。 在使用值类型的集合（如 Dictionary<string, myStruct>）时，请务必记住这一点。
        //结构是值类型，而类是引用类型。
        //与类不同，结构的实例化可以不使用 new 运算符。
        //结构可以声明带参数的构造函数。
        //一个结构不能从另一个结构或类继承，而且不能作为一个类的基。 所有结构都直接继承自 System.ValueType，后者继承自 System.Object。
        //结构可以实现接口。
        //结构可用作可以为 null 的类型，因而可向其赋 null 值。
    }

    //接口
    interface IInterface
    {
        /*接口具有以下属性：
         * 接口类似于抽象基类。 实现接口的任何类或结构都必须实现其所有成员。
         * 接口无法直接进行实例化。 其成员由实现接口的任何类或结构来实现。
         * 接口可以包含事件、索引器、方法和属性。
         * 接口不包含方法的实现。
         * 一个类或结构可以实现多个接口。 一个类可以继承一个基类，还可实现一个或多个接口。
         */
        //接口方法
        void InterfaceMethod();

        //接口属性
        int InterfaceProperties { get; set; }

        //接口索引器
        int this[int i] { get; set; }

        //接口事件
        event MyDelegateEventHandler InterfaceEventHandler;
    }

    //委托
    /* 委托名称采用 Pascal 规则。
     * 委托名称添加 CallBack 后缀？
     * 委托事件名称添加 EventHandler 后缀？ 添加 Object sender 和 EventArgs e 参数？
     * 不要向委托添加 Delegate 后缀。
     *
     * 委托方法添加 CallBack 后缀？
     *
     * 事件添加 EventHandler 后缀？
     * 事件访问器添加 EventHandler 后缀？
     * 事件处理程序添加 EventHandler 后缀？事件处理程序添加 Object sender 和 EventArgs e 参数？
     */
    delegate void MyDelegateCallBack();

    delegate void GenericDelegateCallBack<T>(T param);

    delegate void MyDelegateEventHandler(object sender, EventArgs e); // 规范

    //枚举
    [Flags] // 标记枚举
    enum Enum : int
    {
        // 枚举名使用Pascal规则命名，由于枚举成员本质属于常量，原则上使用大写。
        SUNDAY = 0
    }

    //特性
    [System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class AttributeClass : Attribute
    {
        /*特性具有以下属性：
         * 特性可向程序中添加元数据。元数据是有关在程序中定义的类型的信息。所有的 .NET 程序集都包含指定的一组元数据，这些元数据描述在程序集中定义的类型和类型成员。可以添加自定义特性，以指定所需的任何附加信息。
         * 可以将一个或多个特性应用到整个程序集、模块或较小的程序元素（如类和属性）。
         * 特性可以与方法和属性相同的方式接受参数。
         * 程序可以使用反射检查自己的元数据或其他程序内的元数据。
         *
         *
         * 特性的指定方法为：将括在方括号中的特性名置于其应用到的实体的声明上方。
         */

        // 标记为弃用的
        [Obsolete]
        public void ObsoleteFunction()
        {
        }

        // 如果没有预定义 MyDefine，则忽略代码中这个方法的所有调用
        [Conditional("MyDefine")]
        public void ConditionalFunction()
        {
            // 相当于#if，区别是
            // #if是根据本程序集是否有配置相应宏定义来判断是否执行。
            // Conditional 根据函数调用方的环境来选择是否执行
#if MyDefine
            // 代码块
#endif
        }

        // 可序列化类
        [Serializable]
        class SerializableClass
        {
            // 不可序列化字段
            [NonSerialized] public int var;
        }

        public void UseAttributes()
        {
            // 使用IsDefined方法检查是否拥有特性
            var result = typeof(AttributeClass).IsDefined(typeof(ObsoleteAttribute), true);
            result = typeof(AttributeClass).GetMethod("ObsoleteFunction").IsDefined(typeof(ObsoleteAttribute), true);
            var allAttributes = typeof(AttributeClass).GetCustomAttributes(false);
            foreach (var attribute in allAttributes)
            {
                result = attribute is ObsoleteAttribute;
            }
        }
    }

    // 动态类型
    class DynamicClass
    {
        // 动态字段
        dynamic _dynamicField;

        // 动态属性
        dynamic dynamicPropetry
        {
            get { return _dynamicField; }
            set { _dynamicField = value; }
        }

        // 动态索引器
        dynamic this[int i]
        {
            get { return _dynamicField; }
        }

        //动态委托
        delegate dynamic dynamicEventHandler();

        // 动态方法
        public virtual dynamic dynamicMethod(dynamic parame) // 动态参数
        {
            _dynamicField = 666 as dynamic;
            return parame;
        }


        // 表示可在运行时动态添加和删除其成员的对象。
        System.Dynamic.ExpandoObject expandoObject = new System.Dynamic.ExpandoObject();

        class DynamicObjectClass :
            System.Dynamic.DynamicObject // 提供用于在运行时指定动态行为的基类。 必须继承此类；不能直接对其进行实例化。
        {
        }
    }

    class ChildDynamicClass : DynamicClass
    {
        public override dynamic dynamicMethod(dynamic parame)
        {
            return base.dynamicMethod((object)parame);
        }
    }

    /*=================================================================================================
    类的继承关系*/
    //抽象类
    abstract class AbstractClass
    {
        /* 使用 abstract 关键字可以创建不完整且必须在派生类中实现的类和类成员。
         * 抽象类不能实例化。 抽象类的用途是提供一个可供多个派生类共享的通用基类定义。
         * 例如，类库可以定义一个抽象类，将其用作多个类库函数的参数，并要求使用该库的程序员通过创建派生类来提供自己的类实现。
         */
        //抽象方法
        public abstract void AbstractFunction();

        public static AbstractClass Creat()
        {
            return new BassClass();
        }
    }

    //父类（基类）
    class BassClass : AbstractClass
    {
        public override string ToString()
        {
            return base.ToString();
        }

        //访问修饰符
        // 内部访问 // 默认访问级别，只有在同一程序集的文件中，内部类型或成员才是可访问的
        internal int internalField; // 作用域：当前程序集

        // 公共访问 // 公共访问是允许的最高访问级别。同一程序集中的任何其他代码或引用该程序集的其他程序集都可以访问该类型或成员。
        public int PublicField; // 作用域：始终可被访问（不考虑跨线程问题）

        //私有访问 // 私有访问是允许的最低访问级别。 只有同一类或结构中的代码可以访问该类型或成员。
        private int _privateField; // 作用域：当前类

        // 受保护访问 // 只有同一类或结构或者此类的派生类中的代码才可以访问的类型或成员。
        protected int protectedField; // 作用域：被继承的类（包括其他程序集中被继承的类）（只能在子类自己的作用范围内访问自己继承的那个父类protected）

        // 内部且对外受保护访问 // 由其声明的程序集或另一个程序集派生的类中任何代码都可访问的类型或成员。 从另一个程序集进行访问必须在类声明中发生，该类声明派生自其中声明受保护的内部元素的类，并且必须通过派生的类类型的实例发生。
        protected internal int protectedInternalField; // 作用域：当前程序集、其他程序集中被继承的类

        //public Form a = new Form();

        public void MyTestMethod()
        {
        }

        // 抽象类的派生类必须实现所有抽象方法。
        public override void AbstractFunction()
        {
        }

        //方法
        protected void Function()
        {
        }

        //虚方法，virtual 关键字用于修饰方法、属性、索引器或事件声明，并使它们可以在派生类中被重写。
        protected virtual void AirtualFunction()
        {
        }

        // 构造函数
        public BassClass()
        {
        }

        public BassClass(int param)
        {
        }
    }

    //子类（派生类）
    class ChildClass : BassClass, IInterface /*继承接口*/
    {
        //实现接口成员
        /*
         * 若从多个接口中继承了同名成员，则用 . 符号来访问每个接口的成员
         */
        public void InterfaceMethod()
        {
        }

        public int InterfaceProperties
        {
            get { return 0; }
            set { }
        }

        public int this[int i]
        {
            get { return 0; }
            set { }
        }

        public event MyDelegateEventHandler InterfaceEventHandler;

        // 隐藏与重写的区别：当派生类转为基类对象后，调用隐藏成员将会调用基类成员，而调用重写成员会调用派生类成员。
        //隐藏 //隐藏从基类继承的成员，new 关键字可以保留生成输出的关系，但它将取消警告。
        protected new void Function()
        {
            base.Function();
        }

        //重写，override 关键字
        protected override void AirtualFunction()
        {
            base.AirtualFunction();
        }

        // 继承构造函数
        public ChildClass() : base()
        {
        }

        public ChildClass(int param) : base(param)
        {
            /*
             * 会先调用基类构造函数再调用派生类构造函数
             * 派生类的构造函数默认添加 : base()
             * 改变base() 中的参数可以选择继承的构造函数
             */
        }
    }

    //密封类，不可被继承的子类
    sealed class SealedChildClass : ChildClass
    {
        //在类成员声明中将 sealed 关键字置于 override 关键字的前面,用于以后的派生类时，这将取消成员的虚效果（不能再被重写）。
        protected sealed override void AirtualFunction()
        {
        }
    }
}

namespace Namespace
{
    class Class1
    {
    }

    class Class2
    {
    }

    /// <summary>
    /// 自定义错误
    /// </summary>
    [Serializable]
    public class MyException : Exception // 规范:向从System.Exception继承的类型添加 Exception 后缀。
    {
        public MyException()
        {
        }

        public MyException(string message) : base(message)
        {
        }

        public MyException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MyException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }
    }
}

// 难点突破
namespace Namespace.NestedNamespace
{
    // 数据类型、值传递与引用传递、浅拷贝与深拷贝
    class ValueAndQuote
    {
        /// <summary>
        /// 数据类型
        /// </summary>
        class Type
        {
            // 值类型
            /* 值类型的变量直接包含其数据。
             * 值类型是从类 System.ValueType 派生的，包括布尔型、整型、浮点型、高精度型、枚举和结构
             * 对于值类型，每个变量都具有其自己的数据副本，对一个变量执行的操作不会影响另一个变量（ref 和 out 参数变量除外）。
             * 当使用值类型时，使用的就是值本身。
             * 值类型不可为 null。但可以将其用 可以为 null 的类型：Nullable<T>。
             * 隐式转换 byte → short → int → long → float → double
             * */
            /* 布尔型 */
            bool _bool = false;

            /* 整形表 */
            sbyte _sbyte = SByte.MinValue; // 有符号 8 位整数
            byte _byte = Byte.MinValue; // 无符号 8 位整数，字节
            char _char = Char.MinValue; // 16 位 Unicode 字符
            short _short = Int16.MinValue; // 有符号 16 位整数
            ushort _ushort = UInt16.MinValue; // 无符号 16 位整数
            int _int = Int32.MinValue; // 有符号 32 位整数
            uint _uint = UInt32.MinValue; // 无符号 32 位整数 // 类型后缀:U 或 u
            long _long = Int64.MinValue; // 有符号 64 位整数 // 类型后缀:L 或 l

            ulong _ulong = UInt64.MinValue; // 无符号 64 位整数 // 类型后缀:UL 或 ul

            /* 浮点型表 */
            float _float = Single.MinValue; // 32 位浮点值 // 类型后缀:F 或 f

            double _double = Double.MinValue; // 64 位浮点值 // 类型后缀:D 或 d

            /*
            * 将一个float型转化为内存存储格式的步骤为：
            （1）先将这个实数的绝对值化为二进制格式。 
            （2）将这个二进制格式实数的小数点左移或右移n位，直到小数点移动到第一个有效数字的右边。 
            （3）从小数点右边第一位开始数出二十三位数字放入第22到第0位。 
            （4）如果实数是正的，则在第31位放入“0”，否则放入“1”。 
            （5）如果n 是左移得到的，说明指数是正的，第30位放入“1”。如果n是右移得到的或n=0，则第30位放入“0”。 
            （6）如果n是左移得到的，则将n减去1后化为二进制，并在左边加“0”补足七位，放入第29到第23位。如果n是右移得到的或n=0，则将n化为二进制后在左边加“0”补足七位，再各位求反，再放入第29到第23位。
            * 
            * 将一个内存存储的float二进制格式转化为十进制的步骤： 
            （1）将第22位到第0位的二进制数写出来，在最左边补一位“1”，得到二十四位有效数字。将小数点点在最左边那个“1”的右边。 
            （2）取出第29到第23位所表示的值n。当30位是“0”时将n各位求反。当30位是“1”时将n增1。 
            （3）将小数点左移n位（当30位是“0”时）或右移n位（当30位是“1”时），得到一个二进制表示的实数。 
            （4）将这个二进制实数化为十进制，并根据第31位是“0”还是“1”加上正号或负号即可。
            */
            /* 高精度型 */
            decimal _decimal = Decimal.MinValue; // 128 位数据类型 // 类型后缀:M 或 m

            /* 其它值类型 */
            Enum _enum = new Enum(); // 枚举

            Struct _struct = new Struct(); // 结构

            // 声明为可以为 null 的类型
            Struct? _structNull = new Struct(); // 可以为 null 的类型：Nullable<T>

            // 引用类型
            /* 引用类型的变量存储对其数据（对象）的引用。实际上指的是一个内存地址。
             * 所有类型派生自终极基类 Object ，包括 类、接口、委托、Object、String（字串符常量）与动态类型
             * 对于引用类型，两个变量可引用同一对象。因此，对一个变量执行的操作会影响另一个变量所引用的对象。
             * 当使用引用类型时，实际上是使用指向该对象的指针，而不是对象本身。
             */
            // class、interface、delegate 可以声明引用类型
            public class MyClass
            {
                public int Field = 0;

                public MyClass(int param)
                {
                    Field = param;
                }
            }

            MyClass _myClass = new MyClass(0);

            interface IInterface
            {
            }

            delegate void MyDelegate();

            /* 内置引用类型 */
            object _object = new Object();
            string _string = string.Empty; // 由于 string 是不可改变的常量，所以传值时会新建一份副本

            dynamic _dynamic = new System.Dynamic.ExpandoObject(); // dynamic 关键字是类型 System.Dynamic.DynamicObject 的简化
            /* object* _intPtr; // 指针*/

            /// <summary>
            /// 堆(Heap)栈(Stack)详解
            /// </summary>
            class HeapAndStack
            {
                /*
                 * .Net Framework 在执行代码时，有两个用来存储对象的地方，也就是堆和栈，用于帮助执行我们的代码。它们驻留在机器内存中，包含了所有我们需要实现的信息。
                 * 栈(Stack)
                 *     栈用来负责跟踪代码里正在执行什么，或者说代码里的什么东东被called。
                 *     栈具有一个特性： 最后一个放入栈中的物体总是被最先拿出来， 这个特性通常称为后进先出(LIFO)队列。
                 *     栈由操作系统自动分配释放 ，存放函数的参数值，局部变量的值等。
                 *     栈的两个最重要的操作是Push（压入）和POP（移除）。
                 *     栈使用的是一级缓存， 他们通常都是被调用时处于存储空间中，调用完毕立即释放。
                 *     在递归程序中，每一层次递归都必须在调用栈上增加一条地址，因此如果程序出现无限递归（或仅仅是过多的递归层次），调用栈就会产生栈溢出。
                 * 堆(Heap)
                 *     堆用来跟踪对象，或者数据。
                 *     堆里面的任何东西都不受限制的随便访问。
                 *     堆一般由GC（C#）或程序员分配释放， 若程序员不释放，程序结束时可能由OS回收，分配方式类似于链表。
                 *     堆存放在二级缓存中，生命周期由虚拟机的垃圾回收算法来决定（并不是一旦成为孤儿对象就能被回收）。所以调用这些对象的速度要相对来得低一些。
                 *
                 * 当代码执行时，堆栈里头主要放置四种类型：值类型，引用类型，指针(Pointers)，以及指令(Instructions)。
                 *     指针就是对一个类型的引用。指针不同于引用类型。当我们说某某是引用类型时，实际上就意味着我们要通过指针去访问这个类型的值。
                 *     一个指针占用内存中的一块空间，指向内存中另外一块空间。指针跟任何别的放在堆栈中的东西一样，是要占用物理空间的。它的值要么是null，要么就是内存地址。
                 *     栈顶分配空间用来存储方法所包含的信息，这部分空间叫做栈框（stack frame）。
                 *     方法的参数被完全复制。
                 *     控制权交给JIT编译好的方法指令集，开始真正的执行代码。
                 *
                 * 存放法则
                 *     引用类型总是保存在堆里头
                 *     值类型以及指针，总是保存在其被声明(Declared)的地方。
                 */
                class MyClass
                {
                    public int Value;
                }

                // 一般方法在堆栈中的存储
                int Program(int param, int[] arrParam, ref int[] refParam) // 栈顶指针 return | Pointer = 当前位置（栈）
                                                                           // 方法 program(int) 压栈
                                                                           // 参数 param | int = 0(默认值)压栈
                                                                           // 参数 arrParam | Pointer = (arrParam的实参)保存的地址（指向堆中一个 int[]） 压栈
                                                                           // 参数 refParam | Pointer = &(refParam的实参)（形参指向实参） 压栈
                {
                    int j = 233; // 局部变量 j | int = 233 压栈
                    MyClass obj; // 局部指针 obj | Pointer = Null（默认值） 压栈
                    obj = new MyClass(); // 堆中创建对象 MyClass() // obj | Pointer = &MyClass()
                    param = param + j; // 方法仅涉及栈中的值
                    obj.Value = j + 433; // 方法通过指针从堆中取出 MyClass().Value 并赋值 j + 433
                    arrParam[0] = 123; // 方法通过指针从堆中取出对象 int[]（同时被arrParam的实参指向） 并赋值 123
                    arrParam = new int[2]; // 在堆中创建对象 int[2] 并将该对象地址赋值到 arrParam | Pointer （实参指向的地址依旧没变）
                    refParam =
                        new int[6]; // 在堆中创建对象 int[6] 并将该对象地址赋值到 refParam | Pointer 所指向的 (refParam的实参) | Pointer （实参地址已改变）
                    return param; // 方法结束，返回 param 的值至栈顶指针 return | Pointer （方法 program(int) 开始的地方）
                    // obj | Pointer 出栈   // 堆中保留了没有被引用的对象 MyClass() ，等待GC处理回收
                    // j | int 出栈
                    // refParam | Pointer 出栈（堆中保留了仍被 (refParam的实参) | Pointer 引用的对象 int[6]）
                    // arrParam | Pointer 出栈 //堆中保留了没有被引用的对象 int[2] ，等待GC处理回收（堆中保留了仍被 (arrParam的实参) | Pointer 引用的对象 int[]）
                    // param | int 出栈
                    // program(int) 出栈
                } // return | Pointer 出栈

                // 栈继续执行下一个方法
            }
        }

        /// <summary>
        /// 赋值与传参
        /// </summary>
        class AssignmentAndTransfer
        {
            // 变量赋值
            /*个人理解：可以把变量标识符看成一个指针，它存储的就是一个地址，指向一个内存中的一块分配的空间
            * 如果变量是值类型，那么它所存储的就是数据（或者说变量地址等价于）
            * 如果变量是引用类型，那么它存储的是对象的地址
            *
            * 值变量赋值：
            * 变量（数据）地址不变，拷贝值给变量。
            * 引用变量赋值：
            * 变量地址不变，拷贝对象地址给变量，修改新变量数据（不改变对象地址）会影响原变量，重新赋值新变量（改变对象地址）不会影响原变量
            */
            public void Function()
            {
                unsafe
                {
                    // 值变量赋值
                    int a = 666;
                    int b = a; // 新变量b与原变量a有不同的地址（数据地址）
                    Console.WriteLine("a = " + a + "  b = " + b);
                    Console.WriteLine("a的地址为：X0" + ((int)&a).ToString("x"));
                    Console.WriteLine("b的地址为：X0" + ((int)&b).ToString("x") + Environment.NewLine);
                    b = 233; // 修改新变量b不会影响原变量a
                    Console.WriteLine("a = " + a + "  b = " + b);
                    Console.WriteLine("a的地址为：X0" + ((int)&a).ToString("x"));
                    Console.WriteLine("b的地址为：X0" + ((int)&b).ToString("x") + Environment.NewLine);

                    // 值传递值变量
                    method(a, b);

                    void method(int x, int y)
                    {
                        // 值变量形参的地址（数据地址）与实参不同
                        Console.WriteLine("x的地址为：X0" + ((int)&x).ToString("x"));
                        Console.WriteLine("y的地址为：X0" + ((int)&y).ToString("x") + Environment.NewLine);
                        x = x + y; // 修改值变量形参不会影响实参
                    }

                    // 引用变量赋值
                    int[] arrA = new int[] { 1, 2, 3 };
                    int[] arrB = arrA; // 新变量b与原变量a有不同的“变量地址（个人理解）”，但它们有相同的对象地址（C#中不可查看），即b与a指向同一个对象
                    Console.WriteLine($"arrA = {arrA[0]},{arrA[1]},{arrA[2]}  arrB = {arrB[0]},{arrB[1]},{arrB[2]}");
                    arrB[0] = 233; // 修改新变量b会影响原变量a
                    Console.WriteLine($"arrA = {arrA[0]},{arrA[1]},{arrA[2]}  arrB = {arrB[0]},{arrB[1]},{arrB[2]}" +
                                      Environment.NewLine);

                    // 值传递引用变量
                    Console.WriteLine($"实参 = {arrA[0]},{arrA[1]},{arrA[2]}");
                    methodObject(arrA);

                    void methodObject(int[] x)
                    {
                        // 形参与实参有不同的“变量地址（个人理解）”，但它们有相同的对象地址（C#中不可查看），即形参与实参指向同一个对象
                        x[0] = 666; // 修改（不改变对象地址）形参会影响实参
                        Console.WriteLine($"实参 = {arrA[0]},{arrA[1]},{arrA[2]}  形参 = {x[0]},{x[1]},{x[2]}");
                        x = new int[] { 7, 8, 9, 10 }; // 赋值（改变对象地址）形参不会影响实参
                        Console.WriteLine($"实参 = {arrA[0]},{arrA[1]},{arrA[2]}  形参 = {x[0]},{x[1]},{x[2]}" +
                                          Environment.NewLine);
                    }
                }
            }

            // 传递参数详解
            /* 在C#中，传递参数有值传递、引用传递两种。
             * 而值传递实际上就是值传递值变量、值传递引用变量，引用传递就是显示引用传递（ref、out）
             *
             * 值传递值类型时与值变量赋值一样，新建并赋值一个值类型形参，修改、赋值形参不会影响实参
             * 值传递引用类型时与引用变量赋值一样，新建并赋值一个引用类型形参，形参与实参拥有相同的对象地址，修改形参的数据（不改变对象地址）时会影响实参，但赋值（改变对象地址）形参不会影响实参
             * ref、out引用传递时，实参等价于形参，形参相当于是一个指向实参的指针
             * ref 有出有进
             * out 有出无进
             * */
            public void Program()
            {
                unsafe
                {
                    // 值传递值变量
                    int a = 233;
                    Console.WriteLine("实参 = " + a);
                    method(a);

                    void method(int x)
                    {
                        // 值变量形参的地址（数据地址）与实参不同
                        Console.WriteLine("x的地址为：X0" + ((int)&x).ToString("x"));
                        x = 666; // 修改值变量形参不会影响实参
                        Console.WriteLine("实参 = " + a + "  形参 = " + x);
                    }

                    // 值传递引用变量
                    int[] arrA = new int[] { 1, 2, 3 };
                    Console.WriteLine($"实参 = {arrA[0]},{arrA[1]},{arrA[2]}");
                    methodObject(arrA);

                    void methodObject(int[] x)
                    {
                        // 形参与实参有不同的“变量地址（个人理解）”，但它们有相同的对象地址（C#中不可查看），即形参与实参指向同一个对象
                        x[0] = 666; // 修改（不改变对象地址）形参会影响实参
                        Console.WriteLine($"实参 = {arrA[0]},{arrA[1]},{arrA[2]}  形参 = {x[0]},{x[1]},{x[2]}");
                        x = new int[] { 7, 8, 9, 10 }; // 赋值（改变对象地址）形参不会影响实参
                        Console.WriteLine($"实参 = {arrA[0]},{arrA[1]},{arrA[2]}  形参 = {x[0]},{x[1]},{x[2]}" +
                                          Environment.NewLine);
                    }

                    // 显示引用传递
                    displayMetohd(ref a, ref arrA);

                    void displayMetohd(ref int x, ref int[] y)
                    {
                        // 形参的任何修改都会影响实参，形参等价于实参
                        x = 666;
                        y = new int[] { 7, 8, 9, 10 };
                    }
                }
            }
        }


        /// <summary>
        /// 浅拷贝与深拷贝
        /// </summary>
        class CopyAndDeepCopy
        {
            /*
             * 在深层副本中，所有的对象都是重复的；
             * 而在浅表副本中，只有顶级对象是重复的，并且顶级以下的对象包含引用。
             * 深拷贝和浅拷贝之间的区别在于是否复制了子对象。
             */
            class MyClass
            {
                public int a;
                public int[] array;
                public List<SubClass> ObjectList = new List<SubClass>();

                public class SubClass
                {
                    int[] _subArray = new int[] { 1, 2, 3 };
                }

                /// <summary>
                /// 对象的浅拷贝
                /// </summary>
                /// <returns></returns>
                public new MyClass MemberwiseClone()
                {
                    return this.MemberwiseClone();
                }


                public MyClass(MyClass obj) => this.MemberwiseClone();

                public MyClass()
                {
                }
            }

            /// <summary>
            /// （例）利用 MemberwiseClone 方法浅拷贝
            /// </summary>
            void Method()
            {
                //MemberwiseClone 方法创建一个浅表副本，方法是创建一个新对象，然后将当前对象的非静态字段复制到该新对象。如果字段是值类型的，则对该字段执行逐位复制。如果字段是引用 类型，则复制引用但不复制引用的对象；因此，原始对象及其复本引用同一对象。
                MyClass a = new MyClass();
                a.MemberwiseClone(); // 在类中重写MemberwiseClone方法实现浅拷贝
                MyClass b = new MyClass(a); // 利用构造函数创建浅拷贝副本
                b = DeepCopy<MyClass>(b); // 深拷贝
            }

            /// <summary>
            /// 利用二进制序列化实现深拷贝（通用、低效）
            /// </summary>
            /// <typeparam name="T">对象类型</typeparam>
            /// <param name="obj">对象</param>
            /// <returns></returns>
            public static T DeepCopy<T>(T obj) where T : class
            {
                try
                {
                    using (Stream tempStream = new MemoryStream())
                    {
                        BinaryFormatter serialize = new BinaryFormatter();
                        serialize.Serialize(tempStream, obj);
                        tempStream.Position = 0;
                        //tempStream.Seek(0, SeekOrigin.Begin);
                        T temp = serialize.Deserialize(tempStream) as T;
                        return temp;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }

    // 委托与事件
    class DelegateSimple
    {
        public class Sample
        {
            //※委托声明
            public delegate void TestDelegateCallBack();

            public delegate bool TestDelegate2CallBack(int param);

            /// <summary>
            /// 委托命令
            /// </summary>
            public class DelegateOrder
            {
                //※定义委托实例
                TestDelegateCallBack TestDelegate = null;

                public void Program()
                {
                    //※添加静态委托
                    TestDelegate += RealMethod.FunctionCallBack1;
                    // 添加实例委托
                    TestDelegate += new RealMethod().ObjectCallBack;
                    //链式委托
                    TestDelegate += RealMethod.FunctionCallBack1;
                    TestDelegate += RealMethod.FunctionCallBack2;
                    //获取所有委托方法
                    List<Delegate> Delegates = new List<Delegate>(TestDelegate.GetInvocationList());
                    //遍历链式委托并返回每个委托的值
                    foreach (Delegate del in Delegates)
                    {
                        del.DynamicInvoke();
                    }

                    //※同步，在当前线程调用方法
                    TestDelegate(); //这里将调用 FunctionCallBack1 和 FunctionCallBack2
                    TestDelegate.Invoke(); //Invoke与上句指令等效

                    //※异步
                    TestDelegate = null;
                    TestDelegate += RealMethod.FunctionCallBack2; //※异步只允许有一个方法
                    TestDelegate.BeginInvoke(null, null); //异步，线程异步地执行委托所指向的方法

                    //使用EndInvoke方法来获得返回值
                    TestDelegate2CallBack TestDelegate2 = new TestDelegate2CallBack(RealMethod.FunctionCallBack3);
                    IAsyncResult Result = TestDelegate2.BeginInvoke(666, null, null); //异步线程状态
                    //在异步调用未执行完成之前，EndInvoke将会阻塞进程
                    Console.WriteLine(TestDelegate2.EndInvoke(Result).ToString());
                    ;
                }
            }

            /// <summary>
            /// 实际调用的方法
            /// </summary>
            public class RealMethod
            {
                public void ObjectCallBack()
                {
                    Console.WriteLine("实例化对象方法被调用");
                }

                public static void FunctionCallBack1()
                {
                    Console.WriteLine("FunctionCallBack1被调用");
                }

                public static void FunctionCallBack2()
                {
                    Console.WriteLine("FunctionCallBack2被调用");
                }

                public static bool FunctionCallBack3(int param)
                {
                    Console.WriteLine("FunctionCallBack3被调用 param=:" + param);
                    return true;
                }
            }
        }

        // 委托与事件的区别
        /*
         * 参考解释：事件是封装过的委托实例
         * 实际应用时，事件只能在声明事件的作用域中调用，委托可以在所有类中调用
         */
        public class DelegateAndEvent
        {
            // 声明委托
            public delegate void MyDelegateCallBack();

            public delegate void MyDelegateEventHandle(object sender, EventArgs e);

            public class DelegateOrder
            {
                /*
                 * 事件用来封装委托，事件只可以被当前类作用域调用。也就是说事件不能被直接调用,只能通过某些操作触发。
                 * 事件访问器用来封装事件
                 * 事件访问器主要用来控制访问事件的对象不会被同时调用？
                 */
                // 定义委托实例
                public MyDelegateCallBack MyCallback = null;

                // 定义事件
                public event MyDelegateEventHandle MyEventHandle;

                // 定义事件访问器
                private object objectLock = new object(); // 检测锁

                public event MyDelegateEventHandle PropertyEventHandle
                {
                    add
                    {
                        lock (objectLock)
                        {
                            /*
                             * 当某线程执行到代码锁时，lock 会将 objectLock 锁定，此后访问该区域代码的线程将会挂起等待，直到当前 lock 区域内的代码执行完毕
                             */
                            // value(); // value 相当于客户程序调用+=时传递过来的delegate
                            MyEventHandle += value;
                        }
                    }
                    remove
                    {
                        lock (objectLock)
                        {
                            MyEventHandle -= value;
                        }
                    }
                }

                // 内部委托方法
                public void MethodCallBack()
                {
                    Console.WriteLine("内部MethodCallBack被调用");
                }

                // 内部事件
                public void MethodEventHandle(object sender, EventArgs e)
                {
                    Console.WriteLine("内部MethodEventHandle被调用");
                }

                // 调用事件
                public void CallEvent()
                {
                    MyCallback();
                    this.MyEventHandle(this, EventArgs.Empty); // 事件只能由内部调用
                    // this.PropertyEventHandle(); // 编译错误，事件访问器不能被调用
                    this.PropertyEventHandle += MyEventHandle; // 添加事件
                    this.PropertyEventHandle -= MyEventHandle; // 移除事件
                }

                public void Program()
                {
                    MyCallback += MethodCallBack;
                    MyCallback();

                    MyEventHandle += MethodEventHandle;
                    this.MyEventHandle(this, EventArgs.Empty);

                    this.PropertyEventHandle += MethodEventHandle;
                    // this.PropertyEventHandle(this, EventArgs.Empty);// 编译错误，事件访问器不能被调用
                }
            }

            public class ProgramClass
            {
                // 外部方法
                public static void FunctionCallBack()
                {
                    Console.WriteLine("外部FunctionCallBack被调用");
                }

                // 外部事件方法
                public static void FunctionEventHandle(object sender, EventArgs e)
                {
                    Console.WriteLine("外部FunctionEventHandle被调用");
                }

                void Main()
                {
                    var test = new DelegateOrder();

                    // 委托可以在外部被调用
                    test.MyCallback += FunctionCallBack;
                    test.MyCallback();

                    // 由于事件的封装性，只能在声明事件的类中调用，而外部可以添加方法（相当于 private 但可以在外部添加事件处理程序）
                    test.MyEventHandle += FunctionEventHandle;
                    // test.MyEventHandle(this, EventArgs.Empty); // 编译错误，事件只能由当前类中触发

                    // 事件访问器 // 事件访问器相当于事件的“属性”。在外部只能添加或移除事件
                    test.PropertyEventHandle += FunctionEventHandle;
                    // test.PropertyEventHandle(this, EventArgs.Empty); // 编译错误，事件访问器不能被调用
                }
            }
        }
    }
}


#if true
namespace 范例
{
    class 范例
    {
        int Program()
        {
            // 该功能尚未实现错误
            throw new NotImplementedException();
        }
    }

    public class 事件的使用
    {
        // 时刻表示格式
        const string FULL = "yyyy/dd/MM hh:mm:ss\n";
        const string DATE = "yyyy/dd/MM\n";
        const string TIME = "hh:mm:ss\n";

        static bool isSuspended = true; // 程序暂停flag
        static string timeFormat = TIME; // 时刻表示格式

        static void Main()
        {
            WriteHelp();
            var cts = new CancellationTokenSource();
            Task.WhenAll(Task.Run(() => EventLoop(cts)),
                TimerLoop(cts.Token)).Wait();
        }

        // 每秒时刻表示循环
        static async Task TimerLoop(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                if (!isSuspended)
                {
                    // 每隔一秒输出现在时刻
                    Console.Write(DateTime.Now.ToString(timeFormat));
                }

                await Task.Delay(1000);
            }
        }

        // 按键事件循环
        static void EventLoop(CancellationTokenSource cts)
        {
            while (!cts.IsCancellationRequested)
            {
                // 读取文字
                // 等待按键按下事件
                string line = Console.ReadLine();
                char eventCode = line.Length == 0 ? '\0' : line[0];

                // 事件处理
                switch (eventCode)
                {
                    case 'r': // run
                        isSuspended = false;
                        break;
                    case 's': // suspend
                        isSuspended = true;
                        break;
                    case 'f': // full
                        timeFormat = FULL;
                        break;
                    case 'd': // date
                        timeFormat = DATE;
                        break;
                    case 't': // time
                        timeFormat = TIME;
                        break;
                    case 'q': // quit
                        cts.Cancel();
                        break;
                    default: // 帮助
                        WriteHelp();
                        break;
                }
            }
        }

        private static void WriteHelp()
        {
            Console.Write(
                "使用方法\n" +
                "r (run)    : 开始输出时刻。\n" +
                "s (suspend): 暂停输出时刻。\n" +
                "f (full)   : 时刻格式改为“日期＋时刻”。\n" +
                "d (date)   : 时刻格式改为“仅日期”。\n" +
                "t (time)   : 时刻格式改为“仅时刻”。\n" +
                "q (quit)   : 结束程序。\n"
            );
        }

        //异步调用
        public void 异步调用示例()
        {
            Func<string, string> dele = new Func<string, string>((param) =>
            {
                // 这里将被异步调用
                Thread.Sleep(2000); // 模拟一些耗时过程
                return "结果";
            });
            var result = dele.BeginInvoke("参数", (v) =>
            {
                // 当异步调用结束以后会调用这里的的回调函数
                // 如果不需要回调函数在这里填 null
                //var ar = v as System.Runtime.Remoting.Messaging.AsyncResult;
                //var d = ar.AsyncDelegate as Func<string, string>;
                //var s = ar.AsyncState as string; // 这里能够获取"回调参数"
                //Console.WriteLine("回调已被调用，参数：" + s + Environment.NewLine +
                //                  $"EndInvokeCalled:{ar.EndInvokeCalled}");
                //if (!ar.EndInvokeCalled) // 如果主线程已经调用了EndInvoke，这里将不会执行
                //{
                //    var resultCallBack = d.EndInvoke(ar); // 回调函数取到异步调用的结果，注意不要和调用委托的线程重复使用 EndInvoke
                //    Console.WriteLine("回调：" + resultCallBack);
                //}
            }, @"回调参数");

            var r = dele.EndInvoke(result); // 阻塞当前进程直到异步调用结束
        }
    }


    public class Func与Action
    {
        //delegate string DelegateEventHandler(int param);
        //DelegateEventHandler Fun2;
        //以上两行代码等价于下句代码
        //Func<int, string> Fun2;

        //定义Func<>委托实例
        Func<string> Fun1;

        Func<int, string> Fun2;

        //若要引用的方法，具有一个参数并返回 void (或在 Visual Basic 中，声明为 Sub 而不是 Function)，使用泛型 Action<T> 委托。
        Action<int> action;

        string Method1()
        {
            return "";
        }

        string Method2(int param)
        {
            return "";
        }

        void Method(int param)
        {
        }

        void Program()
        {
            // 添加委托
            Fun1 = new Func<string>(Method1);
            Fun2 = Method2;
            action = Method;
            // 调用委托方法
            Fun1.Invoke();

            // 添加匿名方法
            Fun2 = delegate (int param) { return ""; };
            // Lambda 表达式
            Fun2 = (int param) => { return ""; };
        }
    }

    /// <summary>
    /// 自定义Dispose
    /// </summary>
    public class SampleDispose
    {
        /// <summary>
        /// 实现基类的释放模式
        /// </summary>
        public class BassTemplate : IDisposable //※需要继承IDisposable接口
        {
            /* 托管资源与非托管资源
             * 托管资源指的是.NET可以自动进行回收的资源，主要是指托管堆上分配的内存资源。托管资源的回收工作是不需要人工干预的，有.NET运行库在合适调用垃圾回收器进行回收。
             * 非托管的资源，就是Stream，数据库的连接，GDI+的相关对象，还有Com对象等等这些资源，需要手动去释放。
             * 最常用的非托管资源类型是包装操作系统资源的对象，如文件、窗口、网络连接或数据库连接。
             * 如果该类包含非托管资源，应当继承 IDisposable 接口以显示调用 Disposable() 释放资源
             * */
            /// <summary>
            /// 假设的托管资源
            /// </summary>
            Stream _unmanaged = new MemoryStream();

            SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


            public void program()
            {
                //using语句，定义一个范围，在范围结束时处理对象。
                using (BassTemplate obj = new BassTemplate())
                {
                    //代码段使用obj
                } //离开代码段后调用Dispose

                #region 等价代码

#if tru
                {
                    BassTemplate obj = new BassTemplate();
                    try
                    {

                    }
                    finally
                    {
                        if (obj != null)
                            ((IDisposable)obj).Dispose();
                    }
                }
#endif

                #endregion
            }

            /// <summary>
            /// 是否已释放资源的标志
            /// </summary>
            private bool _isDisposed = false;

            /// <summary>
            /// 类的使用者，在外部显示调用的公共处理器
            /// </summary>
            public void Dispose()
            {
                Dispose(true); // 释放托管和非托管资源
                GC.SuppressFinalize(this); //将对象从垃圾回收器链表中移除，从而在垃圾回收器工作时，只释放托管资源，而不执行此对象的析构函数
            }

            /// <summary>
            /// 执行释放资源的实际工作的 Dispose(Boolean) 方法。
            /// </summary>
            /// <param name="disposing">指示方法调用是来自 Dispose 方法（其值为 true）还是来自终结器（其值为 false）。</param>
            protected virtual void Dispose(bool disposing)
            {
                /*
                 * 如果子类有自己的非托管资源，可以重载这个函数，添加自己的非托管资源的释放
                 * 但是要记住，重载此函数必须保证调用基类的版本，以保证基类的资源正常释放
                 */

                if (!this._isDisposed) // 如果资源未释放 这个判断主要用了防止对象被多次释放
                {
                    if (disposing)
                    {
                        // 在这里添加需要释放的托管资源，它释放的托管资源可包括：
                        // 实现 T:System.IDisposable 的托管对象。 
                        // 占用大量内存或使用短缺资源的托管对象。 
                        _unmanaged?.Dispose();
                    }

                    //在这里添加需要释放的非托管资源
                }

                this._isDisposed = true; // 标识此对象已释放
            } //*/

            /// <summary>
            /// Finalize方法
            /// </summary>
            ~BassTemplate()
            {
                // 由垃圾回收器调用，释放非托管资源
                Dispose(false);
                // 析构函数实际上是隐式地对对象的基类调用 Finalize。
#if tru
                protected override void Finalize()
                {
                    try
                    {
                        // 析构函数中的方法
                    }
                    finally
                    {
                        base.Finalize();
                    }
                }
#endif
            }
        }

        /// <summary>
        /// 实现派生类的释放模式
        /// </summary>
        public sealed class SubTemplate : BassTemplate
        {
            /// <summary>
            /// 假设的非托管资源
            /// </summary>
            Stream _unmanaged = new MemoryStream();

            /// <summary>
            /// 标记子类对象是否已经被释放
            /// </summary>
            private bool _isDisposed = false;

            /// <summary>
            /// 执行释放资源的实际工作的 Dispose(Boolean) 方法。
            /// </summary>
            /// <param name="disposing">指示方法调用是来自 Dispose 方法（其值为 true）还是来自终结器（其值为 false）。</param>
            protected override void Dispose(bool disposing)
            {
                //验证是否已释放
                if (_isDisposed) return;

                if (disposing)
                {
                    //step1：在这里释放托管的并且在这个子类型中申明的资源
                }

                //step2：在这里释放非托管的并且在这个子类型中申明的资源
                _unmanaged?.Dispose();

                //step3：释放父类中的资源
                base.Dispose(disposing);

                _isDisposed = true; // 标识此对象已释放
            }

            ~SubTemplate() => Dispose(false);
        }
    }

    /// <summary>
    /// 序列化与反序列化
    /// </summary>
    public class SerializeAndDeserialize
    {
        /*
         * 参考：序列化就是把一个对象保存到一个文件或数据库字段中去，反序列化就是在适当的时候把这个文件再转化成原来的对象使用。
         * 序列化和反序列化最主要的作用有：
         * 1、在进程下次启动时读取上次保存的对象的信息
         * 2、在不同的AppDomain或进程之间传递数据
         * 3、在分布式应用系统中传递数据
         */
        /// <summary>
        /// 可序列化类
        /// </summary>
        [Serializable] // 标记为可序列化
        public class MySerializableClass
        {
            private int _int = 0;
            private string _string = "这是一个私有字段";
            public string MyString = "这是一个共有字段";

            [NonSerialized] // 标记为不可序列化
            public string CantMyString = "这是一个不可序列化字段";

            public int MyProperty { get; set; } = 666;

            public string PackagingString
            {
                get => _string;
                set => _string = value;
            }

            public void MyMethod()
            {
                Console.WriteLine(_string);
            }

            public MySerializableClass()
            {
            }

            public MySerializableClass(string str)
            {
                this._string = str;
            }
        }

        [Serializable] // 标记为可序列化
        public class MySerializableClass2
        {
            public void MyMethod()
            {
                Console.WriteLine("Test2");
            }

            public MySerializableClass2()
            {
            }
        }

        public class Program
        {
            /// <summary>
            /// 二进制（流）序列化(写入到文件)
            /// </summary>
            public void WriteBinaryFormatter(object obj, string path)
            {
                //MySerializableClass TestObj = new MySerializableClass();
                //MySerializableClass2 testObj2 = new MySerializableClass2();

                //// 创建文件流
                //FileStream streamObj = new FileStream(Application.StartupPath + @"\TestFile.txt", FileMode.Create);
                ////StreamWriter streamObj = new StreamWriter(Application.StartupPath + @"\TestFile.txt", true, Encoding.Unicode);
                ////streamObj = new FileStream(Application.StartupPath + @"\TestFile.myType", FileMode.Create);
                //// 创建序列化
                //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serialize = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                //// 序列化对象并写入到流
                //serialize.Serialize(streamObj, TestObj);
                //streamObj.Close();

                if (obj == null) return;
                try
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        var formatter = new BinaryFormatter();
                        formatter.Serialize(stream, obj);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("对象写入二进制文件失败！" + e);
                }
            }

            public object ReadBinaryFormatter(string path)
            {
                //FileStream streamObj = null;
                //try
                //{
                //    // 打开文件流
                //    streamObj = new FileStream(Application.StartupPath + @"\TestFile.txt", FileMode.Open);
                //    // 创建序列化
                //    BinaryFormatter serialize = new BinaryFormatter();

                //    // 反序列化对象
                //    MySerializableClass readedObj = serialize.Deserialize(streamObj) as MySerializableClass;

                //    readedObj.MyMethod();
                //    return readedObj;
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine.Show("错误位置：" + nameof(ReadBinaryFormatter) + "|" +
                //        "错误信息：" + e.Message);
                //}
                //finally
                //{
                //    streamObj?.Close();
                //}
                //return null;
                try
                {
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        var formatter = new BinaryFormatter();
                        return formatter.Deserialize(stream);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("读取二进制文件失败！" + e);
                }

                return null;
            }

            ///// <summary>
            ///// Soap 序列化
            ///// </summary>
            //public void WriteSoapFormatter()
            //{
            //    MySerializableClass TestObj = new MySerializableClass("23333");
            //    // 创建文件流
            //    FileStream streamObj = new FileStream(Application.StartupPath + @"\TestFile.txt", FileMode.Create);
            //    SoapFormatter serialize = new SoapFormatter();
            //    serialize.Serialize(streamObj, TestObj);
            //    streamObj.Close();
            //}

            //public MySerializableClass ReadSoapFormatter()
            //{
            //    FileStream streamObj = null;
            //    try
            //    {
            //        // 打开文件流
            //        streamObj = new FileStream(Application.StartupPath + @"\TestFile.txt", FileMode.Open);
            //        // 创建序列化
            //        SoapFormatter serialize = new SoapFormatter();

            //        // 反序列化对象
            //        MySerializableClass readedObj = serialize.Deserialize(streamObj) as MySerializableClass;

            //        readedObj.MyMethod();
            //        return readedObj;
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine.Show("错误位置：" + nameof(ReadBinaryFormatter) + "|" +
            //                        "错误信息：" + e.Message);
            //    }
            //    finally
            //    {
            //        streamObj?.Close();
            //    }

            //    return null;
            //}

            /// <summary>
            /// Xml 序列化
            /// </summary>
            public void WriteXml()
            {
                MySerializableClass TestObj = new MySerializableClass("23333");
                // 创建文件流
                FileStream streamObj = new FileStream(@"\TestFile.xml", FileMode.Create);
                //FileStream streamObj = new FileStream(Application.StartupPath + @"\TestFile.xml", FileMode.Create);
                XmlSerializer serialize = new XmlSerializer(typeof(MySerializableClass));
                serialize.Serialize(streamObj, TestObj);
                streamObj.Close();
            }

            public MySerializableClass ReadXml()
            {
                FileStream streamObj = null;
                try
                {
                    // 打开文件流
                    streamObj = new FileStream(@"\TestFile.xml", FileMode.Open);
                    // 创建序列化
                    XmlSerializer serialize = new XmlSerializer(typeof(MySerializableClass));

                    // 反序列化对象
                    MySerializableClass readedObj = serialize.Deserialize(streamObj) as MySerializableClass;

                    readedObj.MyMethod();
                    return readedObj;
                }
                catch (Exception e)
                {
                    Console.WriteLine("错误位置：" + nameof(ReadBinaryFormatter) + "|" +
                                    "错误信息：" + e.Message);
                }
                finally
                {
                    streamObj?.Close();
                }

                return null;
            }
        }
    }

    //public class 多线程调用窗口控件
    //{
    //    public class Form : System.Windows.Forms.Form
    //    {
    //        //窗口控件
    //        System.Windows.Forms.TextBox TextBox = new System.Windows.Forms.TextBox();


    //        //定义委托
    //        public delegate System.Windows.Forms.TextBox GetTextEventHandler();

    //        //定义委托实例
    //        public static GetTextEventHandler GetTestTextBox;

    //        //委托方法
    //        public System.Windows.Forms.TextBox GetTestTextBoxMethod()
    //        {
    //            return TextBox;
    //        }

    //        public void Main()
    //        {
    //            //添加委托
    //            GetTestTextBox = new GetTextEventHandler(GetTestTextBoxMethod);
    //        }
    //    }

    //    public class Thread
    //    {
    //        delegate void UpdateEventHandler(); //与更新控件方法对应的委托

    //        //更新控件
    //        public void Update()
    //        {
    //            if (Form.GetTestTextBox().InvokeRequired
    //            ) //如果控件的 true 是在与调用线程不同的线程上创建的（说明您必须通过 Invoke 方法对控件进行调用），则为 Handle；否则为 false。
    //            {
    //                //UpdateEventHandler Callback = new UpdateEventHandler(Update);
    //                Form.GetTestTextBox().BeginInvoke(new UpdateEventHandler(Update)); //推荐 //以异步方式在 UI 线程上运行
    //                Form.GetTestTextBox().Invoke(new UpdateEventHandler(Update)); //以同步方式在 UI 线程上运行，将会等待 UI 线程运行结束
    //            }
    //            else
    //            {
    //                Form.GetTestTextBox().Text = ""; //在这里更新控件，GetTestTextBox()等价于TestTextBox引用，流程在控件线程上
    //            }
    //        }

    //        //读取控件
    //        public void Read()
    //        {
    //            string test = Form.GetTestTextBox().Text;
    //        }


    //        public void Update1()
    //        {
    //            if (Form1.GetUIForm().InvokeRequired)
    //            {
    //                Form1.GetUIForm().BeginInvoke(new UpdateEventHandler(Update1));
    //            }
    //            else
    //            {
    //                Form1.GetUIForm().TextBox.Text = "";
    //            }
    //        }
    //    }

    //    public class Form1 : System.Windows.Forms.Form
    //    {
    //        //窗口控件
    //        internal System.Windows.Forms.TextBox TextBox = new System.Windows.Forms.TextBox();

    //        public delegate Form1 GetUIFormEventHandler();

    //        public static GetUIFormEventHandler GetUIForm;

    //        //委托方法
    //        public Form1 GetUIFormMethod()
    //        {
    //            return this;
    //        }

    //        public void Main()
    //        {
    //            //添加委托
    //            GetUIForm = new GetUIFormEventHandler(GetUIFormMethod);
    //        }
    //    }
    //}

    public class 利用CSharp实现闭包概念
    {
        /*
         * 任何声明在另一个函数内部的函数都可以称为闭包。也就是说，闭包是一个函数。
         * 严格来说，闭包是内部函数以及其作用域链组成的一个整体。
         * 闭包的特点：
         *  1.闭包函数能够访问外部函数的变量。（换句话说，局部函数能够访问外部函数的局部变量）
         *  2.闭包函数能够维持函数作用域。
         *  
         * 可以把闭包的“闭包外局部变量”看成是一个对象中的私有变量，闭包是这个对象中的函数
         */
        public void Main()
        {
            var temp1 = Method(60); // 闭包1
            var temp2 = Method(60); // 闭包2
            Console.WriteLine(temp1(60) + "\t" + temp2(90)); // 两个闭包的“闭包外局部变量”互不干扰
            Console.WriteLine(temp1(60) + "\t" + temp2(90));
            Console.WriteLine(temp1(60) + "\t" + temp2(90));
            temp1 = null; // 闭包的“闭包外局部变量”将在其闭包的生命周期结束时销毁
            Console.Read();
        }

        Func<int, int> Method(int local) // local是一个方法中的局部变量
        {
            int inside(int change) // 也可以利用匿名方法实现
            {
                local = local + change;
                return local; // local的值会被保存
            }

            return new Func<int, int>(inside);
        }
    }

    public class 动态类型反汇编
    {
        /*动态类型反汇编总结
         * 声明的 dynamic 转变为 object
         * 赋值到动态类型不做任何变化
         * 动态类型转换成其他类型时，先会生成一个静态委托，并在调用的地方先执行一次 Null 检查，再创建动态调用站点转换联编程序
         * 动态类型作为（return）返回值时处理同上
         * 当动态类型是字段、属性、索引器、函数、返回值时会添加声明为动态类型的特性
         * 当访问动态类型中的成员时，先会生成一个静态委托，并在调用的地方先执行一次 Null 检查，再创建动态调用站点联编程序
         */
    }

    class 正则表达式
    {
        // 快速参考：https://docs.microsoft.com/zh-cn/dotnet/standard/base-types/regular-expression-language-quick-reference
    }
}
#endif