using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWork
{
    public class InsertRecordsIntoDepartment
    {
        public void Execute()
        {
            try
            {
                using (var context = new ContextClass())
                {
                    var dept = new Department
                    {
                        deptName = "Accounting"
                    };
                    context.Departments.Add(dept);
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

           


