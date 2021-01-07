using DocumentFormat.OpenXml.Office2010.CustomUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseConnection
{
  public  class SqlConnection1
    {
        private string objConn;
        private SqlConnection objsql;
       // private string objconn;
//-------------------------------------------------------CONNECTION-----------------------------------------------------------------------------------------------
        public SqlConnection1()
        {
            objConn = "Data Source = 192.168.50.95; Initial Catalog = pnimmagadda; Integrated Security = True; Persist Security Info = False; Pooling = False; MultipleActiveResultSets = False; Encrypt = False; TrustServerCertificate = False";
            //objsql = new SqlConnection(objConn);
        }

//------------------------------------------------------------INSERT------------------------------------------------------------------------------------------
        public void Insert()
        {
            Console.WriteLine("inserting empName,empMobileNumber,empSalary");
            string empName = Console.ReadLine();
            string empMobileNumber = Console.ReadLine();
            string empSalary = Console.ReadLine();
            objsql.Open();
            SqlCommand sqlcommand = new SqlCommand("INSERT INTO Employees_11_Dec(empName,empMobileNumber,empSalary) VALUES(@empName,@empMobileNumber,@empSalary)", objsql);
            sqlcommand.Parameters.AddWithValue("@empName", empName);
            sqlcommand.Parameters.AddWithValue("@empMobileNumber", empMobileNumber);
            sqlcommand.Parameters.AddWithValue("@empSalary", empSalary);
            sqlcommand.ExecuteNonQuery();
            objsql.Close();
        }




//------------------------------------------------------------UPDATE------------------------------------------------------------------------------------------







        public void Update()
        {
            Console.WriteLine("update empName,empMobileNumber,empSalary");
            string empName = Console.ReadLine();
            string empMobileNumber = Console.ReadLine();
            string empSalary = Console.ReadLine();
            objsql.Open();
            SqlCommand sqlcommand = new SqlCommand("UPDATE  Employees_11_Dec SET empName=@empName,empMobileNumber=@empMobileNumber,empSalary=@empSalary where empId=11", objsql);
            sqlcommand.Parameters.AddWithValue("@empName", empName);
            sqlcommand.Parameters.AddWithValue("@empMobileNumber", empMobileNumber);
            sqlcommand.Parameters.AddWithValue("@empSalary", empSalary);
            sqlcommand.ExecuteNonQuery();
            objsql.Close();
        }
//-----------------------------------------------------------UPDATE1(USING)------------------------------------------------------------------------------------
          public void Update1()
        {
            using(SqlConnection sql_conn=new SqlConnection(objConn))
            {
                var sql = "update Employees_11_Dec set empName=@empName,empMobileNumber=@empMobileNumber,empSalary=@empSalary where empId=12";
                using (SqlCommand sql_cmd=new SqlCommand(sql,sql_conn))
                {
                    Console.WriteLine("enter the emName,empMobileNumber,empSalary");
                    string empName = Console.ReadLine();
                    int empMobileNumber = Convert.ToInt32(Console.ReadLine());
                    decimal empSalary =Convert.ToDecimal(Console.ReadLine());
                    sql_conn.Open();
                    sql_cmd.Parameters.AddWithValue("@empName", empName);
                    sql_cmd.Parameters.AddWithValue("@empMobileNumber", empMobileNumber);
                    sql_cmd.Parameters.AddWithValue("@empSalary", empSalary);
                    sql_cmd.ExecuteNonQuery();
                    sql_conn.Close();

                }
            }
        }

//-----------------------------------------------------------DELETE------------------------------------------------------------------------------------------


        public void Delete()
        {
            Console.WriteLine("enter which Name do u want to delete");
            int empId = Convert.ToInt32(Console.ReadLine());

            objsql.Open();
            SqlCommand sqlcommand = new SqlCommand("DELETE Employees_11_Dec  where empId=@empId", objsql);
            sqlcommand.Parameters.AddWithValue("@empId", empId);
            sqlcommand.ExecuteNonQuery();
            objsql.Close();

        }
//-------------------------------------------------------------DELETE(USING)----------------------------------------------------------------------------
         public void Delete1()
        {
            using(SqlConnection sql_conn=new SqlConnection(objConn))
            {
                var sql = "DELETE  Employees_11_Dec where empId=@empId";
                using (SqlCommand sql_cmd=new SqlCommand(sql,sql_conn))
                {
                    Console.WriteLine("enter empId which u want to delete");
                    int empId =Convert.ToInt32 (Console.ReadLine());
                    sql_conn.Open();
                    sql_cmd.Parameters.AddWithValue("@empId", empId);
                    sql_cmd.ExecuteNonQuery();
                    sql_conn.Close();

                }
            }
        }
 //------------------------------------------------------------INSERT(USING)------------------------------------------------------------------------------------------

        public void Insert1()
        {
            using(SqlConnection obj_sql=new SqlConnection(objConn))
            {
                using(SqlCommand sql_cmd=new SqlCommand("Insert_Employee",obj_sql))
                {
                    Console.WriteLine("enter empName,empMobileNumber,empsalary");
                   
                    string empName = Console.ReadLine();
                    var empMobileNumber = Console.ReadLine();
                    var empSalary = Console.ReadLine();
                   
                    obj_sql.Open();
                    sql_cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 
                    sql_cmd.Parameters.AddWithValue("@empName", empName);
                    sql_cmd.Parameters.AddWithValue("@empMobileNumber", empMobileNumber);
                    sql_cmd.Parameters.AddWithValue("@empSalary", empSalary);
                    
                    sql_cmd.ExecuteNonQuery();
                    obj_sql.Close();
                }
            }
        }
 //------------------------------------------------------------READ_RECORDS_DATAREADER------------------------------------------------------------------------------------------

        public void ReadAllRecords()
        {
            using (SqlConnection obj_sql_conn = new SqlConnection(objConn))
            {

                using (SqlCommand cmd = new SqlCommand("Insert_Employee", obj_sql_conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    obj_sql_conn.Open();
                    SqlDataReader myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        Console.WriteLine(myReader["empName"] + " " + myReader["empMobileNumber"] + " " + myReader["empSalary"]);
                    }
                    myReader.Close();
                    obj_sql_conn.Close();
                }


            }
        }
 //------------------------------------------------------------READ_BY_SINGLE_RECORD------------------------------------------------------------------------------------------

        public void ReadEmpById()
        {
            using(SqlConnection obj_sql_conn=new SqlConnection(objConn))
            {
                using(SqlCommand cmd=new SqlCommand("Insert_Employee",obj_sql_conn))
                {
                    Console.WriteLine("enter the empId");
                    int empId = Convert.ToInt32(Console.ReadLine());
                    cmd.Parameters.AddWithValue("@empId", empId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    obj_sql_conn.Open();
                    SqlDataReader myReader = cmd.ExecuteReader();
                    while(myReader.Read())
                    {
                        Console.WriteLine("{0},{1},{2}", myReader["empName"],myReader["empMobileNumber"], myReader["empSalary"]);
                    }
                    obj_sql_conn.Close();

                }
            }
        }
        //------------------------------------------------------------READ_BY_SINGLE_RECORD------------------------------------------------------------------------------------------

        public void ReadEmpByName()
        {
            using (SqlConnection sql_conn = new SqlConnection(objConn))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_Employee", sql_conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    Console.WriteLine("enter the empName");
                    string empName = Console.ReadLine();
                    cmd.Parameters.AddWithValue("@empName", empName);
                    sql_conn.Open();
                    SqlDataReader myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    {
                        Console.WriteLine("{0} \t{1} \tṇ{2}", myReader["empId"], myReader["empMobileNumber"], myReader["empSalary"]);
                    }
                    sql_conn.Close();
                }
            }
        }
 //-----------------------------------------------------------GET_MULTIPLE_RECORDS_DATAREADER------------------------------------------------------------------------------------------

        public void GetMultipleRecords()
        {
            using (SqlConnection sql_conn = new SqlConnection(objConn))
            {
                using (SqlCommand sql_cmd = new SqlCommand("Insert_Employee", sql_conn))
                {
                    sql_cmd.CommandType = CommandType.StoredProcedure;
                    sql_conn.Open();
                    using (SqlDataReader myReader = sql_cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (myReader.Read())
                        {
                            Console.WriteLine("{0} \t{1} \t{2}", myReader["empName"], myReader["empSalary"], myReader["empMobileNumber"]);

                        }
                        myReader.NextResult();
                        while (myReader.Read())
                        {
                            Console.WriteLine("{0} \t{1} \t{2}", myReader["deptId"], myReader["deptName"], myReader["empId"]);
                        }

                    }
                }
            }
        }
//-----------------------------------------------------------DATASET AND DATAADAPTER------------------------------------------------------------------------------------------

        public void DataSet1()
        {
            DataSet dataSet = new DataSet();
            using(SqlConnection sql_conn=new SqlConnection(objConn))
            {
                using(SqlCommand sql_cmd=new SqlCommand("Insert_Employee",sql_conn))
                {
                    sql_cmd.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter sda=new SqlDataAdapter(sql_cmd))
                    {
                        sda.Fill(dataSet);
                    }
                }
            }
            foreach(DataRow row in dataSet.Tables[1].Rows)
            {
                Console.WriteLine("{0} \t{1} \t{2}", row["deptId"], row["deptName"], row["empId"]);
            }
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine("{0} \t{1} \t{2}", row["empName"], row["empSalary"], row["empMobileNumber"]);
            }
        }
        //------------------------------------------------------------TRANSACTIONS-----------------------------------------------------------------------------------------

        public void Transactions1()
        {


            using (SqlConnection sql_conn = new SqlConnection(objConn))
            {
                sql_conn.Open();
                var transaction = sql_conn.BeginTransaction();
                try
                {


                    var sql = "INSERT INTO Employees_11_Dec (Empname,EmpMobileNumber,Empsalary) VALUES(@Empname,@EmpMobileNumber,@Empsalary)";
                    using (SqlCommand sql_cmd = new SqlCommand(sql, sql_conn))
                    {
                        //sql_cmd.Transaction = transaction;
                        sql_cmd.Parameters.AddWithValue("@Empname1", "priyankanimmagadda");
                        sql_cmd.Parameters.AddWithValue("@EmpMobileNumber", "7801036508");
                        sql_cmd.Parameters.AddWithValue("@Empsalary", "19000");
                        sql_cmd.Transaction = transaction;
                        sql_cmd.ExecuteNonQuery();

                    }
                    transaction.Commit();
                    sql_conn.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);

                }
                finally
                {
                    transaction.Dispose();
                }

            }
        }
    }





}

