using System;

namespace EntityFrameWorkTask18
{
    class Program
    {
        static void Main(string[] args)
        {
            new InsertRecordsInOrderDetails().Excecute();
            new InsertRecordsIntoProductDetails().Execute();
        }
    }
}
