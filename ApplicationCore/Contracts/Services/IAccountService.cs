using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IAccountService
    {
        public Task<bool> RegisterUser(RegisterModel registerModel);
        public Task<bool> ValidateUser(LoginModel loginModel);
    }
}
