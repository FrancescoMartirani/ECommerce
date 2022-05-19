using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Data.SqlClient;

namespace WebApplication2.Controllers
{
    public class Customer_Controller
    {

        private readonly string ConnectionString;
        public Customer_Controller()
        {

            ConnectionString = "Server=ACADEMYNETPD01\\SQLEXPRESS;Database=ECommerce;Trusted_Connection=True;";

        }

        public List<Customer> GetCustomers()
        {

            var sql = @"
                    SELECT [Id_Customer]
                          ,[Nome]
                          ,[Cognome]
                          ,[DataNascita]
                          ,[Email]
                      FROM [dbo].[Customers]";

            var listResult = new List<Customer>();

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {


                Customer customer = new Customer
                {

                    Id_Customer = Convert.ToInt32(reader["Id_Customer"]),
                    Nome = reader["Nome"].ToString(),
                    Cognome = reader["Cognome"].ToString(),
                    DataNascita = Convert.ToDateTime(reader["DataNascita"]),
                    Email = reader["Email"].ToString(),

                };

                listResult.Add(customer);
            }

            return listResult;
        }

    }
}
