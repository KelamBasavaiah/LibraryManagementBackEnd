﻿using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Interfaces
{
    public interface IUserMgmtRepository
    {
        bool addUserDetails(User user);
        User GetUserDetails(int id);
        List<User> getAllUserMgmtDetails();
        bool deleteUser(int userId);
    }
}
