using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IProfileRepository
    {
        public Applicationuser getProfile(string userName);
        public string getProfileId(string userName);
    }

}
