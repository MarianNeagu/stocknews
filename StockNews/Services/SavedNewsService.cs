using StockNews.Entities;
using StockNews.Models;
using StockNews.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public class SavedNewsService : ISavedNewsService
    {
        private readonly ISavedNewsRepository savedNewsRepository;
        public SavedNewsService(ISavedNewsRepository savedNewsRepository)
        {
            this.savedNewsRepository = savedNewsRepository;
        }

        public List<News> GetSavedNews(string username)
        {
            return savedNewsRepository.GetSavedNewsIQueryable(username).ToList();
        }

        public void SaveNews(SavedNewsModel savedNewsModel)
        {
            var newSavedNews = new SavedNews
            {
                Id = (savedNewsModel.userId + savedNewsModel.newsId),
                UserId = savedNewsModel.userId,
                NewsId = savedNewsModel.newsId
            };
            savedNewsRepository.SaveNews(newSavedNews);
        }
    }
}
