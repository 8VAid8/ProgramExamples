using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarsProject.DAL
{
    public class GuitarsRepository : IRepository<Guitar>
    {
        SqlConnection connection;

        public GuitarsRepository()
        {
            string username = "your username";
            string password = "your pass";
            string connectionString = $"yourConnectionString";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void Create(int id, string brand, string model, string color, decimal price)
        {
            string commandText = $"INSERT INTO Guitars(Id, Brand, Model, Color, Price) " +
                $"values({id}, '{brand}', '{model}', '{color}', {price});";
            using (SqlCommand command = new SqlCommand(commandText, connection))
            {
                if (command.ExecuteNonQuery() <= 0)
                    throw new Exception("Вставка не удалась!");
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public IEnumerable<Guitar> Get()
        {
            //using (SqlDataReader reader = command.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("{0} {1} {2}",
            //            reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            //    }
            //}
            throw new NotImplementedException();
        }

        public void Update(int id, string brand, string model, string color, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
