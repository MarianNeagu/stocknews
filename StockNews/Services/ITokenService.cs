using StockNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
