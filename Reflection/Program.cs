using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void  Main(string[] args)
        {
            string className = "Reflection.Student";
            Type type = Type.GetType(className);
            dynamic student = type.Assembly.CreateInstance(className, true, BindingFlags.Default, null, new object[] { 1000 }, null, null);
            //Student student = new Student(10086);
            //Type type = student.GetType();

            FieldInfo fieldInfo = type.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
            object value1 = fieldInfo.GetValue(student);
            Console.WriteLine(value1.GetType());
            int num = (int)fieldInfo.GetValue(student);
            Console.WriteLine(value1.ToString());


            MethodInfo methodInfo = type.GetMethod("Print", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(student, null);
            Console.WriteLine(methodInfo.GetType());

            Console.WriteLine("Hello World!");
        }
    }
}
