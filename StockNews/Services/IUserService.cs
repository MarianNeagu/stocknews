using StockNews.Entities;
using StockNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public interface IUserService
    {
        List<User> GetUsersByUsername(string username);
        List<User> GetUsersByEmail(string email);
        void DeleteUserByUsername(string username);
        void UpdateUsername(UserModel userModel);
    }
}
