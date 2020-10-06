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

        public IEnumerable<string> Get()
        {
            return bookObj.Get();
        }
    }
}
