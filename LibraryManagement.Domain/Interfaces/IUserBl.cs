﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;


namespace LibraryManagement.Domain.Interfaces
{
   public interface IUserBl
    {        
        List<User> getAllbooksforUser(int userId);
        bool returnBook(int id);
        login getUser(string username,string password);     
        bool lendingBooks(string bookid, int userID);
    }
}
