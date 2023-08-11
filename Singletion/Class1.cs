using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singletion
{
    internal class Class1 : SingleInstance<Class1, Init>, Init
    {
        public string Name = "TimeUtil1";
        private Class1()
        {
        }
        public void Init()
        {
            Console.WriteLine("Class1 Init");
        }
    }
}