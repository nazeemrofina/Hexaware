using CARS_Case_Study.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CARS_Case_Study.Utility;
namespace CARS_Case_Study.Repository
{
    class AgencyRepository:IAgencyRepository
    {
        SqlConnection con;
        utilityclass util = new utilityclass();
        public List<Agency> GetAllAgencies()
        {
            List<Agency> agencies = new List<Agency>();
           // con = util.getConnection();
            {
                try
                {
                    con = util.getConnection();
                   string query = "select * from LawEnforcementAgencies";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    while (reader.Read())
                    {
                        Agency agency = new Agency();

                        agency.AgencyId = (int)reader["AgencyID"];
                        agency.AgencyName = (string)reader["AgencyName"];
                        agency.Jurisdiction = (string)reader["Jurisdiction"];
                        agency.PhoneNumber = (long)(reader["PhoneNumber"]);
                        agency.Address = (string)reader["Address"];

                        agencies.Add(agency);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return agencies;
        }
        public Dictionary<int, string> GetAgenciesIdAndName()
        {
            Dictionary<int, string> agencies = new Dictionary<int, string>();
            con = util.getConnection();
            {
                try
                {
                   string query = "select AgencyID, AgencyName from LawEnforcementAgencies";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    while (reader.Read())
                    {
                        int agencyId = (int)reader["AgencyID"];
                        string agencyName = (string)reader["AgencyName"];

                        agencies.Add(agencyId, agencyName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return agencies;
        }
        public int AddAgency(Agency agency)
        {
            try
            {
                con = util.getConnection();
                {
                   
                   string query = "insert into LawEnforcementAgencies (AgencyName, Jurisdiction, PhoneNumber, Address) values(@agencyName, @jurisdiction, @phoneNumber, @address)";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@agencyName", agency.AgencyName);
                    sqlquery.Parameters.AddWithValue("@jurisdiction", agency.Jurisdiction);
                    sqlquery.Parameters.AddWithValue("@phoneNumber", agency.PhoneNumber);
                    sqlquery.Parameters.AddWithValue("@address", agency.Address);
                    return sqlquery.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public Agency GetAgencyById(int agencyId)
        {
            Agency agency = new Agency();
            con = util.getConnection();
            {
                try
                {
                   string query = "select * from LawEnforcementAgencies where AgencyID = @agencyId";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@agencyId", agencyId);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    {
                        if (reader.Read())
                        {
                            agency.AgencyId = (int)reader["AgencyID"];
                            agency.AgencyName = (string)reader["AgencyName"];
                            agency.Jurisdiction = (string)reader["Jurisdiction"];
                            agency.PhoneNumber = (long)(reader["PhoneNumber"]);
                            agency.Address = (string)reader["Address"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return agency;
        }
    }
}
