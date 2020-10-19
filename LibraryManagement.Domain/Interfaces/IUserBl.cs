using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Interfaces
{
   public interface IUserBl
    {
        bool getUser(string username,string password);
    }
}
