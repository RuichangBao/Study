using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singletion
{
    internal class Class2 : SingleInstance<Class2>, Init
    {
        public string Name = "Class2";
        private Class2()
        {

        }

        public void Init()
        {
            Console.WriteLine("Class2 Init");
        }
    }
}