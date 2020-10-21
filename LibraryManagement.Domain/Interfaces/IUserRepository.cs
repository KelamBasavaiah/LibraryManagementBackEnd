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
        string getUser(string username);
        List<User> getAllbooksforUser(int userId);
        bool returnBook(int id);
        bool lendingBooks(string bookid, string username);
    }
}
