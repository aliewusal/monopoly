using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace ServerMonopoly.Models
{
    public class LobbyModel
    {
        private SQLiteConnection dbConnection;
        public void ConnectionToDb()
        {
            dbConnection = new SQLiteConnection("Data Source=C:\\Users\\prosu\\source\\repos\\monopoly\\ServerMonopoly\\App_Data\\monopoly.db; Version=3");
        }
        public List<Lobby> lobbies { get; set; }

        public LobbyModel()
        {
            ConnectionToDb();
            lobbies = new List<Lobby>();
        }

        public List<Lobby> GetLobbies()
        {
            dbConnection.Open();
            SQLiteCommand load = dbConnection.CreateCommand();
            load.CommandText = "SELECT * FROM Lobbies";
            SQLiteDataReader sql = load.ExecuteReader();
            while (sql.Read())
            {
                Lobby lobby = new Lobby();
                lobby.Id = Convert.ToInt32(sql["Id"]);
                lobby.Name = Convert.ToString(sql["Name"]);
                lobby.isPrivate = Convert.ToBoolean(sql["isPrivate"]);
                lobby.Count = Convert.ToInt32(sql["Count"]);
                lobby.Password = Convert.ToInt32(sql["Password"]);
                lobbies.Add(lobby);
            }
            dbConnection.Close();
            return lobbies;
        }

    }
}