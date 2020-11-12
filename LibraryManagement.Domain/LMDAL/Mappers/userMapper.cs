using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.LMDAL.Mappers
{
    public class userMapper
    {
        public static async Task<List<User>> MapBook(SqlDataReader drbook)
        {
            List<User> books = new List<User>();
            User book = null;
            while (await drbook.ReadAsync())
            {
                book = new User();
                book.id = Convert.ToInt32(drbook[0].ToString());
                book.userId = Convert.ToInt32(drbook[1].ToString());
                book.bookId = drbook[2].ToString();
                book.dueDate = Convert.ToDateTime(drbook[3].ToString());
                book.bookName = drbook[4].ToString();
                books.Add(book);
            }
            return books;
        }
        public static async Task<login> Login(SqlDataReader dr)
        {
            login login = new login();
            while (await dr.ReadAsync())
            {
                login.userId = Convert.ToInt32(dr[0]);
                login.password = Convert.ToString(dr[1]);
                login.role = Convert.ToString(dr[2]);
                login.username = Convert.ToString(dr[3]);
            }
            return login;
        }


    }
}
