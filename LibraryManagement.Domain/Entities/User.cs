using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class User:login
    {
        string BookId,BookName;
        DateTime DueDate;
        int? Id;
        
        public string bookId { get => BookId; set => BookId = value; }
        public DateTime dueDate { get => DueDate; set => DueDate = value; }
        public int? id { get => Id; set => Id = value; }
        public string bookName { get => BookName; set => BookName = value; }
        public string mailId { get; set; }
        public long phoneNo { get; set; }
        public int? isActive { get; set; }
        public string newPassword { get; set; }
    }
}
