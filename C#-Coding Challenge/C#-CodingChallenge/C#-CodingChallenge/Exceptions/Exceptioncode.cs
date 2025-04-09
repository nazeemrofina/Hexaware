using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__CodingChallenge.Model;

namespace C__CodingChallenge.Exceptions
{
    public class Exceptioncode
    {
        public static void CheckAge(int age)
        {
            if (age > 0)
            {
                return;
            }
            else
            {
                throw (new InvalidPetAgeHandling("Invalid Pet Age"));
            }
        }
        public static void CheckPayment(decimal amount)
        {
            if (amount <= 10)
            {
                throw (new InsufficientFundsException("Invalid amount"));
            }
        }
        //public static void CheckPayment(decimal amount)
        //{
        //    if (amount <= 10)
        //    {
        //        throw (new InsufficientFundsException("Invalid amount"));
        //    }
        //}
        //public static void CheckPayment(decimal amount)
        //{
        //    if (amount <= 10)
        //    {
        //        throw (new InsufficientFundsException("Invalid amount"));
        //    }
        //}

    }
}
