using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMBL
{
    public class UserBl : IUserBl
    {
        IUserRepository userObj;
        public UserBl(IUserRepository userObj)
        {
            this.userObj = userObj;
        }
        public bool getUser(string username, string password)
        {
            bool result = false;
            string dbPasssword = userObj.getUser(username);
            if(dbPasssword== password) { result = true; }
            return result;           
        }
        public List<User> getAllbooksforUser(int userId)
        {
            return userObj.getAllbooksforUser(userId);
        }
        public bool lendingBooks(string bookid, string username)
        {
            return userObj.lendingBooks(bookid, username);
        }
        public bool returnBook(int id)
        {
            return userObj.returnBook(id);
        }
    }
}
