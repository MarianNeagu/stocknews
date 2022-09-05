using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Entities
{
    public class SavedNews
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string NewsId { get; set; }
        public User User { get; set; }
        public News News { get; set; }
    }
}
