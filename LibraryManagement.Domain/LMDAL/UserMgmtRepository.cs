using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.LMDAL.Mappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMDAL
{
    public class UserMgmtRepository : BaseRepository, IUserMgmtRepository
    {
        public async Task<bool> addUserDetails(User user)
        {
            int count = await ExecuteNonQuery("ProcInsertUserDetails",
                                   p => {
                                       p.AddWithValue("@Id", user.id);
                                       p.AddWithValue("@username", user.username);
                                       p.AddWithValue("@password", user.password);
                                       p.AddWithValue("@role", user.role);
                                       p.AddWithValue("@isActive", user.isActive);
                                       p.AddWithValue("@phoneno", user.phoneNo);
                                       p.AddWithValue("@mailid", user.mailId);
                                   });
            if (count > 0)

            {
                return true;
            }
            return false;
        }
        public async Task<User> GetUserDetails(int id)
        {

            return await ExecuteReader("ProcGetUserDetails", async reader => await userMgmtMapper.mapUser(reader),
                                p => { p.AddWithValue("@Id", id); });

        }
        public async Task<List<User>> getAllUserMgmtDetails()
        {

            return await ExecuteReader("procGetAllUserDetails", async reader => await userMgmtMapper.mapAllUsers(reader),
                                  p => { });
        }
        public async Task<bool> deleteUser(int userId)
        {
            int count = await ExecuteNonQuery("procDeleteUser", p => { p.AddWithValue("@userId", userId); });
            if (count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
