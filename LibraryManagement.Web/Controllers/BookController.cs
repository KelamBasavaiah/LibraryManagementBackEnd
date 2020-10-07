using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LibraryManagement.Web.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT")]
    public class BookController : ApiController
    {
        public IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
        // GET: api/Book
        public List<Book> Get()
        {
            return bookBL.GetAll();
        }

        // GET: api/Book/5
        public Book Get(string id)
        {
            return bookBL.GetBook(id);
        }

        // POST: api/Book
        public bool Post([FromBody]Book book)
        {
            try
            {
                return bookBL.AddBook(book);
            }
            catch(Exception e)
            {
                return false;
            }
        }

        // PUT: api/Book/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Book/5
        public bool Delete(string id)
        {
            return bookBL.DeleteBook(id);
        }
    }
}
