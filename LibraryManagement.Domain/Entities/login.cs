using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class login
    {
        public int userId { get; set; }
        public string username { get; set; }

        public string password { get; set; }
        public string role { get; set; }
        public bool aurthorize { get; set; }

    }
}
