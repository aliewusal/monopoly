using ServerMonopoly.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerMonopoly.Controllers
{
    public class LobbyController : ApiController
    {
        private LobbyModel lobbyModel;
        public LobbyController()
        {
            lobbyModel = new LobbyModel();
        }
        //GET api/lobbies
        [Route("api/lobbies/")]
        public IEnumerable<Lobby> GetLobbies()
        {
            return lobbyModel.GetLobbies();
        }
    }
}