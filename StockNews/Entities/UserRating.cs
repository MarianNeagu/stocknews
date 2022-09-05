using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Entities
{
    public class UserRating
    {
        public string UserId { get; set; }
        public string RatingId { get; set; }
        public User User;
        public Rating Rating;
    }
}
