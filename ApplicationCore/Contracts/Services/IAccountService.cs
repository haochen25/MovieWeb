using ApplicationCore.Entities;
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
        public Task<User> RegisterUser(RegisterModel registerModel);
        public Task<UserInfoModel> ValidateUser(LoginModel loginModel);
    }
}
