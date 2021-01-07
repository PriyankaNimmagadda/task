using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static string objConn;
        static void Main(string[] args)
        {
            objConn = "Data Source=192.168.50.95;Initial Catalog=pnimmagadda;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            var employees1 = GetEmployees();
            foreach(var data in employees1)
            {
                Console.WriteLine(data.empId + " " + data.empName + " " + data.empMobileNumber + " " + data.empSalary + " " + data.empDateOfJoining + " " + data.empPerformance);
            }
            var data1 = employees1.Where(d => d.empName.Equals("harish"));
            var data2 = employees1.Where(d => d.empName.Equals("harish")).OrderBy(d=>d.empId);
//---------------------------------------------------VAR------------------------------------------------------------------------------------
            
            var query1 = from employees in employees1
                         where employees.empMobileNumber.StartsWith("7")
                         select employees;

//--------------------------------------------------AVG-------------------------------------------------------------------------------------------------------------------
           
            var query2 = employees1.Average(avg => avg.empId);
            Console.WriteLine(query2);
//-----------------------------------------------Conatins----------------------------------------------------------------------------------
            
            var contains = from employees in employees1
                           where employees.empName.Contains("harish")
                           select employees;
//-------------------------------------------------CONCAT-------------------------------------------------------------------------------------

            // var concat = query1.Concat(query2);

 //---------------------------------------------------DISTINCT----------------------------------------------------------------------------------

            //var distinct = from employees in employees1
              //             where employees.empName.Distinct();       
//--------------------------------------------------------------------------------------------------------------------------------------------        
        
        }
        private static IList<Employee> GetEmployees()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sql_conn = new SqlConnection(objConn))
            {

                var sql = "SELECT *FROM  Employees_11_Dec";
                using (SqlCommand sql_cmd = new SqlCommand(sql, sql_conn))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sql_cmd))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }

            IList<Employee> employees = new List<Employee>();
            foreach (DataRow row in dataTable.Rows)
            {
                //Employee employee = new Employee()
                var employee = new Employee()
                {
                    empId = int.Parse(row["empId"].ToString()),
                    empName = row["empName"].ToString(),
                    empMobileNumber = row["empMobileNumber"].ToString(),
                    empSalary = decimal.Parse(row["empSalary"].ToString()),
                    empDateOfJoining = DateTime.Parse(row["empDateOfJoining"].ToString()),
                    empPerformance = row["empPerformance"].ToString()
                };
                employees.Add(employee);
            }
            return employees;
        }
    }
}

