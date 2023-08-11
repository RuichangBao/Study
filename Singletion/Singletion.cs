using System.Reflection;
using System;
namespace Singletion
{
    //伪单例模式，继承类不能声明私有构造函数
    public abstract class Singletion<T> where T : class, Init, new()
    {
        private static T instance;
        public static T Instance()
        {
            if (instance == null)
            {
                instance = new T();
                instance.Init();
            }
            return instance;
        }
        //public abstract void Init();
    }
}