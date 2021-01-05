using NLua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LuaProcess : NLua.Lua
{
    // 参考手册：https://www.lua.org/manual/
    /*
     CLR应用程序通过LuaInterface.Lua类来使用Lua解释器。实例化这个类，创建一个新的Lua解释器，不同实例直接完全独立。
     Lua类索引创建，读取和修改全部变量，由变量的名字索引
    */
    public void LuaRun()
    {
        State.Encoding = Encoding.UTF8;
        /*
lua变量类型和c#中变量类型的对应
nil         null
string      System.String
number      System.Double
boolean     System.Boolean
table       LuaInterface.LuaTable
Function    LuaInterface.LuaFunction
         */
        this["Num"] = 123;// 定义一个数字
        this["String"] = "从C#中定义变量";// 定义一个字符串

        Console.WriteLine(GetNumber("Num"));// 从lua中读取数字
        Console.WriteLine(GetString("String"));// 从lua中读取字符串 

        // 读取 lua 脚本文件到字符串，并执行
        var luaScriptText = System.IO.File.ReadAllText("../../../学习笔记/Lua交互/Lua_Simple.lua", Encoding.UTF8);
        var reslut = DoString(luaScriptText);// 执行并返回结果
        Console.WriteLine(reslut.First());

        // 执行后如果最后是 return 则会返回一个object对象组
        //DoFile("Lua_Simple.lua");// 从脚本执行 lua 代码
        DoString("Num = 233;");// 从字符串执行 lua 代码

        /*
        // 向lua注册C#方法
        // 1.指定lua中的函数名 
        // 2.指定一个静态方法（最好指定参数类型）
        this.RegisterFunction("CSStaticMethod", typeof(LuaIface).GetMethod("DoStaticMsg", new Type[] { typeof(int) }));
        // 注册一个对象方法
        var LuaInterface = new LuaIface();
        // 1.指定lua中的函数名 
        // 2.指定一个对象
        // 3.指定一个实例方法（最好指定参数类型）
        this.RegisterFunction("CSObjectMethod", LuaInterface, LuaInterface.GetType().GetMethod("DoObjMsg", new Type[] { typeof(int) }));
        // lua 调用 C# 方法
        this.DoFile("TestLua.lua");
        this.DoString("CSStaticMethod(8801)");
        this.DoString("CSObjectMethod(8802)");*/


        // 在 C# 中调用 lua 的函数
        DoString(@"
function Function (param1)
    return function(param2)
        param1 = param1 + param2;
        return param1;
    end
end"
);
        using (var Function = this["Function"] as LuaFunction)
        {
            // 调用 lua 函数将会返回一个object数组
            using (var re = Function.Call(1).First() as LuaFunction)
            {
                var result = re.Call(2);
                Console.WriteLine(result.First());
                Console.WriteLine(re.Call(3).First());
            }
        }


        // 将C# 对象注册进 lua
        this["obj"] = new LuaIface();
        // lua 中调用 C# 对象
        //DoString("print(obj._filed);"); // 无法调用私有成员
        //DoString("print(obj.internalFiled);"); // 无法调用内部成员
        DoString("print(obj.Filed);");
        DoString("obj:DoObjMsg(1818);");
        // 注册对象方法到Lua
        RegisterFunction("DoObjMsg", this["obj"], typeof(LuaIface).GetMethod("DoObjMsg"));
        // Lua调用动态方法
        DoString("DoObjMsg(1919);");
        // 注册静态方法到Lua
        RegisterFunction("DoStaticMsg", typeof(LuaIface).GetMethod("DoStaticMsg"));
        // Lua调用静态方法
        DoString("DoStaticMsg(2020);");


        // 返回所有全局变量
        foreach (var item in Globals)
        {
            Console.WriteLine(item);
        }
    }


    /// <summary>
    /// 提供给lua可使用的接口
    /// </summary>
    public class LuaIface
    {
        private int _filed = 10;
        internal int internalFiled = 20;
        public int Filed = 30;
        public void DoObjMsg(int abc)
        {
            Console.WriteLine("C#的实例方法，编号：" + abc.ToString());
        }
        public static void DoStaticMsg(int abc)
        {
            Console.WriteLine("C#的静态方法，编号：" + abc.ToString());
        }
    }
}