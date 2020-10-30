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
        Task<List<User>> getAllbooksforUser(int userId);
        Task<bool> returnBook(int id);
        login getUser(string username,string password);
        Task<bool> lendingBooks(string bookid, int userID);
        Task<bool> changePassword(int userId, string oldPassword, string newPassword);
    }
}
