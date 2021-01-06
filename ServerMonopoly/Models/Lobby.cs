using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerMonopoly.Models
{
    public class Lobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isPrivate { get; set; }
        public int Count { get; set; }
        public int Password { get; set; }
    }
}