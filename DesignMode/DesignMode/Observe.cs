using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 观察者模式
/// </summary>
namespace DesignMode
{
    /// <summary>
    /// 抽象主题
    /// </summary>
    public abstract class Subject
    {
        List<IObserver> observers = new List<IObserver>();
        // 对同一个订阅号，新增和删除订阅者的操作
        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }
        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }
        public void Update()
        {
            foreach (IObserver item in observers)
            {
                if (item != null)
                {
                    item.Receive(this);
                }
            }
        }
    }
    /// <summary>
    /// 具体主题
    /// </summary>
    class ConcreteSubject: Subject
    {
        public ConcreteSubject(): base()
        {
        }
    }
    // 订阅者接口
    public interface IObserver
    {
        void Receive(Subject tenxun);
    }
    // 具体的订阅者类
    public class Subscriber1 : IObserver
    {
        public Subscriber1()
        {
        }

        public void Receive(Subject xmfdsh)
        {
            Console.WriteLine("订阅者 1观察到了");
        }
    }
    public class Subscriber2 : IObserver
    {
        public Subscriber2()
        {
        }

        public void Receive(Subject xmfdsh)
        {
            Console.WriteLine("订阅者 2观察到了");
        }
    }
    // 客户端测试
    //class Program2
    //{
    //    static void Main(string[] args)
    //    {
    //        ConcreteSubject concreteSubject = new ConcreteSubject();

    //        // 添加订阅者
    //        concreteSubject.AddObserver(new Subscriber1());
    //        concreteSubject.AddObserver(new Subscriber2());
    //        //更新信息
    //        concreteSubject.Update();
    //        //输出结果，此时所有的订阅者都已经得到博客的新消息
    //        Console.ReadLine();
    //    }
    //}
}