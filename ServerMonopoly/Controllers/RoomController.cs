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
    public class RoomController : ApiController
    {
        private RoomModel roomModel;
        public RoomController()
        {
            roomModel = new RoomModel();
        }
        //GET api/rooms
        [Route("api/rooms/")]
        public IEnumerable<Room> GetRooms()
        {
            return roomModel.GetRooms();
        }
    }
}