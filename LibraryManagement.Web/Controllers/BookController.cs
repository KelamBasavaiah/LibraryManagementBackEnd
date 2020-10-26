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
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]
    [RoutePrefix("Book")]
    public class BookController : ApiController
    {
        public IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
       
        [HttpGet]
        [Route("GetAllBooks")]
        public List<Book> GetAllBooks()
        {
            return bookBL.GetAll();
        }

        [HttpGet]
        [Route("GetBook")]
        public Book Get(string id)
        {
            return bookBL.GetBook(id);
        }

        [HttpPost]
        [Route("addBook")]
        public bool addBook([FromBody]Book book)
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

        [HttpPut]
        [Route("updateBook")]
        public bool updateBook(string id, [FromBody]Book book)
        {
            return bookBL.UpdateBook(id, book);
        }

       [HttpDelete]
       [Route("deleteBook")]
        public bool Delete(string id)
        {            
            try
            {
                return bookBL.DeleteBook(id);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
