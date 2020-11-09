using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.LMDAL.Mappers;
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
    public class BookRepository :BaseRepository, IBookRepository
    {   
        public async Task<List<Book>> GetAll()
        {        
            return await ExecuteReader("GetAllBooks",
                                        async reader => await BookMapper.MapBooks(reader), p => { });
        }
        public async Task<Book> GetBook(string id)
        {
            return await ExecuteReader("GetBook",
                async reader => await BookMapper.MapBook(reader),
                p => { p.AddWithValue("@Id", id); });
        }
        public async Task<bool> AddBook(Book book)
        {   
           int result= await ExecuteNonQuery("AddBooks",
                p => {
                    p.AddWithValue("@Id", book.id);
                    p.AddWithValue("@BookName", book.name);
                    p.AddWithValue("@AuthorName", book.author_name);
                    p.AddWithValue("@Contact", book.contact);
                    p.AddWithValue("@Price", book.price);
                    p.AddWithValue("@Copies", book.copies);
                    p.AddWithValue("@Edition", book.edition);
                    p.AddWithValue("@PublishedDate", book.publishedDate);
                    p.AddWithValue("@Publisher", book.publisher);
                    p.AddWithValue("@Genres", book.genres);
                });
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateBook(string id, Book book)
        {            
            int result= await ExecuteNonQuery("UpdateBook",
               p => {
                   p.AddWithValue("@Id",id);
                   p.AddWithValue("@BookName", book.name);
                   p.AddWithValue("@AuthorName", book.author_name);
                   p.AddWithValue("@Contact", book.contact);
                   p.AddWithValue("@Price", book.price);
                   p.AddWithValue("@Copies", book.copies);
                   p.AddWithValue("@Edition", book.edition);
                   p.AddWithValue("@PublishedDate", book.publishedDate);
                   p.AddWithValue("@Publisher", book.publisher);
                   p.AddWithValue("@Genres", book.genres);
               });
            if (result>0)
            {
                return true;
            }
            return false;
        }


        public async Task<bool> DeleteBook(string bookId)
        {           
            int result = await ExecuteNonQuery("deleteBook",
                p => {
                    p.AddWithValue("@bookId", bookId);

                });
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
