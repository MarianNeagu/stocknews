﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Entities
{
    public class Tag
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<NewsTag> NewsTags { get; set; }
    }
}
