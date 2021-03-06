﻿using LibraryManagement.Domain.Interfaces;
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
        public async Task<IHttpActionResult> GetBooks(int userId)
        {            
            try
            {
                return Ok(await userObj.getAllbooksforUser(userId));
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }
                
        [HttpPost]
        [Route("login")]
        public async Task<IHttpActionResult> login(login log)
        {
           
            try
            {
                return Ok(await userObj.getUser(log.username, log.password));
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.NotFound, ex.Message); 
            }
        }

        [HttpPost]
        [Route("lendBook")]
        public async Task<IHttpActionResult> lendBook(List<string> bookid, int userId)
        {
            try
            {
                return Ok(await userObj.lendingBooks(bookid, userId));
            }
            catch (Exception e)
            {
                return Ok(false);
            }
        }

        [HttpPost]
        [Route("returnBook")]
        public async Task<IHttpActionResult> returnBook(List<int> id)
        {
            try
            {
                return Ok(await userObj.returnBook(id));
            }
            catch (Exception)
            {

                return Ok(false);
            }
            
        }
    }
}
