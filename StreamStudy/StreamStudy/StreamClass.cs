using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamStudy
{
    internal class StreamClass
    {
        private DirectoryInfo basePath= new DirectoryInfo(Directory.GetCurrentDirectory());
        private AsyncCallback asyncReadCallback = new AsyncCallback(ReadCallback);
        private AsyncCallback asyncWriteCallback = new AsyncCallback(WriteCallback);
        private object asyncReadCallbackObj = new object();
        private object asyncWriteCallbackObj = new object();
        public void Main()
        {
            string startDirectory = basePath.Parent.Parent.Parent.FullName + @"\aaa";
            string endDirectory = basePath.Parent.Parent.Parent.FullName + @"\bbb";
            if (!Directory.Exists(startDirectory))
            {
                Console.WriteLine("输入文件夹不存在"+ startDirectory);
                return;
            }
            Directory.CreateDirectory(endDirectory);
            foreach (string filename in Directory.EnumerateFiles(startDirectory))
            {
                //#region 同步复制10次
                //using (FileStream sourctFileStream = File.Open(filename, FileMode.Open))
                //{
                //    Console.WriteLine(sourctFileStream.Name);
                //    Console.WriteLine(sourctFileStream.Length);
                //    using (FileStream destinationStream = File.Create(endDirectory + filename.Substring(filename.LastIndexOf('\\'))))
                //    {
                //        byte[] buffer = new byte[512]; // 读取数据写入到目标文件流
                //        int bytesRead;
                //        int i = 0;
                //        while ((bytesRead = sourctFileStream.Read(buffer, 0, buffer.Length)) > 0 && i < 10)
                //        {
                //            i++;
                //            Console.WriteLine(sourctFileStream.Position);
                //            sourctFileStream.Seek(0, SeekOrigin.Begin);
                //            //sourctFileStream.Position = 0;
                //            destinationStream.Write(buffer, 0, bytesRead);
                //        }
                //    }
                //}
                //#endregion
                #region 异步读取
                //using (FileStream sourctFileStream = File.Open(filename, FileMode.Open))
                //{
                //    using (FileStream destinationStream = File.Create(endDirectory + filename.Substring(filename.LastIndexOf('\\'))))
                //    {
                //        byte[] buffer = new byte[512]; // 读取数据写入到目标文件流
                //        int bytesRead;
                //        while ((bytesRead = sourctFileStream.Read(buffer, 0, buffer.Length)) > 0)
                //        {
                //            Console.WriteLine(sourctFileStream.Position);
                //            destinationStream.BeginWrite(buffer, 0, bytesRead, asyncWriteCallback, asyncWriteCallbackObj);
                //        }
                //    }
                //}
                #endregion
                #region 异步写入
                using (FileStream sourctFileStream = File.Open(filename, FileMode.Open))
                {
                    using (FileStream destinationStream = File.Create(endDirectory + filename.Substring(filename.LastIndexOf('\\'))))
                    {
                        //一个中文三个字符所以数组大小必须是3的倍数才不会乱码
                        byte[] buffer = new byte[108]; // 读取数据写入到目标文件流
                        int bytesRead;
                        while ((bytesRead = sourctFileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            Console.WriteLine(sourctFileStream.Position);
                            destinationStream.BeginWrite(buffer, 0, bytesRead, asyncWriteCallback, asyncWriteCallbackObj);
                        }
                    }
                }
                #endregion
            }
        }
        private static void ReadCallback(IAsyncResult ar)
        {
            Console.WriteLine("异步读取回调函数：");
            Console.WriteLine(ar.IsCompleted);
        }
        private static void WriteCallback(IAsyncResult ar)
        {
            Console.WriteLine("异步写入回调函数");
        }
    }
}