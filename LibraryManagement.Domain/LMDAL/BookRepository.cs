using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMDAL
{
    public class BookRepository : IBookRepository
    {
        SqlConnection conn;
        SqlCommand cmdBooks,cmdBook;
        public BookRepository()
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
        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            cmdBooks = new SqlCommand("GetAllBooks", conn);
            cmdBooks.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            SqlDataReader drbook = cmdBooks.ExecuteReader();
            Book book = null;
            while (drbook.Read())
            {
                book = new Book();
                book.Id = drbook[0].ToString();
                book.Name = drbook[1].ToString();
                book.AuthorName = drbook[2].ToString();
                book.Price = Convert.ToInt32(drbook[3]);
                book.ContactNo =Convert.ToInt32(drbook[4].ToString());
                book.Edition = Convert.ToInt32(drbook[5].ToString());
                book.PublishedDate = Convert.ToDateTime(drbook[6].ToString());
                book.Publisher = drbook[7].ToString();
                book.Copies = Convert.ToInt32(drbook[8].ToString());
                book.Genres = drbook[9].ToString();
                books.Add(book);
            }
            conn.Close();
            return books;

        }
        public List<Book> GetBook(string id)
        {
            List<Book> book = new List<Book>();
            cmdBook = new SqlCommand("GetBook", conn);
            cmdBook.Parameters.AddWithValue("@Id", id);
            cmdBook.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            SqlDataReader sqlData = cmdBook.ExecuteReader();
            Book Data = null;
            while (sqlData.Read())
            {
                Data = new Book();
                Data.Id = sqlData[0].ToString();
                Data.Name = sqlData[1].ToString();
                Data.AuthorName = sqlData[2].ToString();
                Data.Price = Convert.ToInt32(sqlData[3]);
                Data.ContactNo = Convert.ToInt32(sqlData[4].ToString());
                Data.Edition = Convert.ToInt32(sqlData[5].ToString());
                Data.PublishedDate = Convert.ToDateTime(sqlData[6].ToString());
                Data.Publisher = sqlData[7].ToString();
                Data.Copies = Convert.ToInt32(sqlData[8].ToString());
                Data.Genres = sqlData[9].ToString();
                book.Add(Data);
            }
            conn.Close();
            return book;
        }
        
    }
}
