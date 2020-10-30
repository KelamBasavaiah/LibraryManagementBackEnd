using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMBL
{
    public class UserMgmtBL : IUserMgmtBL
    {
        IUserMgmtRepository userObj;
        public UserMgmtBL(IUserMgmtRepository userObj)
        {
            this.userObj = userObj;
        }
        public  async Task<bool> addUserDetails(User user)
        {
            return await userObj.addUserDetails(user);
        }
        public async Task<User> GetUserDetails(int id)
        {
            return await userObj.GetUserDetails(id);
        }
        public async Task<List<User>> getAllUserMgmtDetails()
        {
            return await userObj.getAllUserMgmtDetails();
        }
        public async Task<bool> deleteUser(int userId)
        {
            return await userObj.deleteUser(userId);
        }

    }
}
