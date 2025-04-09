using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__CodingChallenge.Service
{
    class CashDonationClass:DonationClass
    {
        SqlConnection con;
        SqlDataReader sdr;
        Utility util = new Utility();
        DateTime DonationDate { get; set; }
        string type;
        int shelterid;
        public CashDonationClass(DateTime donationDate,string donorName,string type,decimal amount,int shelterid):base(donorName,amount)
        {
            DonationDate = donationDate;
            this.type = type;
            this.shelterid = shelterid;
            //this.donorName = donorName;
            //this.amount = amount;
        }
        public override void RecordDonation()
        {
            try
            {
                con = util.getConnection();
                String query = "insert into donation(donationid,donorname,donationtype,donationamount,donationdate,shelterid)  values(@donationid,@donorname,@donationtype,@donationamount,@donationdate,@shelterid) ";
                SqlCommand sqlquery = new SqlCommand(query, con);
                sqlquery.Parameters.AddWithValue("donationid", ++donationid);
                sqlquery.Parameters.AddWithValue("donorname", donorName);
                sqlquery.Parameters.AddWithValue("donationtype", type);
                sqlquery.Parameters.AddWithValue("donationamount", amount);
                sqlquery.Parameters.AddWithValue("donationdate", DateTime.Now.Date);
                sqlquery.Parameters.AddWithValue("shelterid", shelterid);
                int rowsAffected = sqlquery.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Successfully Donated");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
