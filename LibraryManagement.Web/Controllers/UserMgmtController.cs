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
    [RoutePrefix("UserMgmt")]
    public class UserMgmtController : ApiController
    {
        IUserMgmtBL userObj;
        public UserMgmtController(IUserMgmtBL userObj)
        {
            this.userObj = userObj;
        }

        [HttpGet]
        [Route("GetUser")]
        public IHttpActionResult GetUser(int id)
        {
            try
            {
                return Ok(userObj.GetUserDetails(id));
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.NotFound, ex.Message);
            }            
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult GerallUsers()
        {
            try
            {
                return Ok(userObj.getAllUserMgmtDetails());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult AddUser([FromBody]User user)
        {
            try
            {
                return Ok(userObj.addUserDetails(user));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IHttpActionResult Delete(int userId)
        {
            try
            {
                return Ok(userObj.deleteUser(userId));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }
    }
}