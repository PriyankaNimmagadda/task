using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWork
{
    public class InsertRecordIntoEmployeeTable
    {
        public void Execute()
        {
            try
            {
                using (var context = new ContextClass())
                {
                    var employee = new Employee();
                    Console.WriteLine("enter empName");
                    employee.empName = Console.ReadLine();
                    Console.WriteLine("enter empLoc");
                    employee.empLoc = Console.ReadLine();
                    Console.WriteLine("enter the deptId");
                    employee.deptId = Convert.ToInt32(Console.ReadLine());

                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

