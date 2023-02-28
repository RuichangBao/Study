using System;

namespace DesignMode
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.TestNum = 100;
            Console.WriteLine(Singleton.Instance.TestNum);
            Console.WriteLine("Hello World!");
        }
    }
}
