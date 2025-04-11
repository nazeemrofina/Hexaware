using CARS_Case_Study.Models;
using CARS_Case_Study.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CARS_Case_Study.ExceptionClass;
using System.Data.Common;

namespace CARS_Case_Study.Repository
{
    public class IncidentRepository: IIncidentRepository
    {
        SqlConnection con;
        utilityclass util = new utilityclass();
     
        public List<Incident> GetAllIncidents()
        {
            List<Incident> incidents = new List<Incident>();
            using (con = util.getConnection())
            {
                try
                {
                  
                    string query = "select * from Incidents";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            Incident incident = new Incident();

                            incident.IncidentId = (int)reader["IncidentID"];
                            incident.IncidentType = (string)reader["IncidentType"];
                            incident.IncidentDate = (DateTime)reader["IncidentDate"];
                            incident.Location = (string)reader["Location"];
                            incident.Description = (string)reader["Description"];
                            incident.Status = (string)reader["Status"];
                            incident.AgencyId = (int)reader["AgencyID"];

                            incidents.Add(incident);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                con.Close();
            }
            return incidents;
        }
        public int AddIncident(Incident incident)
        {
            try
            {
                using (con = util.getConnection())
            {
                //con.Open();
                

                    string query = "insert into Incidents (IncidentType, IncidentDate, Location, Description, AgencyID) OUTPUT INSERTED.IncidentID values(@incidentType, @incidentDate, @location, @description, @agencyId)";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@incidentType", incident.IncidentType);
                    sqlquery.Parameters.AddWithValue("@incidentDate", incident.IncidentDate);
                    sqlquery.Parameters.AddWithValue("@location", incident.Location);
                    sqlquery.Parameters.AddWithValue("@description", incident.Description);
                    sqlquery.Parameters.AddWithValue("@agencyId", incident.AgencyId);
                    return (int)sqlquery.ExecuteScalar();
                
            }
        }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public int UpdateIncidentStatus(int incidentId, string status)
        {
            try
            {
                using (con = util.getConnection()) { 
                   string query = "update Incidents set Status = @status where IncidentID = @incidentId";

                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@incidentId", incidentId);
                    sqlquery.Parameters.AddWithValue("@status", status);
                    return sqlquery.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public int GetIncidentById(int incidentId)
        {
            int incidentIdFromDB = -1;
            using (con=util.getConnection())
            {
                try
                {
                     string query = "select IncidentID from Incidents where IncidentId = @incidentId";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@incidentId", incidentId);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    
                        if (reader.Read())
                        {
                            incidentIdFromDB = (int)reader["IncidentID"];
                        }
                    if (incidentIdFromDB == -1)
                    {
                        throw (new IncidentNumberNotFoundException($"Incident with the ID{incidentId} not found "));
                    }
                    
                }
                catch(IncidentNumberNotFoundException e)
                {
                     Console.WriteLine(e.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            return incidentIdFromDB;
        }
        public Incident GetIncidentForCaseReport(int incidentId)
        {
            Incident incidentFetched = new Incident();
            using (con = util.getConnection())
            {
                try
                {
                   
                    string query = "select * from Incidents where IncidentId = @incidentId";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@incidentId", incidentId);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            incidentFetched.IncidentId = (int)reader["IncidentID"];
                            incidentFetched.IncidentType = (string)reader["IncidentType"];
                            incidentFetched.IncidentDate = (DateTime)reader["IncidentDate"];
                            incidentFetched.Location = (string)reader["Location"];
                            incidentFetched.Description = (string)reader["Description"];
                            incidentFetched.Status = (string)reader["Status"];
                            incidentFetched.AgencyId = (int)reader["AgencyID"];
                        }
                    }
                    else
                    {
                        throw (new IncidentNumberNotFoundException($"Incident with the ID{incidentId} not found "));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return incidentFetched;
        }
        public List<Incident> GetIncidentInDateRange(DateTime startDate, DateTime endDate)
        {
            List<Incident> incidents = new List<Incident>();
            using (con = util.getConnection())
            {
                try
                {
                   string query= $"select * from Incidents where IncidentDate between '{startDate}' and '{endDate}'";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            Incident incident = new Incident();

                            incident.IncidentId = (int)reader["IncidentID"];
                            incident.IncidentType = (string)reader["IncidentType"];
                            incident.IncidentDate = (DateTime)reader["IncidentDate"];
                            incident.Location = (string)reader["Location"];
                            incident.Description = (string)reader["Description"];
                            incident.Status = (string)reader["Status"];
                            incident.AgencyId = (int)reader["AgencyID"];

                            incidents.Add(incident);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return incidents;
        }
        public List<Incident> GetIncidentsByType(string incidentType)
        {
            List<Incident> incidents = new List<Incident>();
            using (con=util.getConnection())
            {
                try
                {
                   string query = $"select * from Incidents where IncidentType = '{incidentType}'";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            Incident incident = new Incident();

                            incident.IncidentId = (int)reader["IncidentID"];
                            incident.IncidentType = (string)reader["IncidentType"];
                            incident.IncidentDate = (DateTime)reader["IncidentDate"];
                            incident.Location = (string)reader["Location"];
                            incident.Description = (string)reader["Description"];
                            incident.Status = (string)reader["Status"];
                            incident.AgencyId = (int)reader["AgencyID"];

                            incidents.Add(incident);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return incidents;
        }





    }
}
