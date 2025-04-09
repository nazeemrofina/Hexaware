using C__CodingChallenge.Service;
using C__CodingChallenge.Model;
using System.Transactions;

namespace C__CodingChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utility util = new Utility();
            util.checkConnection();

            Methods method = new Methods();

            Console.WriteLine("Enter the operation to perform 1-ListAllDetails 2-Donation 3-Adoptionevent");
            int no = Convert.ToInt32(Console.ReadLine());

            switch (no)
            {
                case 1:
                     method.ListAllPets();
                    break;
                case 2:
                    method.DonationRecording();
                    break;
                case 3:
                    method.AdoptionEventManagement();
                    break;
                default:
                    break;
            }

           
          

        }
    }
}
