using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class Book
    {
        int  edition, price, copies, contactNo;
        string id,name, authorName, publisher, genres;
        DateTime publishedDate;

        public string Id { get => id; set => id = value; }
        public int Edition { get => edition; set => edition = value; }
        public int Price { get => price; set => price = value; }
        public int Copies { get => copies; set => copies = value; }
        public int ContactNo { get => contactNo; set => contactNo = value; }
        public string Name { get => name; set => name = value; }
        public string AuthorName { get => authorName; set => authorName = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public string Genres { get => genres; set => genres = value; }
        public DateTime PublishedDate { get => publishedDate; set => publishedDate = value; }

    }
}
