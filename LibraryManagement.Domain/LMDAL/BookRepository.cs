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
        SqlCommand cmdBooks,cmdBook,cmdAddBooks,cmdUpdateBook;
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
                book.ContactNo =Convert.ToInt64(drbook[4].ToString());
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
        public Book GetBook(string id)
        {
            Book book = new Book();
            cmdBook = new SqlCommand("GetBook", conn);
            cmdBook.Parameters.AddWithValue("@Id", id);
            cmdBook.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            SqlDataReader sqlData = cmdBook.ExecuteReader();
            while (sqlData.Read())
            {
                book.Id = sqlData[0].ToString();
                book.Name = sqlData[1].ToString();
                book.AuthorName = sqlData[2].ToString();
                book.Price = Convert.ToInt32(sqlData[3]);
                book.ContactNo = Convert.ToInt64(sqlData[4].ToString());
                book.Edition = Convert.ToInt32(sqlData[5].ToString());
                book.PublishedDate = Convert.ToDateTime(sqlData[6].ToString());
                book.Publisher = sqlData[7].ToString();
                book.Copies = Convert.ToInt32(sqlData[8].ToString());
                book.Genres = sqlData[9].ToString();
            } 
            conn.Close();
            return book;
        }
        public bool AddBook(Book book)
        {
            bool inserted = false;
            cmdAddBooks = new SqlCommand("AddBooks", conn);
            cmdAddBooks.Parameters.AddWithValue("@Id", book.Id);
            cmdAddBooks.Parameters.AddWithValue("@BookName", book.Name);
            cmdAddBooks.Parameters.AddWithValue("@AuthorName", book.AuthorName);
            cmdAddBooks.Parameters.AddWithValue("@Contact", book.ContactNo);
            cmdAddBooks.Parameters.AddWithValue("@Price", book.Price);
            cmdAddBooks.Parameters.AddWithValue("@Copies", book.Copies);
            cmdAddBooks.Parameters.AddWithValue("@Edition", book.Edition);
            cmdAddBooks.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
            cmdAddBooks.Parameters.AddWithValue("@Publisher", book.Publisher);
            cmdAddBooks.Parameters.AddWithValue("@Genres", book.Genres);
            cmdAddBooks.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            if (cmdAddBooks.ExecuteNonQuery()> 0)
                inserted = true;
            return inserted;
        }

        public bool UpdateBook(string id, Book book)
        {
            bool updated = false;
            cmdUpdateBook = new SqlCommand("UpdateBook", conn);
            cmdUpdateBook.Parameters.AddWithValue("@Id", id);
            cmdUpdateBook.Parameters.AddWithValue("@BookName", book.Name);
            cmdUpdateBook.Parameters.AddWithValue("@AuthorName", book.AuthorName);
            cmdUpdateBook.Parameters.AddWithValue("@Contact", book.ContactNo);
            cmdUpdateBook.Parameters.AddWithValue("@Price", book.Price);
            cmdUpdateBook.Parameters.AddWithValue("@Copies", book.Copies);
            cmdUpdateBook.Parameters.AddWithValue("@Edition", book.Edition);
            cmdUpdateBook.Parameters.AddWithValue("@PublishedDate", book.PublishedDate);
            cmdUpdateBook.Parameters.AddWithValue("@Publisher", book.Publisher);
            cmdUpdateBook.Parameters.AddWithValue("@Genres", book.Genres);
            cmdUpdateBook.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            if(cmdUpdateBook.ExecuteNonQuery() > 0)
            {
                updated = true;
            }
            return updated;
        }


        public bool DeleteBook(string bookId)
        {
            bool result;
            cmdBook = new SqlCommand("deleteBook", conn);
            cmdBook.Parameters.AddWithValue("@bookId", bookId);        
            cmdBook.CommandType = CommandType.StoredProcedure;
            OpenConnection();
            try
            {
               var k = cmdBook.ExecuteReader();
                result = true;
               
            }
            catch (Exception)
            {
                result = false;
               
            }
            conn.Close();
            return result;
        }
    }
}
