using System;
using System.Collections.Generic;
using StockNews.Entities;
using System.Linq;
using StockNews.Models;
using System.Threading.Tasks;



namespace StockNews.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly StockNewsContext db;
        public CommentsRepository(StockNewsContext db)
        {
            this.db = db;
        }
        public IQueryable<Comment> GetCommentsByNewsIdIQueryable(string newsId)
        {
            return db.Comments.Where(c => c.NewsId == newsId);
        }
    }
}
