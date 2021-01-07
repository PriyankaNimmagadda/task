using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class2
    {
      

        public void swap()
        {
            //int a = 10, b = 20;
            //a = a + b;
            //b = a - b;
            //a = a - b;
            //Console.WriteLine(+a + " " + b);
            ConcurrentBag<int> c1 = new ConcurrentBag<int>();
            c1.Add(1);
            c1.Add(2);
            c1.Add(3);
            
                Parallel.ForEach(c1, n =>
                {
                    Console.WriteLine(n);
                });
           

        }
    }
}
