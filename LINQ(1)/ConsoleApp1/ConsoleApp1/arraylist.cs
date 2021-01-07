//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    class Arraylist2
//    {



//        public void arrayList1()
//        {
//            IList<int> lst = new List<int>();
//            Parallel.For(0, 100000, i =>
//              {
//                  lst.Add(i);
//              });

//            ParallelOptions po = new ParallelOptions();
//            po.MaxDegreeOfParallelism = 3;

//            CancellationTokenSource cts = new CancellationTokenSource();
//            po.CancellationToken = cts.Token;
//            Console.WriteLine("Press any key to START.....Press C to CANCEL ");
//            Console.ReadKey();
//            Task.Factory.StartNew(() =>
//            {


//                if (Console.ReadKey().KeyChar == 'c')
//                {
//                    cts.Cancel();
//                }
//            });

//            try
//            {
//                Parallel.ForEach(lst,po,n =>

//                  {
//                      Console.WriteLine(n);
//                      po.CancellationToken.ThrowIfCancellationRequested();
//                  });
//            }
//            catch (OperationCanceledException e)
//            {
//                Console.WriteLine(e.Message);
//            }
//            finally
//            {
//                cts.Dispose();
//            }

//        }

////    }
////}