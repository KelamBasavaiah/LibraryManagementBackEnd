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
        public login getUser(string username, string password)
        {
            login login = new login();
            login = userObj.getUser(username);
            if(login.password== password) { login.aurthorize = true; }
            return login;           
        }
        public List<User> getAllbooksforUser(int userId)
        {
            return userObj.getAllbooksforUser(userId);
        }
        public bool lendingBooks(string bookid, int userID)
        {
            return userObj.lendingBooks(bookid, userID);
        }
        public bool returnBook(int id)
        {
            return userObj.returnBook(id);
        }
    }
}
