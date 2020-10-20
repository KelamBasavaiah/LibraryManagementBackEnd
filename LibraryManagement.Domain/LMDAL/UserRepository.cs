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
        SqlCommand cmduser,cmdBooks;
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
        public List<User> getAllbooksforUser(string userName)
        {
            List<User> books = new List<User>();
            cmdBooks = new SqlCommand("ProcGetBookRecords", conn);
            cmdBooks.Parameters.AddWithValue("@UserName", userName);
            cmdBooks.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            SqlDataReader drbook = cmdBooks.ExecuteReader();
            User book = null;
            while (drbook.Read())
            {
                book = new User();
                book.userName = drbook[0].ToString();
                book.bookId = drbook[1].ToString();
                book.dueDate = Convert.ToDateTime(drbook[2].ToString());
                books.Add(book);
            }
            conn.Close();
            return books;
        }
    }
}
    