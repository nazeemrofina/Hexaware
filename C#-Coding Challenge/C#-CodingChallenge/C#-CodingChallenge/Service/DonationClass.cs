using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__CodingChallenge.Service
{
    abstract class DonationClass
    {
        public string donorName { get; set; }
        public decimal amount { get; set; }
        public static int donationid=2006;
        public DonationClass(string donorName, decimal amount )
        {
            this.donorName = donorName;
            this.amount = amount;
        }
        public DonationClass(string donorName)
        {
            this.donorName = donorName;
         
        }
        public abstract void RecordDonation();
    }
}
