using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMDAL.Mappers
{
    public class userMgmtMapper
    {
        public static async Task<List<User>> mapAllUsers(SqlDataReader drUser)
        {
            List<User> users = new List<User>();
            User user;
            while (await drUser.ReadAsync())
            {
                user = new User();
                user.userId = Convert.ToInt32(drUser[0]);
                user.username = drUser[1].ToString();
                user.password = drUser[2].ToString();
                user.role = Convert.ToString(drUser[3]);
                user.isActive = Convert.ToInt32(drUser[4]);
                user.phoneNo = Convert.ToInt64(drUser[5]);
                user.mailId = drUser[6].ToString();
                users.Add(user);
            }
            return users;
        }
        public static async Task<User> mapUser(SqlDataReader drUser)
        {
            User user = new User();
            while (await drUser.ReadAsync())
            {
                user.id = Convert.ToInt32(drUser[0]);
                user.username = drUser[1].ToString();
                user.password = drUser[2].ToString();
                user.role = Convert.ToString(drUser[3]);
                user.isActive = Convert.ToInt32(drUser[4]);
                user.phoneNo = Convert.ToInt64(drUser[5]);
                user.mailId = drUser[6].ToString();
            }
            return user;
        }
    }
}
