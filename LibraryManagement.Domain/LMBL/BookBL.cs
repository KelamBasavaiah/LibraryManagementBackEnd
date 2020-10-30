using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMBL
{
    public class BookBL:IBookBL
    {
        private IBookRepository bookObj;

        public BookBL(IBookRepository bookObj)
        {
           this.bookObj = bookObj;
        }

        public async Task<bool> DeleteBook(string bookId)
        {
            return await bookObj.DeleteBook(bookId);
        }

        public async Task<List<Book>> GetAll()
        {
            return await bookObj.GetAll();
        }

        public async Task<Book>  GetBook(string id)
        {
            return await bookObj.GetBook(id);
        }
        public async Task<bool> AddBook(Book book)
        {
            return await bookObj.AddBook(book);
        }
        public async Task<bool> UpdateBook(string id,Book book)
        {
            return await bookObj.UpdateBook(id, book);
        }
    }
}
