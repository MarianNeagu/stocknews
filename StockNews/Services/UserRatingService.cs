using StockNews.Entities;
using StockNews.Models;
using StockNews.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public class UserRatingService : IUserRatingService
    {
        private readonly IUserRatingRepository userRatingRepository;
        public UserRatingService(IUserRatingRepository userRatingRepository)
        {
            this.userRatingRepository = userRatingRepository;
        }

        public void SaveUserRating(UserRatingModel userRatingModel)
        {
            var userRating = new UserRating
            {
                UserId = userRatingModel.userId,
                RatingId = userRatingModel.ratingId
            };
            userRatingRepository.SaveUserRating(userRating);
        }
    }
}
