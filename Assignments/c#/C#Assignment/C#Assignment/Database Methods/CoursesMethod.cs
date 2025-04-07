using C_Assignment.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Assignment.Database_Methods
{
    class CoursesMethod
    {
        static SqlConnection con;
        static SqlCommand sdr;
        static utility util = new utility();
        public static void InsertIntoCourses()
        {
            Console.WriteLine("Enter Course_id  ");
            int courseid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Course Name  ");
            string coursename = (Console.ReadLine());
            Console.WriteLine("Enter Course_credit  ");
            int coursecredit = int.Parse((Console.ReadLine()));
            Console.WriteLine("Enter teacher_id  ");
            int teacher_id = int.Parse((Console.ReadLine()));




            try
            {
                con = util.getConnection();
                String query = "INSERT INTO COURSES(course_id,course_name,credits,teacher_id) VALUES(@courseid,@coursename,@coursecredit,@teacherid) ";
                SqlCommand sqlquery = new SqlCommand(query, con);
                sqlquery.Parameters.AddWithValue("courseid", courseid);
                sqlquery.Parameters.AddWithValue("coursename", coursename);
                sqlquery.Parameters.AddWithValue("coursecredit", coursecredit);
                sqlquery.Parameters.AddWithValue("teacherid", teacher_id);


                int rowsAffected = sqlquery.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Course Successfully Inserted ");
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void updateCourses(string course_name,int teacher_id)
        {
            con = util.getConnection();
            try
            {
                string query = "UPDATE COURSES SET TEACHER_ID=@TEACHER_ID WHERE COURSE_NAME=@COURSENAME";
                SqlCommand sqlquery = new SqlCommand(query, con);
                sqlquery.Parameters.AddWithValue("TEACHER_ID", teacher_id);
                sqlquery.Parameters.AddWithValue("COURSENAME", course_name);
                int rowsAffected = sqlquery.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Successfully Assigned Teacher To Course {course_name}");
                }
                else
                {
                    Console.WriteLine("No Course To Assign Teacher");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
