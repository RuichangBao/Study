using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void  Main(string[] args)
        {
            string className = "Reflection.Student";
            //反射创建对象
            Type type = Type.GetType(className);
            dynamic student = type.Assembly.CreateInstance(className, true, BindingFlags.Default, null, new object[] { 1000 }, null, null);

            FieldInfo fieldInfo = type.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
            //通过反射访问私有变量
            object value1 = fieldInfo.GetValue(student);
            Console.WriteLine(value1.GetType());
            Console.WriteLine(value1.ToString());

            //通过反射访问私有方法
            MethodInfo methodInfo = type.GetMethod("Print", BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo.Invoke(student, null);
            Console.WriteLine(methodInfo.GetType());

            Console.WriteLine("Hello World!");
        }
    }
}
