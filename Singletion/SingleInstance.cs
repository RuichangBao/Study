using System.Reflection;
using System;
namespace Singletion
{

    /// <summary>
    /// 带接口的单例，通常用于可MOCK的类
    /// </summary>
    /// <typeparam name="T">单例的类型</typeparam>
    /// <typeparam name="I">单例类型的接口</typeparam>
    public class SingleInstance<T, I> where T : I
    {
        //private static object lockObj = new object();
        private static T instance;
        //获取到的是一个接口
        public static I Instance()
        {
            //lock (lockObj)
            //{
            if (instance == null)
            {
                instance = InstanceCreater.CreateInstance<T>();
            }
            //}
            return instance;
        }
    }

    /// <summary>
    /// 单例,需要在当前类中定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleInstance<T> where T : class
    {
        private static object lockObj = new object();
        private static T instance;
        public static T Instance()
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = InstanceCreater.CreateInstance<T>();
                }
            }

            return instance;
        }
    }

    static class InstanceCreater
    {
        public static T CreateInstance<T>()
        {
            Type type = typeof(T);
            try
            {
                return (T)type.Assembly.CreateInstance(type.FullName, true, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null, null);
            }
            catch (MissingMethodException ex)
            {
                throw new Exception(string.Format("{0}(单例模式下，构造函数必须为private)", ex.Message));
            }
        }
    }
}