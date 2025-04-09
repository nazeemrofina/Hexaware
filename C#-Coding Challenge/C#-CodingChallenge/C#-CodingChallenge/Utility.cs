using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace C__CodingChallenge
{
    class Utility
    {
        SqlConnection con;


        public SqlConnection getConnection()
        {
            con = new SqlConnection("data source = DESKTOP-UJRKO6I\\SQLEXPRESS;database = petpals;trusted_connection = true;");
            con.Open();
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
