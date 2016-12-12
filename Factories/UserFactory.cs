using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using quotingDojo.Models;
namespace quotingDojo.Factory
{
    public class UserFactory : IFactory<User>
    {
        private string connectionString;
        public UserFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=NewQuotes;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(User item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query = "INSERT INTO User (name, quote, createdat, updatedat) VALUES (@name, @quote, Now(), Now())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<User> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM User");
            }
        }
        public User FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM User WHERE id = @id", new {Id = id}).FirstOrDefault();
            }
        }
    }
}