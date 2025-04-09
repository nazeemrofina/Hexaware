using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__CodingChallenge.Exceptions;
using C__CodingChallenge.Model;

namespace C__CodingChallenge.Service
{
    class PetShelter
    {
        List<Pets> pets;
        SqlConnection con;
        SqlDataReader sdr;
        Utility util = new Utility();
        public List<Pets> AvilablePets()
        {
            // Exceptioncode.CkeckNullException(pets);
            con = util.getConnection();
            try
            {
                String query = "select * from pets";
                SqlCommand sqlquery = new SqlCommand(query, con);
                sdr = sqlquery.ExecuteReader();

                while (sdr.Read())
                {
                    Console.WriteLine($"{sdr["petname"]}, {sdr["age"]},{sdr["breed"]}," +
                        $"{sdr["pettype"]} ");

                }
                con.Close();

            }
            catch (FileHandlingException e)
            {
                Console.WriteLine(e.Message);

            }
            catch(NullReferenceExceptionHandling e)
            {
                Console.WriteLine(e.Message);
            }
             return pets;
        }
        public void AddPets(Pets pet)
        {
            try
            {
                Exceptioncode.CheckAge(pet.age);
            }
            catch (InvalidPetAgeHandling e)
            {
                Console.WriteLine(e.Message);
            }
            pets.Add(pet);
        }
        public void RemovePets(Pets pet)
        {
            pets.Remove(pet);
        }
    }
}
