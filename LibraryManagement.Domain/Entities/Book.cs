using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class Book
    {

        int Edition, Price, Copies;long contactNo;

        string Id, Name, authorName, Publisher, Genres;
        DateTime PublishedDate;

        public string id { get => Id; set => Id = value; }
        public int edition { get => Edition; set => Edition = value; }
        public int price { get => Price; set => Price = value; }
        public int copies { get => Copies; set => Copies = value; }
        public long contact { get => contactNo; set => contactNo = value; }
        public string name { get => Name; set => Name = value; }
        public string author_name { get => authorName; set => authorName = value; }
        public string publisher { get => Publisher; set => Publisher = value; }
        public string genres { get => Genres; set => Genres = value; }
        public DateTime publishedDate { get => PublishedDate; set => PublishedDate = value; }

    }
}
