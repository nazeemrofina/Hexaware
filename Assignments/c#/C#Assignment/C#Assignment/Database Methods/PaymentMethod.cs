using C_Assignment.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Assignment.Database_Methods
{
    class PaymentMethod
    {

        static SqlConnection con;
        static SqlCommand sdr;
        static utility util = new utility();
        public static void InsertIntoPayments(int Payment_id,int  student_id,float amount,DateTime paymentdate )
        {
        //    Console.WriteLine("Enter Payment ID  ");
        //    int Payment_id = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Enter Student ID  ");
        //    int student_id = int.Parse((Console.ReadLine()));
        //    Console.WriteLine("Enter amount  ");
        //    float amount = float.Parse((Console.ReadLine()));
        //    Console.WriteLine("Enter Date of payment :");
        //    DateTime paymentdate = DateTime.Parse((Console.ReadLine()));




            try
            {
                con = util.getConnection();
                String query = "INSERT INTO Payments(Payment_id,student_id,amount,payment_date) VALUES(@Payment_id,@student_id,@amount,@payment_date) ";
                SqlCommand sqlquery = new SqlCommand(query, con);
                sqlquery.Parameters.AddWithValue("Payment_id", Payment_id);
                sqlquery.Parameters.AddWithValue("student_id", student_id);
                sqlquery.Parameters.AddWithValue("amount", amount);
                sqlquery.Parameters.AddWithValue("payment_date", paymentdate);


                int rowsAffected = sqlquery.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Payment Successfully Inserted ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            con.Close();

        }
    }
}
