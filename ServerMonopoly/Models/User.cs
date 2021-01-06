using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerMonopoly.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Friends { get; set; }
        public string Password { get; set; }
        public int Rating { get; set; }
        public int Games_count { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Likes { get; set; }
    }
}