using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Interfaces
{
    public interface IBookBL
    {
        Task<List<Book>> GetAll();

        Task<Book> GetBook(string id);
        Task<bool> DeleteBook(string bookId);
        Task<bool> AddBook(Book book);
        Task<bool> UpdateBook(string id, Book book);
    }
}
