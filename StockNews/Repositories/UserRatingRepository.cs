using StockNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Repositories
{
    public class UserRatingRepository : IUserRatingRepository
    {
        private readonly StockNewsContext db;
        public UserRatingRepository(StockNewsContext db)
        {
            this.db = db;
        }
        public void SaveUserRating(UserRating userRating)
        {
            db.UserRatings.Add(userRating);
            db.SaveChanges();
        }
    }
}
