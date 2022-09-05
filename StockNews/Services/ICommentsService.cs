using System;
using System.Collections.Generic;
using System.Linq;
using StockNews.Entities;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public interface ICommentsService
    {
        List<Comment> GetCommentsByNewsId(string newsId);
    }
}
