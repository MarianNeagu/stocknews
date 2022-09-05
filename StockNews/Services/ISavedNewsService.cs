using StockNews.Entities;
using StockNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public interface ISavedNewsService
    {
        List<News> GetSavedNews(string username);
        void SaveNews(SavedNewsModel savedNewsModel);
    }
}
