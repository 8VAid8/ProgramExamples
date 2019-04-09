using MySql.Data.MySqlClient;
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
        MySqlConnection connection;

        public GuitarsRepository()
        {
            string username = "root";
            string password = "";
            string connectionString = $"Server=localhost;Port=3306;Database=mysql;Uid={username};Pwd={password};CharSet=utf8";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public void Create(string brand, string model, string color, decimal price)
        {
            string commandText = $"INSERT INTO Guitars(Brand, Model, Color, Price) " +
                $"values('{brand}', '{model}', '{color}', {price});";
            using (MySqlCommand command = new MySqlCommand(commandText, connection))
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
            List<Guitar> guitars = new List<Guitar>();
            string commandText = $"select Brand, Model, Price from Guitars";
            using (MySqlCommand command = new MySqlCommand(commandText, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        guitars.Add(new Guitar
                        {
                            Brand = reader.GetString(0),
                            Model = reader.GetString(1),
                            Price = reader.GetInt64(2)
                        });
                    }
                }
            }
            return guitars;
        }

        public void Update(int id, string brand, string model, string color, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}
