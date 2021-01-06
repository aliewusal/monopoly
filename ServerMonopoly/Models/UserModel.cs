using System;
using System.Collections.Generic;
using System.Data;
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
            GetUsers();
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

        //public void AcceptedFriend(string sender_name, int accept_id)
        //{
           
        //}

        //public string AddFriend(string search_name, int sender_id)
        //{
        //    dbConnection.Open();
        //    SQLiteCommand load = dbConnection.CreateCommand();

        //    load.CommandText = "SELECT * FROM Users WHERE Name = @name";
        //    load.Parameters.Add("@name", DbType.String).Value = search_name;
        //    SQLiteDataReader sql = load.ExecuteReader();

        //    User user = new User();

        //    while (sql.Read())
        //    {
        //        user.Id = Convert.ToInt32(sql["Id"]);
        //        user.Name = Convert.ToString(sql["Name"]);
        //        user.Friends = Convert.ToString(sql["Friends"]);
        //        user.Password = Convert.ToString(sql["Password"]);
        //        user.Rating = Convert.ToInt32(sql["Rating"]);
        //        user.Games_count = Convert.ToInt32(sql["Games_count"]);
        //        user.Wins = Convert.ToInt32(sql["Wins"]);
        //        user.Loses = Convert.ToInt32(sql["Loses"]);
        //        user.Likes = Convert.ToInt32(sql["Likes"]);

        //        SQLiteCommand add = dbConnection.CreateCommand();
        //        add.CommandText = "INSERT INTO RequestFriends (User1_Id, User2_Id, Accepted) values (@sender_id, @userId, @accepted)";
        //        add.Parameters.Add("@sender_id", DbType.Int32).Value = sender_id;
        //        add.Parameters.Add("@userId", DbType.Int32).Value = user.Id;
        //        add.Parameters.Add("@accepted", DbType.Boolean).Value = false;
        //    }
                       

        //    dbConnection.Close();

        //    return $"Завяка в друзья {search_name} отправлена";
        //}

        public User GetUserById(int id)
        {
            dbConnection.Open();
            SQLiteCommand load = dbConnection.CreateCommand();

            load.CommandText = "SELECT * FROM Users WHERE Id = @id";
            load.Parameters.Add("@id", DbType.Int32).Value = id;
            SQLiteDataReader sql = load.ExecuteReader();

            User user = new User();

            while (sql.Read())
            {
                user.Id = Convert.ToInt32(sql["Id"]);
                user.Name = Convert.ToString(sql["Name"]);
                user.Friends = Convert.ToString(sql["Friends"]);
                user.Password = Convert.ToString(sql["Password"]);
                user.Rating = Convert.ToInt32(sql["Rating"]);
                user.Games_count = Convert.ToInt32(sql["Games_count"]);
                user.Wins = Convert.ToInt32(sql["Wins"]);
                user.Loses = Convert.ToInt32(sql["Loses"]);
                user.Likes = Convert.ToInt32(sql["Likes"]);
            }

            dbConnection.Close();

            return user;
        }

        public bool Login(string name, string passwod)
        {
            dbConnection.Open();
            SQLiteCommand load = dbConnection.CreateCommand();

            load.CommandText = "SELECT * FROM Users WHERE Name = @name AND Password = @password";
            load.Parameters.Add("@name", DbType.String).Value = name;
            load.Parameters.Add("@password", DbType.String).Value = passwod;
            SQLiteDataReader sql = load.ExecuteReader();

            User user = new User();

            while (sql.Read())
            {
                user.Id = Convert.ToInt32(sql["Id"]);
                user.Name = Convert.ToString(sql["Name"]);
                user.Friends = Convert.ToString(sql["Friends"]);
                user.Password = Convert.ToString(sql["Password"]);
                user.Rating = Convert.ToInt32(sql["Rating"]);
                user.Games_count = Convert.ToInt32(sql["Games_count"]);
                user.Wins = Convert.ToInt32(sql["Wins"]);
                user.Loses = Convert.ToInt32(sql["Loses"]);
                user.Likes = Convert.ToInt32(sql["Likes"]);
            }

            dbConnection.Close();

            if (user != null)
                return true;
            else
                return false;
        }

        public string Register(User user) // same Create
        {
            foreach (User user1 in users)
            {
                if (user1.Name == user.Name)
                    return "Это имя уже занято!";
            }
            dbConnection.Open();

            SQLiteCommand add = dbConnection.CreateCommand();
            add.CommandText = "INSERT INTO Users(Name, Friends, Password, Rating, Games_count, Wins, Loses, Likes)" +
                " values(@name, @friends, @password, @rating, @games_count, @wins, @loses, @likes)";
            add.Parameters.Add("@name", DbType.String).Value = user.Name;
            add.Parameters.Add("@friends", DbType.String).Value = user.Friends;
            add.Parameters.Add("@password", DbType.String).Value = user.Password;
            add.Parameters.Add("@rating", DbType.Int32).Value = user.Rating;
            add.Parameters.Add("@games_count", DbType.Int32).Value = user.Games_count;
            add.Parameters.Add("@wins", DbType.Int32).Value = user.Wins;
            add.Parameters.Add("@loses", DbType.Int32).Value = user.Loses;
            add.Parameters.Add("@likes", DbType.Int32).Value = user.Likes;
            add.ExecuteNonQuery();

            users.Add(user);

            dbConnection.Close();

            return "Регистрация прошла успешно!";
        } 

        public string Delete(int id)
        {
            dbConnection.Open();

            SQLiteCommand add = dbConnection.CreateCommand();
            add.CommandText = "DELETE FROM Users WHERE Id = @id";
            add.Parameters.Add("@id", DbType.Int32).Value = id;
            add.ExecuteNonQuery();

            foreach (User user in users)
            {
                if (user.Id == id)
                {
                    users.Remove(user);
                    break;
                }    
            }

            dbConnection.Close();

            return "Пользователь был удален!";
        }

        public string Update(int id, User user)
        {
            dbConnection.Open();

            SQLiteCommand add = dbConnection.CreateCommand();
            add.CommandText = "UPDATE Users SET Name = @name, Friends = @friends, Password = @password, " +
                " Rating = @rating, Games_count = @games_count, Wins = @wins, Loses = @loses, Likes = @likes WHERE Id = @id";
            add.Parameters.Add("@id", DbType.Int32).Value = id;
            add.Parameters.Add("@name", DbType.String).Value = user.Name;
            add.Parameters.Add("@friends", DbType.String).Value = user.Friends;
            add.Parameters.Add("@password", DbType.String).Value = user.Password;
            add.Parameters.Add("@rating", DbType.Int32).Value = user.Rating;
            add.Parameters.Add("@games_count", DbType.Int32).Value = user.Games_count;
            add.Parameters.Add("@wins", DbType.Int32).Value = user.Wins;
            add.Parameters.Add("@loses", DbType.Int32).Value = user.Loses;
            add.Parameters.Add("@likes", DbType.Int32).Value = user.Likes;
            add.ExecuteNonQuery();

            dbConnection.Close();

            return "Данные успешно обновлены!";
        } 
    }
}