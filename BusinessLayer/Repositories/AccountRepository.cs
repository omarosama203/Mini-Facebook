using BusinessLayer.Interfaces;
using DataAccessLayer.Contexts;
using DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly DataBase _db;

        public AccountRepository(DataBase db)
        {
            _db = db;
        }
        public void Register(RegisterViewModel userVm)
        {

        }
    }
}
