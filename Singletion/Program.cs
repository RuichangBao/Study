using System;
using System.Diagnostics;

namespace Singletion // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Init init = Class1.Instance();//获取到的是一个接口
            init.Init();
            Class2.Instance().Init();//获取到的是一个对象
            Console.WriteLine(Class3.Instance().Name);
            Console.ReadKey();
        }
    }
}