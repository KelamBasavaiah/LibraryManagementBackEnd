using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

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
        public string getUser(string username)
        {
            string passowrd = "";
            cmduser = new SqlCommand("getUser", conn);
            cmduser.Parameters.AddWithValue("@username", username);
            cmduser.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            try
            {
                SqlDataReader dr = cmduser.ExecuteReader();
                while (dr.Read())
                {
                    passowrd = Convert.ToString(dr[1]);
                }

            }
            catch (Exception)
            {

                passowrd = "";
            }
            conn.Close();
            return passowrd;
        }
        public List<User> getAllbooksforUser(int userId)
        {
            List<User> books = new List<User>();
            cmdBooks = new SqlCommand("ProcGetBookRecords", conn);
            cmdBooks.Parameters.AddWithValue("@UserId", userId);
            cmdBooks.CommandType = CommandType.StoredProcedure;
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
                books.Add(book);
            }
            conn.Close();
            return books;
        }
        public bool returnBook(int id)
        {
            bool result = false;
            cmdBook = new SqlCommand("ProcDeleteBookRecords", conn);
            cmdBook.Parameters.AddWithValue("@Id", id);
            cmdBook.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            try
            {
                if (cmdBook.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;

            }
            conn.Close();
            return result;

        }
        public bool lendingBooks(string bookid, string username)
        {
            bool lendBook = false;
            cmdlendBooks = new SqlCommand("ProcAddBookRecords", conn);
            cmdlendBooks.Parameters.AddWithValue("@username", username);
            cmdlendBooks.Parameters.AddWithValue("@bookId", bookid);
            cmdlendBooks.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            if (cmdlendBooks.ExecuteNonQuery() > 0)
            {
                lendBook = true;
            }
            conn.Close();
            return lendBook;
        }
    }
}
    