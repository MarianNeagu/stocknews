using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Entities
{
    public class Rating
    {
        public string Id { get; set; }
        public int NrOfUpvotes { get; set; }
        public string NewsId { get; set; }
        public News News { get; set; }
        public ICollection<UserRating> UserRatings { get; set; }
    }
}
