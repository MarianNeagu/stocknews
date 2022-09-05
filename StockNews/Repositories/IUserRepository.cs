using StockNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsersByUsernameIQueryable(string username);
        IQueryable<User> GetUsersByEmailIQueryable(string email);
        void DeleteUser(User userToDelete);
        void UpdateUser(User userToUpdate);
    }
}
