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
    public class DepartmentRepo:IDepartmentRepo
    {
       private readonly DataBase db;
       public  DepartmentRepo(DataBase db)
        {
            this.db = db;
        }

        public ICollection<Department> getAll()
        {
            return db.departments.ToList();
        }
    }
}
