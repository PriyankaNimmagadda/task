using System;

namespace EntityFrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            new InsertRecordIntoEmployeeTable().Execute();
            new InsertRecordsIntoDepartment().Execute();
        }
    }
}
