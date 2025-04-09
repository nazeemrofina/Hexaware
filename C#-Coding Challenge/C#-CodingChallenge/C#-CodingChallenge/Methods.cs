using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__CodingChallenge.Service;
using C__CodingChallenge.Exceptions;

namespace C__CodingChallenge
{
    class Methods
    {
        SqlDataReader sdr;
        SqlConnection con;
        Utility util = new Utility();
        SqlDataReader sdr2;
        public void ListAllPets()
        {
            PetShelter petShelter = new PetShelter();
            petShelter.AvilablePets();
        }
        public void DonationRecording()
        {
            Console.WriteLine("Give inputs of all the details of the donor");
            Console.WriteLine("Enter DonorName : ");
            string DonorName = Console.ReadLine();
            Console.WriteLine("Enter DonationType(cash/item) : ");
            string DonationType = Console.ReadLine();
            Console.WriteLine("Enter DonationAmount : ");
            Decimal DonationAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter DonationItem : ");
            string DonationItem = Console.ReadLine();
            Console.WriteLine("Enter ShelterId : ");
            int shelterid = int.Parse(Console.ReadLine());
            Exceptioncode.CheckPayment(DonationAmount);
            if (DonationType == "cash")
            {
                CashDonationClass cashdonation = new CashDonationClass(DateTime.Now.Date, DonorName, "amount", DonationAmount, shelterid);
                cashdonation.RecordDonation();
            }
            //else if (DonationType == "item")
            //{
            //    ItemDonationClass itemdonation = new ItemDonationClass(DateTime.Now.Date,item, DonationItem, DonorName);
            //}

        }
        public void AdoptionEventManagement()
        {
            adoptionEventClass aec = new adoptionEventClass();
            int number= aec.adoptioneventrecord();
            Console.WriteLine(number);
         //   int eventid = 0;

         

            Console.WriteLine("Give inputs of all the details of the Participant");
            Console.WriteLine("Enter ParticipantId : ");
            int ParticipantId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter ParticipantName : ");
            string ParticipantName = Console.ReadLine();
            Console.WriteLine("Enter ParticipantTyoe : ");
            string ParticipantType = (Console.ReadLine());

            try
            {
                con = util.getConnection();
                String query = "insert into Participants values(@ParticipantId,@ParticipantName,@ParticipantType,@eventid)";
                SqlCommand sqlquery = new SqlCommand(query, con);
                sqlquery.Parameters.AddWithValue("ParticipantId", ++ParticipantId);
                sqlquery.Parameters.AddWithValue("ParticipantName", ParticipantName);
                sqlquery.Parameters.AddWithValue("ParticipantType", ParticipantType);
                sqlquery.Parameters.AddWithValue("eventid", number);

                int rowsAffected = sqlquery.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Successfully Inserted Participant");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
        public void RecordParticipant(int eventid)
        {
            Console.WriteLine(eventid);


        }
    }
    }

