using StockNews.Entities;
using StockNews.Models;
using StockNews.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository newsRepository;
        public NewsService(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }
        public List<News> GetNews()
        {
            return newsRepository.GetNewsIQueryable().ToList();
        }

        public List<News> GetNewsByTag(string tagName)
        { 
            return newsRepository.GetNewsByTagIQueryable(tagName).ToList();
        }
    }
}
