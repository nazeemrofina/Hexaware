using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CARS_Case_Study.Utility
{
    public class utilityclass
    {
        SqlConnection con;


        public SqlConnection getConnection()
        {
            //con = new SqlConnection("data source = DESKTOP-UJRKO6I\\SQLEXPRESS;database = CARSDB;trusted_connection = true;");
            // con.Open();
            string connectionString = DBProperty.GetProperty("ConnectionString");
        //    Console.WriteLine(connectionString);
            con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                //  Console.WriteLine("Success");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return con;
        }
        public void checkConnection()
        {
            try
            {
                using (con = getConnection())
                {
                    Console.WriteLine("Successfully Connected");
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
