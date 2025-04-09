using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__CodingChallenge.Service
{
    class ItemDonationClass:DonationClass
    {
        public string ItemType { get; set; }
        public ItemDonationClass(DateTime  date,string itemType,string donorName):base(donorName)
        {
            this.ItemType = itemType;
        }
        public override void RecordDonation()
        {

        }
    }
}
