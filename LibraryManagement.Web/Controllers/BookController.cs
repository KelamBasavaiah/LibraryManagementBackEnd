using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryManagement.Web.Controllers
{
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
        public List<Book> Get(string id)
        {
            return bookBL.GetBook(id);
        }

        // POST: api/Book
        public void Post([FromBody]string value)
        {
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
