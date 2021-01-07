//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    class Class1
//    {

//        public static void Main()
//        {
//            Thread t = new Thread(pri);
//            Thread t1 = new Thread(hari);
//            t.Start();
//            Thread.Sleep(5000);
//            t.Join();
//            t1.Start();
//        }

//        public static void pri()
//        {
//            object obj = new object();
//            lock (obj)
//            {
//                List<int> li = new List<int>();
//                for (int i = 1; i <= 10; i++)
//                {
//                    li.Add(i);
//                    //Thread.Sleep(2000);
//                }
//                ConcurrentBag<int> c = new ConcurrentBag<int>(li);
//                Parallel.ForEach(c, d =>
//                 {
//                     Console.WriteLine(d);
//                 });
//                //Parallel.For(0, c.Count, i =>
//                //{
//                //    Console.WriteLine(li[i]);
//                //});
//            }
//        }
//        public static void hari()
//        {

           
//                List<int> l4 = new List<int>();
//                for (int j = 11; j <= 20; j++)
//                {
//                    l4.Add(j);
//                    //Thread.Sleep(2000);
//                }
//                ConcurrentBag<int> ca = new ConcurrentBag<int>(l4);
//                Parallel.ForEach(ca, d =>
//                {
//                    Console.WriteLine(d);
//                });
            
//        }
//    }
//}
