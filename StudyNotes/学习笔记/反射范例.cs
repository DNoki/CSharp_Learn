using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public static class 反射范例
{
    //注意：BindingFlags.Instance 或者 BindingFlags.Static 二者必须有一项或者都有
    // 查找所有成员 BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static

    public static void Main(string[] args)
    {
        var obj = (object)new SampleClass();

        obj.SetPrivateProperty("privateProperty", "改变的文本");
        Console.WriteLine(obj.GetPrivateField<string>("privateField"));
        obj.SetPrivateField("privateField", "改变的文本2");
        Console.WriteLine(obj.GetPrivateProperty<string>("privateProperty"));

        obj.GetPrivateMethod<Action>("privateMethod").Invoke();
        obj.GetPrivateMethod<Action<string>>("privateMethod").Invoke("带参数的方法");

        var result = obj.GetPrivateMethod<Func<int, int, int>>("privateMethod").Invoke(233, 433);
        Console.WriteLine(result);

        Console.ReadLine();
    }

    /// <summary>
    /// 利用反射获取对象私有字段的值
    /// </summary>
    /// <typeparam name="T">字段类型</typeparam>
    /// <param name="instance"></param>
    /// <param name="name">私有字段名</param>
    /// <returns></returns>
    public static T GetPrivateField<T>(this object instance, string name)
    {
        var field = instance.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
        return field != null ? (T)field.GetValue(instance) : (default);
    }
    /// <summary>
    /// 利用反射修改对象私有字段的值
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="name">私有字段名</param>
    /// <param name="value">要修改的值</param>
    public static void SetPrivateField(this object instance, string name, object value)
    {
        var field = instance.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
        field.SetValue(instance, value);
    }
    /// <summary>
    /// 利用反射获取对象私有属性的值
    /// </summary>
    /// <typeparam name="T">属性类型</typeparam>
    /// <param name="instance"></param>
    /// <param name="name">私有属性名</param>
    /// <returns></returns>
    public static T GetPrivateProperty<T>(this object instance, string name)
    {
        var property = instance.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic);
        return property != null ? (T)property.GetValue(instance) : (default);
    }
    /// <summary>
    /// 利用反射修改对象私有属性的值
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="name">私有属性名</param>
    /// <param name="value">要修改的值</param>
    public static void SetPrivateProperty(this object instance, string name, object value)
    {
        var property = instance.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic);
        property.SetValue(instance, value);
    }
    /// <summary>
    /// 利用反射获取对象私有方法的委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="instance"></param>
    /// <param name="name"></param>
    /// <param name="types"></param>
    /// <returns></returns>
    public static T GetPrivateMethod<T>(this object instance, string name) where T : Delegate
    {
        //var type = instance.GetType();
        //var method = type.GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic, null, types, null);
        //return method != null ? Delegate.CreateDelegate(typeof(T), instance, method) as T : null;
        return Delegate.CreateDelegate(typeof(T), instance, name) as T;
    }
}

public class SampleClass
{
    private string privateField = "Private Field";
    private string privateProperty { get => privateField; set => privateField = value; }

    private void privateMethod() => Console.WriteLine("Private Method excute.");
    private void privateMethod(string text) => Console.WriteLine($"Private Method excute. Print {text}");
    private int privateMethod(int a, int b) => a + b;

    public string PublicField = "Public Field";

    public void PublicMethod() => Console.WriteLine("Public Method excute.");

}

