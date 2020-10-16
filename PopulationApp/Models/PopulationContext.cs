using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationApp.Models
{
    public class PopulationContext
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM People", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        people.Add(new Person
                        {
                            PersonId = (int)reader.GetValue(0),
                            FirstName = reader.GetValue(1).ToString(),
                            LastName = reader.GetValue(2).ToString(),
                            Age = (int)reader.GetValue(3),
                            Gender = reader.GetValue(4).ToString(),
                            CountryId = (int)reader.GetValue(5),
                        });
                    }
                }
                reader.Close();
                return people;
            }
        }
        
        public List<int> GetCountryIds()
        {
            List<int> ids = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT CountyId FROM Countries", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ids.Add((int)reader.GetValue(0));
                    }
                }
                reader.Close();
                return ids;
            }
        }

        public void AddPerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"INSERT INTO People VALUES ('{person.FirstName}', '{person.LastName}', {person.Age}, '{person.Gender}', {person.CountryId})", connection);

                //SqlCommand command = new SqlCommand("INSERT INTO People VALUES (@FirstName, @LastName, @Age, @Gender, @CountryId)", connection);
                //SqlParameter firstNameParam = new SqlParameter("@FirstName", person.FirstName);
                //command.Parameters.Add(firstNameParam);
                //SqlParameter lastNameParam = new SqlParameter("@LastName", person.LastName);
                //command.Parameters.Add(lastNameParam);
                //SqlParameter ageParam = new SqlParameter("@Age", person.Age);
                //command.Parameters.Add(ageParam);
                //SqlParameter genderParam = new SqlParameter("@Gender", person.Gender);
                //command.Parameters.Add(genderParam);
                //SqlParameter countyIdParam = new SqlParameter("@CountryId", person.CountryId);
                //command.Parameters.Add(countyIdParam);

                command.ExecuteNonQuery();
            }
        }

        public void EditPerson(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"UPDATE People SET FirstName = '{person.FirstName}', LastName = '{person.LastName}', Age = {person.Age}, Gender = '{person.Gender}', CountryId = {person.CountryId} WHERE PersonId = {person.PersonId}", connection);

                command.ExecuteNonQuery();
            }
        }

        public void DeletePerson(int? personId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"DELETE FROM People WHERE PersonId = {personId}", connection);

                command.ExecuteNonQuery();
            }
        }

        public void AddCountry(Country country)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"INSERT INTO Countries VALUES ('{country.Name}', {country.Population}, {country.Area}, '{country.Continent}', '{country.Capital}')", connection);

                command.ExecuteNonQuery();
            }
        }

        public void EditCountry(Country country)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"UPDATE Countries SET Name = '{country.Name}', Population = {country.Population}, Area = {country.Area}, Capital = '{country.Capital}', Continent = '{country.Continent}' WHERE CountyId = {country.CountryId}", connection);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteCountry(int? countryId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"DELETE FROM Countries WHERE CountyId = {countryId}", connection);

                command.ExecuteNonQuery();
            }
        }

        public List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Countries", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        countries.Add(new Country
                        {
                            CountryId = (int)reader.GetValue(0),
                            Name = reader.GetValue(1).ToString(),
                            Population = (int)reader.GetValue(2),
                            Area = (int)reader.GetValue(3),
                            Continent = reader.GetValue(4).ToString(),
                            Capital = reader.GetValue(5).ToString(),
                        });
                    }
                }
                reader.Close();
                return countries;
            }
        }
    }
}
