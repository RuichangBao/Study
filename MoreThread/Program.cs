using System;
using System.Threading;

namespace MoreThread
{
    class Program
    {
        public static int appleNum = 10;
        private static object locker = new object();//创建锁
        private static Mutex mutex = null;

        static void Main(string[] args)
        {
            mutex = new Mutex();
            Thread t1 = new Thread(() => { EatApple("张三"); });
            t1.Start();
            Thread t2 = new Thread(() => { EatApple("李四"); });
            t2.Start();
            while (true)
            {

            }
        }
        static void EatApple(string name)
        {
            Console.WriteLine("线程启动：" + name);
            while (appleNum > 0)
            {
                lock (locker)
                {
                    appleNum--;
                    Console.WriteLine(name + " 正在吃苹果，");
                    Thread.Sleep(3000);
                    Console.WriteLine(name + " 吃完了，还剩" + appleNum + "个苹果\n");
                }
            }
        }
    }
}
