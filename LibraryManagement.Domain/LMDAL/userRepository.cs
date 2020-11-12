using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagement.Domain.LMDAL.Mappers;

namespace LibraryManagement.Domain.LMDAL
{
    public class userRepository : BaseRepository,IUserRepository
    {
        public async Task<login> getUser(string username)
        {
            return await ExecuteReader("getUser",
               async reader => await userMapper.Login(reader),
               p => { p.AddWithValue("@username", username); });
            
        }
        public async Task<List<User>> getAllbooksforUser(int userId)
        {
            return await ExecuteReader("ProcGetBookRecords",
               async reader => await userMapper.MapBook(reader),
               p => { p.AddWithValue("@UserId", userId); });
        }
        
        public async Task<bool> returnBook(List<int> id)
        {
            int result=await ExecuteNonQuery("ProcDeleteBookRecords",
               p=> { p.Add(new SqlParameter("@Ids", GetIDs(id))); });
            if (result > 0)
            {
                return true;
            }
            return false;

        }
        private DataTable GetIDs(List<int> ids)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            foreach (var id in ids)
            {
                dt.Rows.Add(id);
            }
            return dt;
        }

        public async Task<bool> lendingBooks(List<string> bookid, int userID)
        {
            int result = await ExecuteNonQuery("ProcAddBookRecords",
               p => { p.Add(new SqlParameter("@BookId", GetBookIDs(bookid)));
                      p.Add(new SqlParameter("@UserId", userID));
               });
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        private DataTable GetBookIDs(List<string> bookIds)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BookId");
            foreach (var id in bookIds)
            {
                dt.Rows.Add(id);
            }
            return dt;
        }
    }
}
    