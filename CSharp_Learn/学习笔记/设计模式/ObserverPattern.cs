using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // 定义对象间的一种一对多的依赖关系,当一个对象的状态发生改变时, 所有依赖于它的对象都得到通知并被自动更新。
    /// <summary>
    /// 观察者模式
    /// </summary>
    public class ObserverPattern
    {
        ///// <summary>
        ///// 目标，被观察者，管理观察者并通知观察者
        ///// </summary>
        //public abstract class Subject
        //{
        //    public List<Observer> ObserverList { get; set; }

        //    public void Attach(Observer observer)
        //    {
        //        this.ObserverList.Add(observer);
        //    }
        //    public void Detach(Observer observer)
        //    {
        //        this.ObserverList.Remove(observer);
        //    }
        //    public void Notify()
        //    {
        //        foreach (var o in this.ObserverList)
        //        {
        //            o.Update();
        //        }
        //    }
        //}

        ///// <summary>
        ///// 具体的目标
        ///// </summary>
        //public class ConcreteSubject : Subject
        //{
        //    public int SubjectState { get; set; }

        //}

        ///// <summary>
        ///// 观察者抽象
        ///// </summary>
        //public abstract class Observer
        //{


        //    public abstract void Update();
        //}

        ///// <summary>
        ///// 具体的观察者
        ///// </summary>
        //public class ConcreteObserver : Observer
        //{
        //    private int observerState { get; set; }
        //    public ConcreteSubject Subject { get; set; }

        //    public override void Update()
        //    {
        //        this.observerState = this.Subject.SubjectState;
        //    }

        //}
    }
}
