using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;

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
        public async Task<IHttpActionResult> GetUser(int id)
        {
            try
            {
                return Ok(await userObj.GetUserDetails(id));
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.NotFound, ex.Message);
            }            
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IHttpActionResult> GerallUsers()
        {
            try
            {
                return Ok(await userObj.getAllUserMgmtDetails());
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IHttpActionResult> AddUser([FromBody]User user)
        {
            try
            {
                return Ok(await userObj.addUserDetails(user));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IHttpActionResult> Delete(int userId)
        {
            try
            {
                return Ok(await userObj.deleteUser(userId));
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
        }
    }
}