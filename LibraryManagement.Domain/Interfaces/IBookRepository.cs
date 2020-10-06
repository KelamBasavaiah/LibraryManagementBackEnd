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

        List<Book> GetBook(string id);
        
    }
}
