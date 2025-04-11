using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CARS_Case_Study.Models;
using CARS_Case_Study.Utility;

namespace CARS_Case_Study.Repository
{
    class EvidenceRepository:IEvidenceRepository
    {
        SqlConnection con;
        utilityclass util = new utilityclass();
        public int AddEvidence(Evidence evidence)
        {
            try
            {
                using (con=util.getConnection())
                {
                    string query = "insert into Evidences (Description, LocationFound, IncidentID) values (@description, @locationFound, @incidentId)";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@description", evidence.Description);
                    sqlquery.Parameters.AddWithValue("@locationFound", evidence.LocationFound);
                    sqlquery.Parameters.AddWithValue("@incidentId", evidence.IncidentId);
                    return sqlquery.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public List<Evidence> GetEvidencesByIncidentId(int incidentId)
        {
            List<Evidence> evidences = new List<Evidence>();
            using (con=util.getConnection())
            {
                try
                {
                    string query = $"select * from Evidences where IncidentID = {incidentId}";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    
                        while (reader.Read())
                        {
                            Evidence evidence = new Evidence();

                            evidence.EvidenceId = (int)reader["EvidenceID"];
                            evidence.IncidentId = (int)reader["IncidentID"];
                            evidence.Description = (string)reader["Description"];
                            evidence.LocationFound = (string)reader["LocationFound"];

                            evidences.Add(evidence);
                        }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return evidences;
        }
    }
}
