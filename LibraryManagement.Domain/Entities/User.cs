using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class User
    {
        string UserName,BookId;
        DateTime DueDate;

        public string userName { get => UserName; set => UserName = value; }
        public string bookId { get => BookId; set => BookId = value; }
        public DateTime dueDate { get => DueDate; set => DueDate = value; }
    }
}
