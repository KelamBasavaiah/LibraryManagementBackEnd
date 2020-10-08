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
                book.id = drbook[0].ToString();
                book.name = drbook[1].ToString();
                book.author_name = drbook[2].ToString();
                book.price = Convert.ToInt32(drbook[3]);
                book.contact =Convert.ToInt64(drbook[4].ToString());
                book.edition = Convert.ToInt32(drbook[5].ToString());
                book.publishedDate = Convert.ToDateTime(drbook[6].ToString());
                book.publisher = drbook[7].ToString();
                book.copies = Convert.ToInt32(drbook[8].ToString());
                book.genres = drbook[9].ToString();
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
                book.id = sqlData[0].ToString();
                book.name = sqlData[1].ToString();
                book.author_name = sqlData[2].ToString();
                book.price = Convert.ToInt32(sqlData[3]);
                book.contact = Convert.ToInt64(sqlData[4].ToString());
                book.edition = Convert.ToInt32(sqlData[5].ToString());
                book.publishedDate = Convert.ToDateTime(sqlData[6].ToString());
                book.publisher = sqlData[7].ToString();
                book.copies = Convert.ToInt32(sqlData[8].ToString());
                book.genres = sqlData[9].ToString();
            } 
            conn.Close();
            return book;
        }
        public bool AddBook(Book book)
        {
            bool inserted = false;
            cmdAddBooks = new SqlCommand("AddBooks", conn);
            cmdAddBooks.Parameters.AddWithValue("@Id", book.id);
            cmdAddBooks.Parameters.AddWithValue("@BookName", book.name);
            cmdAddBooks.Parameters.AddWithValue("@AuthorName", book.author_name);
            cmdAddBooks.Parameters.AddWithValue("@Contact", book.contact);
            cmdAddBooks.Parameters.AddWithValue("@Price", book.price);
            cmdAddBooks.Parameters.AddWithValue("@Copies", book.copies);
            cmdAddBooks.Parameters.AddWithValue("@Edition", book.edition);
            cmdAddBooks.Parameters.AddWithValue("@PublishedDate", book.publishedDate);
            cmdAddBooks.Parameters.AddWithValue("@Publisher", book.publisher);
            cmdAddBooks.Parameters.AddWithValue("@Genres", book.genres);
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
