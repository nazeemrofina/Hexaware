using CARS_Case_Study.Models;
using CARS_Case_Study.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.Repository
{
    class VictimRepository : IVictimRepository
    {
        SqlConnection con;
        utilityclass util = new utilityclass();
        public int AddVictim(Victim victim)
        {
            try
            {
                con = util.getConnection();
                {

                    string query = "insert into Victims (IncidentID, FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address) values (@incidentId, @firstName, @lastName, @dateOfBirth, @gender, @phoneNumber, @address)";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@incidentId", victim.IncidentId);
                    sqlquery.Parameters.AddWithValue("@firstName", victim.FirstName);
                    sqlquery.Parameters.AddWithValue("@lastName", victim.LastName);
                    sqlquery.Parameters.AddWithValue("@dateOfBirth", victim.DateOfBirth);
                    sqlquery.Parameters.AddWithValue("@gender", victim.Gender);
                    sqlquery.Parameters.AddWithValue("@phoneNumber", victim.PhoneNumber);
                    sqlquery.Parameters.AddWithValue("@address", victim.Address);
                    return sqlquery.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            return 0;
        }



        public List<Victim> GetVictimsByIncidentId(int incidentId)
        {
            List<Victim> victims = new List<Victim>();
            con = util.getConnection();
            {
                try
                {
                  string query = $"select * from Victims where IncidentID = {incidentId}";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            Victim victim = new Victim();

                            victim.VictimId = (int)reader["VictimID"];
                            victim.FirstName = (string)reader["FirstName"];
                            victim.LastName = (string)reader["LastName"];
                            victim.DateOfBirth = (DateTime)reader["DateOfBirth"];
                            victim.Gender = (string)reader["Gender"];
                            victim.PhoneNumber = (long)reader["PhoneNumber"];
                            victim.Address = (string)reader["Address"];

                            victims.Add(victim);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return victims;
        }
    }
}
