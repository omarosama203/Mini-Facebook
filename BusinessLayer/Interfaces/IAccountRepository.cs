using DataAccessLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    internal interface IAccountRepository
    {
        public void Register(RegisterViewModel userVm);
    }
}
