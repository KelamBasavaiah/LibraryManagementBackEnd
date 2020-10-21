using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;


namespace LibraryManagement.Domain.Interfaces
{
   public interface IUserRepository
    {        
        List<User> getAllbooksforUser(int userId);
        bool returnBook(int id);
        login getUser(string username);                
        bool lendingBooks(string bookid, int userID);
    }
}
