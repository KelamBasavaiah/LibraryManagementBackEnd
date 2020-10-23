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
        public bool addUserDetails(User user)
        {
            return userObj.addUserDetails(user);
        }
        public User GetUserDetails(int id)
        {
            return userObj.GetUserDetails(id);
        }
        public List<User> getAllUserMgmtDetails()
        {
            return userObj.getAllUserMgmtDetails();
        }
        public bool deleteUser(int userId)
        {
            return userObj.deleteUser(userId);
        }

    }
}
