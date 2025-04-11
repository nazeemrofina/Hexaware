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
    class OfficerRepository:IOfficerRepository
    {
        SqlConnection con;
        SqlDataReader sdr;
        utilityclass util = new utilityclass();
        public List<Officer> GetAllOfficers()
        {
            List<Officer> officers = new List<Officer>();
            con = util.getConnection();
            {
                try
                {
                    string query = "select * from Officers";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    while (reader.Read())
                    {
                        Officer officer = new Officer();

                        officer.OfficerId = (int)reader["OfficerID"];
                        officer.FirstName = (string)reader["FirstName"];
                        officer.LastName = (string)reader["LastName"];
                        officer.BadgeNumber = (int)(reader["BadgeNumber"]);
                        officer.Rank = (string)(reader["Rank"]);
                        officer.PhoneNumber = (long)reader["PhoneNumber"];
                        officer.Address = (string)reader["Address"];
                        officer.AgencyId = (int)reader["AgencyID"];
                        officer.Role = (string)reader["Role"];

                        officers.Add(officer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return officers;
        }
        public int AddOfficer(Officer officer)
        {
            try
            {

                con = util.getConnection();
                {
                   
                     string query = "insert into Officers (FirstName, LastName, BadgeNumber, Rank, PhoneNumber, Address, AgencyID, Email, Password, Role) values (@firstName, @lastName, @badgeNumber, @rank, @phoneNumber, @address, @agencyId, @email, @password, @role)";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@firstName", officer.FirstName);
                    sqlquery.Parameters.AddWithValue("@lastName", officer.LastName);
                    sqlquery.Parameters.AddWithValue("@badgeNumber", officer.BadgeNumber);
                    sqlquery.Parameters.AddWithValue("@rank", officer.Rank);
                    sqlquery.Parameters.AddWithValue("@phoneNumber", officer.PhoneNumber);
                    sqlquery.Parameters.AddWithValue("@address", officer.Address);
                    sqlquery.Parameters.AddWithValue("@agencyId", officer.AgencyId);
                    sqlquery.Parameters.AddWithValue("@email", officer.Email);
                    sqlquery.Parameters.AddWithValue("@password", officer.Password);
                    sqlquery.Parameters.AddWithValue("@role", officer.Role);
                    int num= sqlquery.ExecuteNonQuery();
                    con.Close();
                    return num;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
           
        }

        public Officer GetOfficerById(int officerId)
        {
            Officer officer = new Officer();
            con = util.getConnection();
            {
                try
                {
                   
                   string query = "select * from Officers where OfficerID = @officerId";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                  sqlquery.Parameters.AddWithValue("@officerId", officerId);
                    SqlDataReader reader = sqlquery.ExecuteReader();
                    {
                        if (reader.Read())
                        {
                            officer.OfficerId = (int)reader["OfficerID"];
                            officer.FirstName = (string)reader["FirstName"];
                            officer.LastName = (string)reader["LastName"];
                            officer.BadgeNumber = (int)(reader["BadgeNumber"]);
                            officer.Rank = (string)reader["Rank"];
                            officer.PhoneNumber = (long)reader["PhoneNumber"];
                            officer.Address = (string)reader["Address"];
                            officer.AgencyId = (int)reader["AgencyID"];
                            officer.Role = (string)reader["Role"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return officer;
        }
        public int OfficerLogin(string email, string password, string role)
        {
            Officer officer = new Officer();
            //string hashedPassword = PasswordChecker.HashPassword(password);

            con = util.getConnection();
            {
                try
                {
                   
                 string query = "select OfficerID from Officers where Email = @email and Password = @password and Role = @role";
                    SqlCommand sqlquery = new SqlCommand(query, con);
                    sqlquery.Parameters.AddWithValue("@email", email);
                    sqlquery.Parameters.AddWithValue("@password", password);
                    sqlquery.Parameters.AddWithValue("@role", role);
                    var result = sqlquery.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            con.Close();
            return -1;
        }
    }
}
