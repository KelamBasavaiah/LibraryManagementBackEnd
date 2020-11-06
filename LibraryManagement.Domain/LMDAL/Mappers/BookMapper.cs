using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMDAL.Mappers
{
    public class BookMapper
    {
        public async Task<List<Book>> MapBooks(SqlDataReader drbook)
        {
            List<Book> books = new List<Book>();

            Book book = null;
            await Task.Run(() =>
            {
                while (drbook.Read())
                {
                    book = new Book();
                    book.id = drbook[0].ToString();
                    book.name = drbook[1].ToString();
                    book.author_name = drbook[2].ToString();
                    book.price = Convert.ToInt32(drbook[3]);
                    book.contact = Convert.ToInt64(drbook[4].ToString());
                    book.edition = Convert.ToInt32(drbook[5].ToString());
                    book.publishedDate = Convert.ToDateTime(drbook[6].ToString());
                    book.publisher = drbook[7].ToString();
                    book.copies = Convert.ToInt32(drbook[8].ToString());
                    book.genres = drbook[9].ToString();
                    books.Add(book);
                }
            });
            return books;

        }
    }
}
