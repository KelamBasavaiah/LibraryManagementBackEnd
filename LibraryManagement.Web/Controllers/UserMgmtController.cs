﻿using LibraryManagement.Domain.Interfaces;
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
    [EnableCors("http://localhost:4200", "*", "GET,POST")]
    public class UserMgmtController : ApiController
    {
        IUserMgmtBL userObj;
        public UserMgmtController(IUserMgmtBL userObj)
        {
            this.userObj = userObj;
        }
        public User Get(int id)
        {
            return userObj.GetUserDetails(id);
        }
        public bool Post([FromBody]User user)
        {
            try
            {
                return userObj.addUserDetails(user);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}