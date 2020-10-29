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
        public IHttpActionResult GetBooks(int userId)
        {            
            try
            {
                return Ok(userObj.getAllbooksforUser(userId));
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }
                
        [HttpPost]
        [Route("login")]
        public IHttpActionResult login(login log)
        {
           
            try
            {
                return Ok(userObj.getUser(log.username, log.password));
            }
            catch (Exception)
            {

                return Ok(new login());
            }
        }

        [HttpPost]
        [Route("lendBook")]
        public IHttpActionResult lendBook(string bookid,[FromBody]User user)
        {
            try
            {
                return Ok(userObj.lendingBooks(bookid, user.userId));
            }
            catch(Exception e)
            {
                return Ok(false);
            }
        }

        [HttpPost]
        [Route("returnBook")]
        public IHttpActionResult returnBook(int id)
        {
            try
            {
                return Ok(userObj.returnBook(id));
            }
            catch (Exception)
            {

                return Ok(false);
            }
            
        }
    }
}
