//using NLua;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//using IronPython;
//using IronPython.Hosting;
//using Microsoft.Scripting;

//namespace CSharp_Learn.Demo
//{
//    public class LuaProcess : NLua.Lua
//    {
//        /*
//         CLR应用程序通过LuaInterface.Lua类来使用Lua解释器。实例化这个类，创建一个新的Lua解释器，不同实例直接完全独立。
//         Lua类索引创建，读取和修改全部变量，由变量的名字索引
//        */
//        public void LuaRun()
//        {
//            /*
//lua变量类型和c#中变量类型的对应
//nil         null
//string      System.String
//number      System.Double
//boolean     System.Boolean
//table       LuaInterface.LuaTable
//Function    LuaInterface.LuaFunction
//             */
//            this["Num"] = 123;// 定义一个数字
//            this["String"] = "从C#中定义变量";// 定义一个字符串

//            var num = this.GetNumber("Num");// 从lua中读取数字
//            var str = this.GetString("String");// 从lua中读取字符串 

//            // 读取 lua 脚本文件到字符串，并执行
//            var luaScriptStream = new System.IO.StreamReader("TestLua.lua", Encoding.UTF8);
//            luaScriptStream.BaseStream.Position = 0;
//            var luaScriptText = luaScriptStream.ReadToEnd();
//            var reslut = this.DoString(luaScriptText).First();// 执行并返回结果

//            // 执行后如果最后是 return 则会返回一个object对象组
//            this.DoFile("TestLua.lua");// 从脚本执行 lua 代码
//            this.DoString("Num = 233;");// 从字符串执行 lua 代码

//            /*
//            // 向lua注册C#方法
//            // 1.指定lua中的函数名 
//            // 2.指定一个静态方法（最好指定参数类型）
//            this.RegisterFunction("CSStaticMethod", typeof(LuaIface).GetMethod("DoStaticMsg", new Type[] { typeof(int) }));
//            // 注册一个对象方法
//            var LuaInterface = new LuaIface();
//            // 1.指定lua中的函数名 
//            // 2.指定一个对象
//            // 3.指定一个实例方法（最好指定参数类型）
//            this.RegisterFunction("CSObjectMethod", LuaInterface, LuaInterface.GetType().GetMethod("DoObjMsg", new Type[] { typeof(int) }));
//            // lua 调用 C# 方法
//            this.DoFile("TestLua.lua");
//            this.DoString("CSStaticMethod(8801)");
//            this.DoString("CSObjectMethod(8802)");*/


//            // 在 C# 中调用 lua 的函数
//            this.DoString(@"
//            function Function (param1)
//                return function(param2)
//                param1 = param1 + param2;
//                return param1;
//                end
//            end");
//            using (var Function = this["Function"] as LuaFunction)
//            {
//                // 调用 lua 函数将会返回一个object数组
//                using (var re = Function.Call(60).First() as LuaFunction)
//                {
//                    Console.WriteLine((re.Call(60).First() as double?).ToString());
//                    Console.WriteLine((re.Call(60).First() as double?).ToString());
//                }
//            }


//            // 将C# 对象注册进 lua
//            this["obj"] = new LuaIface();
//            // lua 中调用 C# 对象
//            DoString("local res = obj:DoObjMsg(1818);");

//            // 返回所有全局变量
//            foreach (var item in this.Globals)
//            {
//                Console.WriteLine(item);
//            }
//        }



//        public void TestMethod()
//        {
//            LuaRun();
//            return;
//            var luaInterface = new LuaIface();
//            //this["母港"] = Data.Pond.母港;
//            this["_bool"] = false;
//            this.RegisterFunction("判断", luaInterface, typeof(LuaIface).GetMethod("Judge"));
//            this.DoFile(@"C:\Users\Noki\Desktop\Program\lua\MyLua.lua");
//            var temp1 = (bool)this["_bool"];
//            System.Windows.Forms.MessageBox.Show(temp1.ToString());
//            return;
//            var temp = this.DoString(@"
//            function Function ()
//              return ""函数返回值""
//            end
//            a = 65
//            return Function ()");
//            var b = temp?[0] ?? null as string;
//            System.Windows.Forms.MessageBox.Show(temp.ToString());


//        }

//        /// <summary>
//        /// 提供给lua可使用的接口
//        /// </summary>
//        public class LuaIface
//        {
//            private int _filed;
//            internal int internalFiled;
//            public int Filed;
//            public void DoObjMsg(int abc)
//            {
//                Console.WriteLine("C#的实例方法，编号：" + abc.ToString());
//            }
//            public static void DoStaticMsg(int abc)
//            {
//                Console.WriteLine("C#的静态方法，编号：" + abc.ToString());
//            }
//            /*
//            public bool Judge(DataJudge data, int rin = 0, int OffsetX = 0, int OffsetY = 0)
//            {
//                return Function.FunctionJudge.Judge(data);
//            }*/
//        }
//    }

//    public class PythonProcess
//    {
//        void RunPy()
//        {
//            var engine= Python.CreateEngine();// 声明调用Python的类
//            var scope = engine.CreateScope();
//            var code = engine.CreateScriptSourceFromString("");// 通过 string 调用 Py语句
//            code.Execute(scope);// 执行上述 Py 代码

//        }
//    }
//}
