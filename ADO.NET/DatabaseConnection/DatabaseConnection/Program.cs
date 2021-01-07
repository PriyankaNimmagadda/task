using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnection
{

   

    class Program
    {
        //SqlConnection1 sql = new SqlConnection1();
        //static string _strconn = string.Empty;
        public static void Main(string[] args)
        {



            //new SqlConnection1().Insert();

            //new SqlConnection1().Update();
            //new SqlConnection1().Update1();

            //new SqlConnection1().Delete();
            //new SqlConnection1().Delete1();

            //new SqlConnection1().Insert1();

            //new SqlConnection1().ReadAllRecords();

            //new SqlConnection1().ReadEmpById();

            //  new SqlConnection1().ReadEmpByName();

            // new SqlConnection1().GetMultipleRecords();

            //new SqlConnection1().DataSet1();

            // new SqlConnection1().Transactions1();

            //_strconn = ConfigurationManager.ConnectionStrings["_strconn"].ConnectionString;

            //Insert();
        }
        //private static void Insert()
        //{
        //    using(SqlConnection sql_conn=new SqlConnection(_strconn))
        //    {
        //        using(SqlCommand sql_cmd=new SqlCommand("Insert_Employee", sql_conn))
        //        {
        //            SqlParameter[] prms = new SqlParameter[6];
        //            prms[0] = new SqlParameter("@empId", SqlDbType.Int);
        //            prms[0].Value = 10;
        //            prms[1] = new SqlParameter("@empName", SqlDbType.VarChar,30);
        //            prms[1].Value = "priyanka";
        //            prms[2] = new SqlParameter("@empMobileNumber", SqlDbType.BigInt);
        //            prms[2].Value = 7801036508;
        //            prms[3] = new SqlParameter("@empSalary", SqlDbType.Money);
        //            prms[3].Value = 19000;
        //            prms[4] = new SqlParameter("@empDateOfJoining", SqlDbType.Date);
        //            prms[4].Value = DateTime.Now;
        //            prms[5] = new SqlParameter("@empPerformane", SqlDbType.Text);
        //            prms[5].Value = 'G';
        //            sql_cmd.Parameters.AddRange(prms);
        //            sql_cmd.CommandType = CommandType.StoredProcedure;
        //            sql_conn.Open();
        //            sql_cmd.ExecuteNonQuery();
        //            sql_conn.Close();

        //        }
        //    }
        //}
    }
}
