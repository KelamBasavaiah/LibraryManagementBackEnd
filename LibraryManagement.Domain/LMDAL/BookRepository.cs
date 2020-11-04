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
        public async Task<List<Book>> GetAll()
        {
            List<Book> books = new List<Book>();
            cmdBooks = new SqlCommand("GetAllBooks", conn);
            cmdBooks.CommandType = CommandType.StoredProcedure;
            
            Book book = null;
            await Task.Run(() =>
            {
                OpenConnection();
                SqlDataReader drbook = cmdBooks.ExecuteReader();
                while (drbook.Read())
                {
                    book = new Book();
                    book.id = drbook[0].ToString();
                    book.name = drbook[1].ToString();
                    book.author_name = drbook[2].ToString();
                    book.price = Convert.ToInt32(drbook[3]);
                    book.contact = Convert.ToInt64(drbook[4].ToString());
                    book.edition = Convert.ToInt32(drbook[5].ToString());
                    book.publishedDate = Convert.ToDateTime(drbook[6].ToString());
                    book.publisher = drbook[7].ToString();
                    book.copies = Convert.ToInt32(drbook[8].ToString());
                    book.genres = drbook[9].ToString();
                    books.Add(book);
                }
            });
            conn.Close();
            return books;

        }
        public async Task<Book> GetBook(string id)
        {
            Book book = new Book();
            cmdBook = new SqlCommand("GetBook", conn);
            cmdBook.Parameters.AddWithValue("@Id", id);
            cmdBook.CommandType = CommandType.StoredProcedure;
            await Task.Run(() =>
            {
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
            });
            conn.Close();
            return book;
        }
        public async Task<bool> AddBook(Book book)
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
            await Task.Run(() =>
            {
                OpenConnection();
                if (cmdAddBooks.ExecuteNonQuery() > 0)
                    inserted = true;
            });
            return inserted;
        }

        public async Task<bool> UpdateBook(string id, Book book)
        {
            bool updated = false;
            cmdUpdateBook = new SqlCommand("UpdateBook", conn);
            cmdUpdateBook.Parameters.AddWithValue("@Id", id);
            cmdUpdateBook.Parameters.AddWithValue("@BookName", book.name);
            cmdUpdateBook.Parameters.AddWithValue("@AuthorName", book.author_name);
            cmdUpdateBook.Parameters.AddWithValue("@Contact", book.contact);
            cmdUpdateBook.Parameters.AddWithValue("@Price", book.price);
            cmdUpdateBook.Parameters.AddWithValue("@Copies", book.copies);
            cmdUpdateBook.Parameters.AddWithValue("@Edition", book.edition);
            cmdUpdateBook.Parameters.AddWithValue("@PublishedDate", book.publishedDate);
            cmdUpdateBook.Parameters.AddWithValue("@Publisher", book.publisher);
            cmdUpdateBook.Parameters.AddWithValue("@Genres", book.genres);
            cmdUpdateBook.CommandType = CommandType.StoredProcedure;
            OpenConnection();

            await Task.Run(() =>
            {
                if (cmdUpdateBook.ExecuteNonQuery() > 0)
                {
                    updated = true;
                }
            });
            return updated;
        }


        public async Task<bool> DeleteBook(string bookId)
        {
            bool result=false;
            cmdBook = new SqlCommand("deleteBook", conn);
            cmdBook.Parameters.AddWithValue("@bookId", bookId);        
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
    }
}
