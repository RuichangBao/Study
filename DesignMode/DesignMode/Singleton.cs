using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    /// <summary>
    /// 单例模式(最简单的单例模式 非线程安全)
    /// </summary>
    public class Singleton
    {
        public int TestNum;
        private Singleton()
        {

        }
        private static Singleton instance;

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        public void TestFunc()
        {
            
        }
    }
}
