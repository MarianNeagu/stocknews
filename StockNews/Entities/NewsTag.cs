using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Entities
{
    public class NewsTag
    {
        public string NewsId { get; set; }
        public string TagId { get; set; }
        public News News { get; set; }
        public Tag Tag { get; set; }
    }
}
