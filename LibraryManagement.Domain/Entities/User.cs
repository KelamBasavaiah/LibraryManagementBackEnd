using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class User
    {
        string BookId;
        DateTime DueDate;
        int Id, UserId;

        public int userId { get => UserId; set => UserId = value; }
        public string bookId { get => BookId; set => BookId = value; }
        public DateTime dueDate { get => DueDate; set => DueDate = value; }
        public int id { get => Id; set => Id = value; }

    }
}
