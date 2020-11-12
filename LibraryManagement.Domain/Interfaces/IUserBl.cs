using System;
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
        Task<bool> returnBook(List<int> id);
        Task<login> getUser(string username,string password);
        Task<bool> lendingBooks(List<string> bookid, int userID);
    }
}
