using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Interfaces
{
    public interface IUserMgmtRepository
    {
        Task<bool> addUserDetails(User user);
        Task<User> GetUserDetails(int id);
        Task<List<User>> getAllUserMgmtDetails();
        Task<bool> deleteUser(int userId);
    }
}
