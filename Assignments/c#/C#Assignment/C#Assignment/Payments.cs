using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Assignment
{
    class Payments
    {
        public int PaymentID { get; set; }
        public Students StudentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payments(int paymentID, Students studentID, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            StudentID = studentID;
            Amount = amount;
            PaymentDate = paymentDate;
        }

        public Students GetStudent()
        {
            return StudentID;
        }

        public decimal GetPaymentAmount()
        {
            return Amount;
        }
        public DateTime GetPaymentDate()
        {
            return PaymentDate;
        }

    }
}
