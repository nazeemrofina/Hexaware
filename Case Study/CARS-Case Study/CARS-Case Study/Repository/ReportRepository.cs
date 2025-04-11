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
        
    class ReportRepository : IReportRepository
    {
        SqlConnection con;
        utilityclass util = new utilityclass();
        public int AddReport(Report report)
        {
            try
            {
                using (con=util.getConnection())
                {
                    string query = "insert into Reports (IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status) values (@incidentId, @reportingOfficer, @reportDate, @reportDetails, @status)";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@incidentId", report.IncidentId);
                    sqlquery.Parameters.AddWithValue("@reportingOfficer", report.ReportingOfficer);
                    sqlquery.Parameters.AddWithValue("@reportDate", report.ReportDate);
                    sqlquery.Parameters.AddWithValue("@reportDetails", report.ReportDetails);
                    sqlquery.Parameters.AddWithValue("@status", report.Status);
                    return sqlquery.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public int UpdateReport(int reportId, string status)
        {
            try
            {
                using (con=util.getConnection())
                {
                    string query = "update Reports set Status = @status WHERE ReportID = @reportId";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@status", status);
                    sqlquery.Parameters.AddWithValue("@reportId", reportId);
                    return sqlquery.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public Report GetReportForCase(int reportId)
        {
            Report report = new Report();
            using (con = util.getConnection())
            {
                try
                {
                   string query = "select * from Reports where ReportID = @reportId";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@reportId", reportId);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    {
                        if (reader.Read())
                        {
                            report.ReportId = (int)reader["ReportID"];
                            report.IncidentId = (int)reader["IncidentID"];
                            report.ReportingOfficer = (int)reader["ReportingOfficer"];
                            report.ReportDate = (DateTime)reader["ReportDate"];
                            report.ReportDetails = (string)reader["ReportDetails"];
                            report.Status = (string)reader["Status"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return report;
        }

        public int GetReportById(int reportId)
        {
            int reportFromDB = -1;
            using (con=util.getConnection())
            {
                try
                {
                    string query = "select ReportID from Reports where ReportID = @reportId";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@reportId", reportId);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                        if (reader.Read())
                        {
                            reportFromDB = (int)reader["ReportID"];
                        }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return reportFromDB;
        }

        public List<Report> GetAllReports()
        {
            List<Report> reports = new List<Report>();
            using (con=util.getConnection())
            {
                try
                {
                   string query = "select * from Reports";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            Report report = new Report();

                            report.ReportId = (int)reader["ReportID"];
                            report.IncidentId = (int)reader["IncidentID"];
                            report.ReportingOfficer = (int)reader["ReportingOfficer"];
                            report.ReportDate = (DateTime)reader["ReportDate"];
                            report.ReportDetails = (string)reader["ReportDetails"];
                            report.Status = (string)reader["Status"];

                            reports.Add(report);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return reports;
        }
    }
}
