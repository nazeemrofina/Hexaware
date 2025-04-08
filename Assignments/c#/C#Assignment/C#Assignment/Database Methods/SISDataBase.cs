using C_Assignment.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Assignment.Database_Methods
{
    class SISDataBase
    {
        static SqlConnection con;
        static SqlDataReader sdr;
        utility util = new utility();
        static int count = 27574;
        public  void InsertAndEnrollStudent()
        {
             con = util.getConnection();
            Console.WriteLine("STUDENT INSERTION AND ENROLLMENTS");
             int student_id=StudentsMethod.InsertIntoStudents();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter the name of the course you want to enroll");
                string Course_Name=Console.ReadLine();

                StringBuilder query = new StringBuilder();
                query.Append("SELECT COURSE_ID FROM COURSES WHERE COURSE_NAME=@COURSE_NAME");

                SqlCommand sqlquery = new SqlCommand(query.ToString(), con);
                sqlquery.Parameters.AddWithValue("COURSE_NAME", Course_Name);
                sdr = sqlquery.ExecuteReader();
                int course_id=0;
                while (sdr.Read())
                {
                     course_id = Convert.ToInt32(sdr["course_id"]);
                     
                }
                sdr.Close();
                Console.WriteLine("Enter Enrollment id: ");
                int enrollmentid = Convert.ToInt32(Console.ReadLine());
               
                EnrollmentMethods.InsertIntoEnrollments(student_id,enrollmentid,DateTime.Now.Date, course_id);
                Console.WriteLine("Do You Want to Enroll More Course True Or False ");
                exit= Convert.ToBoolean(Console.ReadLine()); ;
                Methods.GetAllStudents();
                con.Close();


            }

        }

        public void TeacherAssignment()
        {

            try
            {
                Console.WriteLine("INSERTING THE NEW TEACHER INTO THE TEACHER TABLE AND ASSIGNING HIM TO THE COURSE");
                int teacherid = TeacherMethod.InsertIntoTeachers();
                Console.WriteLine("Enter The Name Of The Course To Be Assigned To The Teachers");
                string course_name = Console.ReadLine();
                con = util.getConnection();
                CoursesMethod.updateCourses(course_name, teacherid);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            con.Close();
        }
        public void PaymetRecording()
        {
            bool ans = false;
          
            con = util.getConnection();
            while (!ans)
            {
                Console.WriteLine("MAKING A PAYMENT");
                Console.WriteLine("Enter the ID of the Student to make the payment");
                int student_id = int.Parse(Console.ReadLine());
                string query = "SELECT FIRST_NAME,LAST_NAME FROM STUDENTS WHERE STUDENT_ID=@STUDENT_ID";
                SqlCommand sqlquery = new SqlCommand(query, con);
                sqlquery.Parameters.AddWithValue("STUDENT_ID", student_id);
                sdr = sqlquery.ExecuteReader();
                String name = "";
                while (sdr.Read())
                {
                    name = sdr["first_name"] + " " + sdr["last_name"];
                    
                }
                sdr.Close();
                Console.WriteLine($"Are you sure you want to make payment to {name} true/false");
                 ans = Convert.ToBoolean(Console.ReadLine());
                if (ans)
                {
                    Console.WriteLine("Enter the amount");
                    float amount = Convert.ToSingle(Console.ReadLine());
                    PaymentMethod.InsertIntoPayments(++count, student_id, amount, DateTime.Now.Date);
                    Console.WriteLine("PAYMENT SUCCESSFULL");
                }
                else
                {
                    ans = false;
                }
            }
            con.Close();
        }
        public void EnrollmentReportForSpecificCourse()
        {
            con = util.getConnection();
           
            try
            {
                Console.WriteLine("ENROLLMENT REPORT FOR A SPECIFIC COURSE");
                Console.WriteLine("Enter the course name to generate report for ");
                string course_name = Console.ReadLine();
                string query1 = "SELECT COURSE_ID FROM COURSES WHERE COURSE_NAME=@COURSENAME";
                SqlCommand sqlquery1 = new SqlCommand(query1, con);
                sqlquery1.Parameters.AddWithValue("COURSENAME", course_name);
                sdr = sqlquery1.ExecuteReader();
                int course_id = 0;
                while (sdr.Read())
                {
                    course_id = Convert.ToInt32(sdr["course_id"]);
                }

                sdr.Close();
                SelectStudent(course_id);
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            con.Close();

        }

        public void SelectStudent(int course_id)
        {
            con = util.getConnection();
            //List<int> AllStudentsFromSpecificEnrollment = new List<int>();
            try
            {
                string query = "SELECT * FROM STUDENTS S JOIN ENROLLMENTS E ON S.STUDENT_ID=E.STUDENT_ID" +
                    " WHERE COURSE_ID=@COURSE_ID";
                SqlCommand sqlquery= new SqlCommand(query, con);
                sqlquery.Parameters.AddWithValue("COURSE_ID", course_id);
                sdr = sqlquery.ExecuteReader();
                while (sdr.Read())
                {
                  Console.WriteLine($"{sdr["student_id"]},{sdr["first_name"]},{sdr["last_name"]},{sdr["date_of_birth"]}, " +
                      $"{sdr["email"]}, {sdr["phone_number"]}");

                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            sdr.Close();
           // ToaccessStudentDetails(AllStudentsFromSpecificEnrollment);
        }
      
       
    }
}
