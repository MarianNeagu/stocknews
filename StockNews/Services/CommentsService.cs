using System;
using StockNews.Entities;
using StockNews.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository commentsRepository;
        public CommentsService(ICommentsRepository commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }
        public List<Comment> GetCommentsByNewsId(string newsId)
        {
            return commentsRepository.GetCommentsByNewsIdIQueryable(newsId).ToList();
        }
    }
}
