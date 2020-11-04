using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> GetAllBooks()
        {
            
            try
            {
                var result = await bookBL.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetBook")]
        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                return Ok(await bookBL.GetBook(id));
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.NotFound,ex.Message);
            }
            
        }

        [HttpPost]
        [Route("addBook")]
        public async Task<IHttpActionResult> addBook([FromBody]Book book)
        {
            try
            {
                return Ok(await bookBL.AddBook(book));
            }
            catch(Exception ex)
            {
                return Ok(false);
            }
        }

        [HttpPut]
        [Route("updateBook")]
        public async Task<IHttpActionResult> updateBook(string id, [FromBody]Book book)
        {
            
            try
            {
                return Ok(await bookBL.UpdateBook(id, book));
            }
            catch (Exception ex)
            {

                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }

       [HttpDelete]
       [Route("deleteBook")]
        public async Task<IHttpActionResult> Delete(string id)
        {            
            try
            {
                return Ok(await bookBL.DeleteBook(id));
            }
            catch (Exception ex)
            {

                return Ok(false);
            }
        }
    }
}
