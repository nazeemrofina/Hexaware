using C_Assignment.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Assignment.Database_Methods
{
    class TeacherMethod
    {
        static SqlConnection con;
        static SqlCommand sdr;
        static utility util = new utility();
        public static int InsertIntoTeachers()
        {
            Console.WriteLine("Enter Teacher ID:  ");
            int teacherid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter First Name:  ");
            string firstname = (Console.ReadLine());
            Console.WriteLine("Enter Last Name:  ");
            string lastname = (Console.ReadLine());
            Console.WriteLine("Enter email:  ");
            string email = (Console.ReadLine());




            try
            {
                con = util.getConnection();
                String query = "INSERT INTO teacher(teacher_id,first_name,last_name,email) VALUES(@teacherid,@efirstname,@elastname,@email) ";
                SqlCommand sqlquery = new SqlCommand(query, con);
                sqlquery.Parameters.AddWithValue("teacherid", teacherid);
                sqlquery.Parameters.AddWithValue("efirstname", firstname);
                sqlquery.Parameters.AddWithValue("elastname", lastname);
                sqlquery.Parameters.AddWithValue("email", email);

                int rowsAffected = sqlquery.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Teacher Successfully Inserted");
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return teacherid;
        }
    }
}
