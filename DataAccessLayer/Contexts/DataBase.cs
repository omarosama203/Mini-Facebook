using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class DataBase:DbContext
    {
       public DataBase(DbContextOptions<DataBase> options):base(options) { } 
        public DbSet<Department> departments {  get; set; }
    }

}
