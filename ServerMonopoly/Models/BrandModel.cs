using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace ServerMonopoly.Models
{
    public class BrandModel
    {
        private SQLiteConnection dbConnection;
        public void ConnectionToDb()
        {
            dbConnection = new SQLiteConnection("Data Source=C:\\Users\\prosu\\source\\repos\\monopoly\\ServerMonopoly\\App_Data\\monopoly.db; Version=3");
        }
        public List<Brand> brands { get; set; }

        public BrandModel()
        {
            ConnectionToDb();
            brands = new List<Brand>();
        }

        public List<Brand> GetBrands()
        {
            dbConnection.Open();
            SQLiteCommand load = dbConnection.CreateCommand();
            load.CommandText = "SELECT * FROM Brands";
            SQLiteDataReader sql = load.ExecuteReader();
            while (sql.Read())
            {
                Brand brand = new Brand();
                brand.Id = Convert.ToInt32(sql["Id"]);
                brand.Name = Convert.ToString(sql["Name"]);
                brand.Image = Convert.ToString(sql["Image"]);
                brands.Add(brand);
            }
            dbConnection.Close();
            return brands;
        }
    }
}