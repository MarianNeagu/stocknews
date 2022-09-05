﻿using StockNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Repositories
{
    public interface ICommentsRepository
    {
        IQueryable<Comment> GetCommentsByNewsIdIQueryable(string newsId);
    }
}
