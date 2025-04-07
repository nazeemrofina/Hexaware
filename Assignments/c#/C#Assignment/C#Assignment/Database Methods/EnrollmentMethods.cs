using C_Assignment.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Assignment.Database_Methods
{
    class EnrollmentMethods
    {

        static SqlConnection con;
        static SqlCommand sdr;
        static utility util = new utility();
        public static void InsertIntoEnrollments(int student_id,int enrollment_id,DateTime date,int course_id)
        {
            //Console.WriteLine("Enter Enrollment ID  ");
            //int enrollmentid = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter student ID  ");
            //int student_id =int.Parse((Console.ReadLine()));
            //Console.WriteLine("Enter Course ID  ");
            //int Course_id = int.Parse((Console.ReadLine()));
            //Console.WriteLine("Enter enrollment Date  ");
            //DateTime Enrollment_Date = DateTime.Parse((Console.ReadLine()));
            try
            {
                con = util.getConnection();
                String query = "INSERT INTO Enrollments(enrollment_id,student_id,course_id,enrollment_date) VALUES(@enrollment_id,@student_id,@course_id,@enrollment_date) ";
                SqlCommand sqlquery = new SqlCommand(query, con);
                sqlquery.Parameters.AddWithValue("enrollment_id", enrollment_id);
                sqlquery.Parameters.AddWithValue("student_id", student_id);
                sqlquery.Parameters.AddWithValue("course_id", course_id);
                sqlquery.Parameters.AddWithValue("enrollment_date", date);


                int rowsAffected = sqlquery.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Enrollment Successfully Inserted ");
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
