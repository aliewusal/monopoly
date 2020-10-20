using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace ServerMonopoly.Models
{
    public class UserModel
    {
        private SQLiteConnection dbConnection;
        public void ConnectionToDb()
        {
            dbConnection = new SQLiteConnection("Data Source=C:\\Users\\prosu\\source\\repos\\monopoly\\ServerMonopoly\\App_Data\\monopoly.db; Version=3");
        }
        public List<User> users { get; set; }
        public UserModel()
        {
            ConnectionToDb();
            users = new List<User>();
        }

        public List<User> GetUsers()
        {
            dbConnection.Open();
            SQLiteCommand load = dbConnection.CreateCommand();
            load.CommandText = "SELECT * FROM Users";
            SQLiteDataReader sql = load.ExecuteReader();
            while (sql.Read())
            {
                User user = new User();
                user.Id = Convert.ToInt32(sql["Id"]);
                user.Name = Convert.ToString(sql["Name"]);
                users.Add(user);
            }
            dbConnection.Close();
            return users;
        }
    }
}