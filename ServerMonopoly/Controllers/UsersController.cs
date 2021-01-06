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
    public class UsersController : ApiController
    {
        private UserModel userModel;
        public UsersController()
        {
            userModel = new UserModel();
        }

        // GET api/user/int/{id}
        [Route("api/user/int/{id}")]
        public User GetUserById(int id)
        {
            return userModel.GetUserById(id);
        }

        //GET api/users
        [Route("api/users/")]
        public IEnumerable<User> GetUsers()
        {
            return userModel.GetUsers();
        }

        //GET api/users/str/{name}
        //[Route("api/user/add/friend/{search_name}/{sender_id}")]
        //public string AddUserInFriend(string search_name, int sender_id)
        //{
        //    return userModel.AddFriend(search_name , sender_id);
        //}

        //GET api/users/string/{name}
        [Route("api/user/login/{name}/{password}")]
        public bool GetLogin(string name, string password)
        {
            return userModel.Login(name, password);
        }

        // POST api/user/register/
        [Route("api/user/register/")]
        public string Post([FromBody] User user)
        {
            return userModel.Register(user);
        }

        // PUT api/user/update/{id}
        [Route("api/user/update/{id}")]
        public void Put(int id, [FromBody] User user)
        {
            userModel.Update(id, user);
        }

        // DELETE api/user/delete/{id}
        [Route("api/user/delete/{id}")]
        public void Delete(int id)
        {
            userModel.Delete(id);
        }
    }
}
