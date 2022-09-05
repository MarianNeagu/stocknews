using StockNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public interface IAuthenticationService
    {
        Task Signup(SignUpUserModel signupUserModel);
        Task<TokenModel> Login(LoginUserModel loginUserModel);
    }
}
