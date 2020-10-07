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

        public List<Book> GetAll()
        {
            return bookObj.GetAll();
        }

        public List<Book> GetBook(string id)
        {
            return bookObj.GetBook(id);
        }
        public bool AddBook(Book book)
        {
            return bookObj.AddBook(book);
        }
    }
}
