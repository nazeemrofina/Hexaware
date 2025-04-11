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
    class SuspectRepository:ISuspectRepository
    {
        SqlConnection con;
        utilityclass util = new utilityclass();
        public int AddSuspect(Suspect suspect)
        {
            try
            {
                con = util.getConnection();
                {
                   
                   string query = "insert into suspects (IncidentID, FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Address) values (@incidentId, @firstName, @lastName, @dateOfBirth, @gender, @phoneNumber, @address)";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@incidentId", suspect.IncidentId);
                    sqlquery.Parameters.AddWithValue("@firstName", suspect.FirstName);
                    sqlquery.Parameters.AddWithValue("@lastName", suspect.LastName);
                    sqlquery.Parameters.AddWithValue("@dateOfBirth", suspect.DateOfBirth);
                    sqlquery.Parameters.AddWithValue("@gender", suspect.Gender);
                    sqlquery.Parameters.AddWithValue("@phoneNumber", suspect.PhoneNumber);
                    sqlquery.Parameters.AddWithValue("@address", suspect.Address);
                    return sqlquery.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public List<Suspect> GetSuspectsByIncidentId(int incidentId)
        {
            List<Suspect> suspects = new List<Suspect>();
            con = util.getConnection();
            {
                try
                {
                   string query = $"select * from Suspects where IncidentID = {incidentId}";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            Suspect suspect = new Suspect();

                            suspect.SuspectId = (int)reader["SuspectID"];
                            suspect.FirstName = (string)reader["FirstName"];
                            suspect.LastName = (string)reader["LastName"];
                            suspect.DateOfBirth = (DateTime)reader["DateOfBirth"];
                            suspect.Gender = (string)reader["Gender"];
                            suspect.PhoneNumber = (long)reader["PhoneNumber"];
                            suspect.Address = (string)reader["Address"];

                            suspects.Add(suspect);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return suspects;
        }
    }
}
