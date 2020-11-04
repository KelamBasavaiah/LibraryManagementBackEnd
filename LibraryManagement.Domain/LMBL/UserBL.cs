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
        public async Task<List<User>> getAllbooksforUser(int userId)
        {
            return await userObj.getAllbooksforUser(userId);
        }
        public async Task<bool> lendingBooks(string bookid, int userID)
        {
            return await userObj.lendingBooks(bookid, userID);
        }
        public async Task<bool> returnBook(int id)
        {
            return await userObj.returnBook(id);
        }
        public async Task<bool> changePassword(int userId,string oldPassword,string newPassword)
        {
            if(await userObj.checkingOldPassword(userId, oldPassword))
            {
                return await userObj.updatePassword(userId, newPassword);
            }
            else
            {
                return false;
            }
        }
    }
}
