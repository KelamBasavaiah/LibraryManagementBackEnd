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
        bool getUser(string username,string password);
        List<User> getAllbooksforUser(string userName);
        bool returnBook(User book);
    }
}
