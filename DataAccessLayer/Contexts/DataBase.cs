using DataAccessLayer.Models;
using DataAccessLayer.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class DataBase : IdentityDbContext<Applicationuser>
    {
        public DataBase(DbContextOptions options) : base(options) { }
        public DbSet<RegisterViewModel> RegisterViewModel { get; set; } = default!;
        public DbSet<LoginViewModel> LoginViewModel { get; set; } = default!;


    }

}
