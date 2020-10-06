using LibraryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMDAL
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
