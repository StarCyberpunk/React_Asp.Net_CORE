using reactsite.Domain.Entity;
using reactsite.Domain.Response;
using reactsite.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace reactsite.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<string>> Register(RegisterViewModel rvm);
        Task<BaseResponse<string>> Login(LoginViewModel model);
        Task<BaseResponse<IEnumerable<User>>> GetAllUsers();
        Task<BaseResponse<User>> GetUser(string name);


    }
}
