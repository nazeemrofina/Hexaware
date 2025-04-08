using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace C_Assignment.Database
{
    class utility
    {
         SqlConnection con;
       

        public  SqlConnection getConnection()
        {
            con = new SqlConnection("data source = DESKTOP-UJRKO6I\\SQLEXPRESS;database = sisdb;trusted_connection = true;");
            con.Open();
            return con;
        }
        public void checkConnection()
        {
            try
            {
                using (con=getConnection())
                {
                    Console.WriteLine("Suuccessfully Connected");
                    con.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
