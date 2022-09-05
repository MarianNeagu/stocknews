using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Entities 
{
    public class News
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public Rating Rating { get; set; }
        public ICollection<SavedNews> SavedNews { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<NewsTag> NewsTags { get; set; }
    }
}
