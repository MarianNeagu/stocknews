﻿using StockNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public interface IUserRatingService
    {
        void SaveUserRating(UserRatingModel userRatingModel);
    }
}
