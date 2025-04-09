using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__CodingChallenge.Service
{
    class adoptionEventClass
    {
        List<Iadoptable> Participants;
        SqlConnection con;
        SqlDataReader sdr;
        Utility util = new Utility();
        public void HostEvent()
        {

        }
        public void RegParticipants(Iadoptable perticipant)
        {
            Participants.Add(perticipant);
        }
        public SqlDataReader adoptioneventrecord()
        {
            con = util.getConnection();
            String query = "select * from adoptionevents where eventdate>@eventdate";
            SqlCommand sqlquery = new SqlCommand(query, con);
            sqlquery.Parameters.AddWithValue("eventdate", DateTime.Now.Date);
            sdr = sqlquery.ExecuteReader();

          //  Console.WriteLine($"Do you want to register for {sdr["eventname"]}");
            while (sdr.Read())
            {
                Console.WriteLine("-------------The ForthComing Events Are-------------");
                Console.WriteLine($"{sdr["eventid"]}, {sdr["eventname"]},{sdr["eventdate"]}," +
                    $"{sdr["eventlocation"]} ");

            }
            con.Close();
            return sdr;
        }
    }
}
