using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Assignment.Database;
namespace C_Assignment.Database;

class Methods
{
    static utility util=new utility();
    static SqlConnection con;
    static SqlDataReader sdr;
 public static void GetAllStudents()
    {
        con = util.getConnection();
        String query = "select * from students";
        SqlCommand sqlquery = new SqlCommand(query,con);
        sdr = sqlquery.ExecuteReader();

        while (sdr.Read())
        {
            Console.WriteLine($"{sdr["student_id"]}, {sdr["first_name"]},{sdr["last_name"]}," +
                $"{sdr["date_of_birth"]},{sdr["email"]}," +
                $"{sdr["phone_number"]} ");
        }
        con.Close();
    }
    public static void GetAllCourses()
    {
        con = util.getConnection();
        String query = "Select * from courses";
        SqlCommand sqlquery = new SqlCommand(query,con);
        sdr = sqlquery.ExecuteReader();
        while(sdr.Read())
        {
            Console.WriteLine($"{sdr["course_id"]},{sdr["course_name"]},{sdr["credits"]},{sdr["teacher_id"]}");
        }
        con.Close();
    }
    public static void GetAllEnrollments()
    {
        con =util.getConnection();
        String query = "Select * from enrollments";
        SqlCommand sqlquery = new SqlCommand(query, con);
        sdr = sqlquery.ExecuteReader();
        while (sdr.Read())
        {
            Console.WriteLine($"{sdr["enrollment_id"]},{sdr["student_id"]}" +
                $",{sdr["course_id"]},{sdr["enrollment_date"]}");
        }
        con.Close();
    }
    public static void GetAllTeachers()
    {
        con = util.getConnection();
        String query = "Select * from teacher";
        SqlCommand sqlquery = new SqlCommand(query, con);
        sdr = sqlquery.ExecuteReader();
        while (sdr.Read())
        {
            Console.WriteLine($"{sdr["teacher_id"]},{sdr["first_name"]}" +
                $",{sdr["last_name"]},{sdr["email"]}");
        }
        con.Close();
    }
    public static void GetAllPayments()
    {
        con = util.getConnection();
        String query = "Select * from payments";
        SqlCommand sqlquery = new SqlCommand(query, con);
        sdr = sqlquery.ExecuteReader();
        while (sdr.Read())
        {
            Console.WriteLine($"{sdr["payment_id"]},{sdr["student_id"]}" +
                $",{sdr["amount"]},{sdr["payment_date"]}");
        }
        con.Close();
    }
   // public void InsertNewData
}

