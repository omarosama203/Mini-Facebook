using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserRepository
    {
        public List<Applicationuser> searchUser(string name);
        public List<Applicationuser> getUsers();
    }
    
}
