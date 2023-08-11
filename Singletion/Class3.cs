using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singletion
{
    internal class Class3 : Singletion<Class3>, Init
    {
        public string Name = "Class3";
        public Class3()
        {

        }
        public void Init()
        {
            Console.WriteLine ("重写 基类Init 方法 Class3  Init");
        }
    }
}