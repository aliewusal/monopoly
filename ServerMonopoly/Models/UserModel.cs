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
            User user = new User();
            user.Name = "User1";
            user.Id = 1;
            users.Add(user);
            return users;
        }
    }
}