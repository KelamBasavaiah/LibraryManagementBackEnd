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
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        IUserBl userObj;
        public UserController(IUserBl userObj)
        {
            this.userObj=userObj;
        }
        
        [HttpGet]
        [Route("GetBooks")]
        public List<User> GetBooks(int userId)
        {
            return userObj.getAllbooksforUser(userId);
        }
        
        [Route("login")]
        [HttpPost]
        public login login(login log)
        {
           
            try
            {
                return userObj.getUser(log.username, log.password);
            }
            catch (Exception)
            {

                return new login();
            }
        }

        [HttpPost]
        [Route("lendBook")]
        public bool lendBook(string bookid,[FromBody]User user)
        {
            try
            {
                return userObj.lendingBooks(bookid, user.userId);
            }
            catch(Exception e)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("returnBook")]
        public bool returnBook(int id)
        {
            return userObj.returnBook(id);
        }
    }
}
