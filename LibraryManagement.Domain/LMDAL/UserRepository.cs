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
        SqlCommand cmduser,cmdBooks,cmdlendBooks,cmdBook;
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
        
        public async Task<bool> returnBook(List<int> id)
        {
            bool result = false;
            cmdBook = new SqlCommand("ProcDeleteBookRecords", conn);
            cmdBook.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@Ids";
            parameter.Value = GetIDs(id);
            cmdBook.Parameters.Add(parameter);
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
            bool lendBook = false;
            cmdlendBooks = new SqlCommand("ProcAddBookRecords", conn);
            cmdlendBooks.CommandType = CommandType.StoredProcedure;
            cmdlendBooks.Parameters.Add(new SqlParameter("@BookId", GetBookIDs(bookid)));
            cmdlendBooks.Parameters.Add(new SqlParameter("@UserId",userID));
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
    