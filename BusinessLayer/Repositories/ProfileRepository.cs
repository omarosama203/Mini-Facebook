using BusinessLayer.Interfaces;
using DataAccessLayer.Contexts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DataBase db;

        public ProfileRepository(DataBase db)
        {
            this.db = db;
        }
        public Applicationuser getProfile(string userName)
        {
            return db.Users.FirstOrDefault(user => user.UserName == userName);
        }

        public string getProfileId(string userName)
        {
            return db.Users.FirstOrDefault(user => user.UserName == userName).Id;
        }
    }
}
