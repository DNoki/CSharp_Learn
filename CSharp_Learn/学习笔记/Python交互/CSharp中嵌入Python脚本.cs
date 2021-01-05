using IronPython;
using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class PythonProcess
{
    public static void TestPython()
    {
        var pyEngine = Python.CreateEngine();
        var scope = pyEngine.CreateScope();
        var code = pyEngine.CreateScriptSourceFromString(@"
print('Holle World');
print('你好世界');

def MyMethod():
    class MyClass(object):
        '''docstring for MyClass.'''
        def __init__(self):
            print('对象已生成！')
            super(MyClass, self).__init__()

    NewClass = MyClass
    _object = NewClass()
    _object.newVar = 13
    print(_object.newVar)

MyMethod();

a = 0
for i in range(101):
    a += i;
else:
    print('循环结束');
    print(a);
");
        //var scriptText = File.ReadAllText("../../../学习笔记/Python交互/Python 范例.py", Encoding.UTF8);
        //var code = pyEngine.CreateScriptSourceFromString(scriptText);
        code.Execute(scope);
    }
}