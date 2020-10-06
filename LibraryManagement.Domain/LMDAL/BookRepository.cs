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
        SqlCommand cmdBooks;
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
                book.Price = Convert.ToInt32(drbook[3].ToString());
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
        
    }
}
