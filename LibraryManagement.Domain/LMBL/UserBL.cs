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
        public async Task<login> getUser(string username, string password)
        {
            login login = new login();
            login = await userObj.getUser(username);
            if(login.password== password) { login.aurthorize = true; }
            return login;           
        }
        public async Task<List<User>> getAllbooksforUser(int userId)
        {
            return await userObj.getAllbooksforUser(userId);
        }
        public async Task<bool> lendingBooks(List<string> bookid, int userID)
        {
            return await userObj.lendingBooks(bookid, userID);
        }
        public async Task<bool> returnBook(List<int> id)
        {
            return await userObj.returnBook(id);
        }
    }
}
