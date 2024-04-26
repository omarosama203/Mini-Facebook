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
    public class UserRepository : IUserRepository
    {
        DataBase db;
        public UserRepository(DataBase db)
        {
            this.db = db;
        }

        public List<Applicationuser> searchUser(string name)
        {
            return db.Users.Where(u => (u.FirstName + " " + u.LastName).ToLower().Contains(name.ToLower())).ToList();
        }
        public List<Applicationuser> getUsers(string id )
        {
            var users=db.Users.ToList();
            var random = new Random();
           return  users.Where(u=>u.Id!=id).OrderBy(u => random.Next()).Take(3).ToList();
            
        }
        public Applicationuser getUserById(string id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
        public Applicationuser EditUser(Applicationuser user) 
        {
            db.Users.Update(user);
            db.SaveChanges();
            return user;
        }
    }
}
