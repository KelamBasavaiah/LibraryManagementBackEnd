using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LibraryManagement.Web.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]
    public class UserController : ApiController
    {
        IUserBl userObj;
        public UserController(IUserBl userObj)
        {
            this.userObj=userObj;
        }
        // GET: api/User
        public List<User> Get(int userId)
        {
            return userObj.getAllbooksforUser(userId);
        }

        // GET: api/User/5
        [Route("api/User/{username}/{password}")]
        public bool Get(string username,string password)
        {
            return userObj.getUser(username, password);
        }

        // POST: api/User
        public bool Post(string bookid,[FromBody]User user)
        {
            try
            {
                return userObj.lendingBooks(bookid, user.UserName);
            }
            catch(Exception e)
            {
                return false;
            }
        }

        // PUT: api/User/5
       
        public bool Put(string username,[FromBody]string password)
        {
            return userObj.getUser(username, password);
        }

        // DELETE: api/User/5
        public bool Delete(int id)
        {
            return userObj.returnBook(id);
        }
    }
}
