using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerMonopoly.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int User1_Id { get; set; }
        public int User2_Id { get; set; }
        public int User3_Id { get; set; }
        public int User4_Id { get; set; }
        public string Position { get; set; }
        public string Money { get; set; }
        public string Brands { get; set; }
        public int Lobby_Id { get; set; }
    }
}