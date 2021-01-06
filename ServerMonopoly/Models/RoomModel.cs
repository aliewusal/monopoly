using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace ServerMonopoly.Models
{
    public class RoomModel
    {
        private SQLiteConnection dbConnection;
        public void ConnectionToDb()
        {
            dbConnection = new SQLiteConnection("Data Source=C:\\Users\\prosu\\source\\repos\\monopoly\\ServerMonopoly\\App_Data\\monopoly.db; Version=3");
        }
        public List<Room> rooms { get; set; }

        public RoomModel()
        {
            ConnectionToDb();
            rooms = new List<Room>();
        }

        public List<Room> GetRooms()
        {
            dbConnection.Open();
            SQLiteCommand load = dbConnection.CreateCommand();
            load.CommandText = "SELECT * FROM Rooms";
            SQLiteDataReader sql = load.ExecuteReader();
            while (sql.Read())
            {
                Room room = new Room();
                room.Id = Convert.ToInt32(sql["Id"]);
                room.User1_Id = Convert.ToInt32(sql["User1_Id"]);
                room.User2_Id = Convert.ToInt32(sql["User2_Id"]);
                room.User3_Id = Convert.ToInt32(sql["User3_Id"]);
                room.User4_Id = Convert.ToInt32(sql["User4_Id"]);
                room.Position = Convert.ToString(sql["Position"]);
                room.Money = Convert.ToString(sql["Money"]);
                room.Brands = Convert.ToString(sql["Brands"]);
                room.Lobby_Id = Convert.ToInt32(sql["Lobby_Id"]);
                rooms.Add(room);
            }
            dbConnection.Close();
            return rooms;
        }

        public string Update(int id, Room room)
        {
            dbConnection.Open();

            SQLiteCommand add = dbConnection.CreateCommand();
            add.CommandText = "UPDATE Rooms SET User1_Id = @user1, User2_Id = @user2, User3_Id = @user3, " +
                " User4_Id = @user4, Position = @pos, Money = @money, Brands = @brands, Lobby_Id = @lobby_id WHERE Id = @id";
            add.Parameters.Add("@id", DbType.Int32).Value = id;
            add.Parameters.Add("@user1", DbType.Int32).Value = room.User1_Id;
            add.Parameters.Add("@user2", DbType.Int32).Value = room.User2_Id;
            add.Parameters.Add("@user3", DbType.Int32).Value = room.User3_Id;
            add.Parameters.Add("@user4", DbType.Int32).Value = room.User4_Id;
            add.Parameters.Add("@pos", DbType.String).Value = room.Position;
            add.Parameters.Add("@money", DbType.String).Value = room.Money;
            add.Parameters.Add("@brands", DbType.String).Value = room.Brands;
            add.Parameters.Add("@lobby_id", DbType.Int32).Value = room.Lobby_Id;
            add.ExecuteNonQuery();

            dbConnection.Close();

            return "Данные успешно обновлены!";
        }
    }
}