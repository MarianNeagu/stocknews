using StockNews.Entities;
using StockNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Repositories
{
    public interface INewsRepository
    {
        IQueryable<News> GetNewsIQueryable();
        IQueryable<News> GetNewsByTagIQueryable(string tagName);
    }
}
