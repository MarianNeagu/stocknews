using Microsoft.EntityFrameworkCore;
using StockNews.Entities;
using StockNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly StockNewsContext db;
        public NewsRepository(StockNewsContext db)
        {
            this.db = db;
        }

        public IQueryable<News> GetNewsIQueryable()
        {
            return db.News;
        }

        public IQueryable<News> GetNewsByTagIQueryable(string tagName) 
        {
            var filteredNews = db.Tags
                .Join(db.NewsTags,
                    tag => tag.Id,
                    newsTags => newsTags.TagId,
                    (tag, newsTags) => new
                    {
                        newsTags.NewsId,
                        tag.Name
                    }
                )
                .Join(db.News,
                    res => res.NewsId,
                    news => news.Id,
                    (res, news) => new
                    {
                        news.Id,
                        news.Title,
                        news.Content,
                        news.PublishDate,
                        res.Name
                    }
                )
                .Where(res => res.Name == tagName)
                .Select(res => new News
                {
                    Id = res.Id,
                    Title = res.Title,
                    Content = res.Content,
                    PublishDate = res.PublishDate
                });


            return filteredNews;
        }
    }
}
