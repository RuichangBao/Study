using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    class Student
    {
        private int id;
        public Student(int id)
        {
            this.id = id;
        }

        private void Print()
        {
            Console.WriteLine("私有输出方法" + id);
        }
    }
}
