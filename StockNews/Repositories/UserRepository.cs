using StockNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StockNewsContext db;

        public UserRepository(StockNewsContext db)
        {
            this.db = db;
        }

        public IQueryable<User> GetUsersByEmailIQueryable(string email)
        {
            return db.Users.Where(u => u.NormalizedEmail == email);
  
        }

        public IQueryable<User> GetUsersByUsernameIQueryable(string username)
        {
            return db.Users.Where(u => u.NormalizedUserName == username);
        }

        public void DeleteUser(User userToDelete)
        {
            db.Users.Remove(userToDelete);
            db.SaveChanges();
        }

        public void UpdateUser(User userToUpdate)
        {
            db.Users.Update(userToUpdate);
            db.SaveChanges();
        }
    }
}
