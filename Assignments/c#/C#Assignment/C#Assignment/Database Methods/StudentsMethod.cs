using C_Assignment.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace C_Assignment.Database_Methods
{
    class StudentsMethod
    {
        static SqlConnection con;
        static SqlCommand sdr;
        static utility util = new utility();
        public static int InsertIntoStudents()
        {
            
            Console.WriteLine("Enter Student_id:  ");
            int student_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter First Name:  ");
            string firstname = (Console.ReadLine());
            Console.WriteLine("Enter Last Name:  ");
            string lastname = (Console.ReadLine());
            Console.WriteLine("Enter DOB(yyyy-mm-dd):  ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter email:  ");
            string email = (Console.ReadLine());
            Console.WriteLine("Enter phone_number  ");
            decimal phone_number = decimal.Parse(Console.ReadLine());



            try
            {
                con = util.getConnection();
                String query = "INSERT INTO STUDENTS(student_id,first_name,last_name,date_of_birth,email,phone_number) VALUES(@empid,@efirstname,@elastname,@dob,@email,@phonenumber) ";
                SqlCommand sqlquery = new SqlCommand(query, con);
                sqlquery.Parameters.AddWithValue("empid", student_id);
                sqlquery.Parameters.AddWithValue("efirstname", firstname);
                sqlquery.Parameters.AddWithValue("elastname", lastname);
                sqlquery.Parameters.AddWithValue("dob", dob);
                sqlquery.Parameters.AddWithValue("email", email);
                sqlquery.Parameters.AddWithValue("phonenumber", phone_number);

                int rowsAffected = sqlquery.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Successfully Inserted");
                    con.Close();
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return student_id;

        }
        public static void UpdateDataIntoStudents()
        {
           
        
            Console.WriteLine("Enter Student_id to Update:   ");
            int empid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter First Name:  ");
            string firstname = (Console.ReadLine());
            Console.WriteLine("Enter Last Name:  ");
            string lastname = (Console.ReadLine());
            Console.WriteLine("Enter DOB(yyyy-mm-dd):  ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter email:  ");
            string email = (Console.ReadLine());
            Console.WriteLine("Enter phone_number  ");
            decimal phone_number = decimal.Parse(Console.ReadLine());



            try
            {
                con = util.getConnection();
                String query = "UPDATE  STUDENTS SET STUDENT_ID=@studentid,FIRST_NAME=@firstname,LAST_NAME=@lastname,DATE_OF_BIRTH=@dob,EMAIL=@email" +
                    ",PHONE_NUMBER=@phonenumber WHERE STUDENT_ID=@studentid";
                SqlCommand sqlquery = new SqlCommand(query, con);
                sqlquery.Parameters.AddWithValue("studentid", empid);
                sqlquery.Parameters.AddWithValue("firstname", firstname);
                sqlquery.Parameters.AddWithValue("lastname", lastname);
                sqlquery.Parameters.AddWithValue("dob", dob);
                sqlquery.Parameters.AddWithValue("email", email);
                sqlquery.Parameters.AddWithValue("phonenumber", phone_number);

                int rowsAffected = sqlquery.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Student Details Successfully Updated");
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void EnrollStudenInACourset()
        {
          
        }
      
    }
}

