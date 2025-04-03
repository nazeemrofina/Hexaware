using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


//1.You are working for ABC Bank Ltd.  on the funds Transfer module.
//You need to handle the situation when the customer wishes to transfer more money than he has in his/her account 
namespace Assignment3
{
    class Program4
    {
        static void Main(String[] args)
        {
            BankDetails bd = new BankDetails(1500);
            try {
                bd.fundtransfer();
            }
            catch(TransactionException e)
            {
                Console.WriteLine(e.Message);
            }
         }
    }
    class BankDetails
    {
        string? Name = "Rofina";
        int Bank_Balance = 100000;
        int Fund_Transfer;

        public BankDetails(int Fund_Transfer)
        {
            this.Fund_Transfer = Fund_Transfer;
        }

        public void fundtransfer()
        {
           
                if (Fund_Transfer > Bank_Balance)
                {
                    throw (new TransactionException("Invalid Balance"));
                }
                else
                {
                    Bank_Balance = Bank_Balance - Fund_Transfer;
                    Console.WriteLine($"Transaction Successful -Current Bank Balance is {Bank_Balance}");
                }
            
            
        }
    }
    public class TransactionException:Exception
    {
        public  TransactionException(string msg):base(msg) { }
    }

}
