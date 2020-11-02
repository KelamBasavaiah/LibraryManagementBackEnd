using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMDAL
{
    public class userRepository : IUserRepository
    {
        SqlConnection conn;
        SqlCommand cmduser,cmdBooks,cmdlendBooks,cmdBook,cmdPaswd;
        public userRepository()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conBook"].ConnectionString);
            OpenConnection();
        }
        void OpenConnection()
        {
            if (conn.State != ConnectionState.Closed)
                conn.Close();
            conn.Open();
        }
        public login getUser(string username)
        {
            login login = new login();
            cmduser = new SqlCommand("getUser", conn);
            cmduser.Parameters.AddWithValue("@username", username);
            cmduser.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            try
            {
                SqlDataReader dr = cmduser.ExecuteReader();
                while (dr.Read())
                {
                    login.userId = Convert.ToInt32(dr[0]);
                    login.password = Convert.ToString(dr[1]);
                    login.role= Convert.ToString(dr[2]);
                    login.username = username;
                }

            }
            catch (Exception)
            {

               
            }
            conn.Close();
            return login;
        }
        public async Task<List<User>> getAllbooksforUser(int userId)
        {
            List<User> books = new List<User>();
            cmdBooks = new SqlCommand("ProcGetBookRecords", conn);
            cmdBooks.Parameters.AddWithValue("@UserId", userId);
            cmdBooks.CommandType = CommandType.StoredProcedure;
            await Task.Run(() =>
            {
                OpenConnection();
                SqlDataReader drbook = cmdBooks.ExecuteReader();
                User book = null;
                while (drbook.Read())
                {
                    book = new User();
                    book.id = Convert.ToInt32(drbook[0].ToString());
                    book.userId = Convert.ToInt32(drbook[1].ToString());
                    book.bookId = drbook[2].ToString();
                    book.dueDate = Convert.ToDateTime(drbook[3].ToString());
                    book.bookName = drbook[4].ToString();
                    books.Add(book);
                }
            });
            conn.Close();
            return books;
        }
        public async Task<bool> returnBook(int id)
        {
            bool result = false;
            cmdBook = new SqlCommand("ProcDeleteBookRecords", conn);
            cmdBook.Parameters.AddWithValue("@Id", id);
            cmdBook.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            await Task.Run(() =>
            {
                if (cmdBook.ExecuteNonQuery() > 0)
                {
                    result = true;
                }

            });
            conn.Close();
            return result;
        }
        public async Task<bool> lendingBooks(string bookid, int userID)
        {
            bool lendBook = false;
            cmdlendBooks = new SqlCommand("ProcAddBookRecords", conn);
            cmdlendBooks.Parameters.AddWithValue("@UserId", userID);
            cmdlendBooks.Parameters.AddWithValue("@bookId", bookid);
            cmdlendBooks.CommandType = CommandType.StoredProcedure;
            await Task.Run(() =>
            {
                OpenConnection();
                if (cmdlendBooks.ExecuteNonQuery() > 0)
                {
                    lendBook = true;
                }
            });
            conn.Close();
            return lendBook;
        }
        public async Task<bool> checkingOldPassword(int userId, string oldPassword)
        {
            bool result = false;
            cmdPaswd = new SqlCommand("CheckingOldPassword", conn);
            cmdPaswd.Parameters.AddWithValue("@userId", userId);
            cmdPaswd.Parameters.AddWithValue("@oldPassword", oldPassword);
            cmdPaswd.CommandType = CommandType.StoredProcedure;
            await Task.Run(() =>
            {
                OpenConnection();
                SqlDataReader drUser = cmdPaswd.ExecuteReader();
                while (drUser.Read())
                {
                    result = Convert.ToBoolean(drUser[0].ToString());
                }
            });
            conn.Close();
            return result;
        }
        public async Task<bool> updatePassword(int userId, string newPassword)
        {
            bool result = false;
            cmdPaswd = new SqlCommand("ProcAddBookRecords", conn);
            cmdPaswd.Parameters.AddWithValue("@userId", userId);
            cmdPaswd.Parameters.AddWithValue("@bookId", newPassword);
            cmdPaswd.CommandType = CommandType.StoredProcedure;
            await Task.Run(() =>
            {
                OpenConnection();
                if (cmdPaswd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
            });
            conn.Close();
            return result;
        }
    }
}
    