using StockNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Repositories
{
    public class SavedNewsRepository : ISavedNewsRepository
    {
        private readonly StockNewsContext db;
        public SavedNewsRepository(StockNewsContext db)
        {
            this.db = db;
        }
        public IQueryable<News> GetSavedNewsIQueryable(string username)
        {
            var savedNews = db.Users
                .Join(db.SavedNews,
                    u => u.Id,
                    sn => sn.UserId,
                    (u, sn) => new
                    {
                        u.UserName,
                        sn.NewsId
                    }
                )
                .Join(db.News,
                    res => res.NewsId,
                    n => n.Id,
                    (res, n) => new
                    {
                        n.Id,
                        n.Title,
                        n.Content,
                        n.PublishDate,
                        res.UserName
                    }
                )
                .Where(res => res.UserName == username)
                .Select(res => new News
                {
                    Id = res.Id,
                    Title = res.Title,
                    Content = res.Content,
                    PublishDate = res.PublishDate
                });

            return savedNews;
        }

        public void SaveNews(SavedNews newSavedNews)
        {
            db.SavedNews.Add(newSavedNews);
            db.SaveChanges();
        }
    }
}
