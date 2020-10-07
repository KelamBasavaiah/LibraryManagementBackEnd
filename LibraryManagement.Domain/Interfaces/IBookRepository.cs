using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Interfaces
{
   public interface IBookRepository
    {
        List<Book> GetAll();

        Book GetBook(string id);
        bool AddBook(Book book);


        bool DeleteBook(string bookId);
        
    }
}
