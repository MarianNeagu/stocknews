using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockNews.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "User")]
    public class NewsController : Controller
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNews()
        {
            var news = newsService.GetNews();
            return Ok(news);
        }

        [HttpGet("{tagName}")]
        public async Task<IActionResult> GetNewsByTag([FromRoute] string tagName)
        {
            var filteredNews = newsService.GetNewsByTag(tagName);
            if (filteredNews.Count() != 0)
                return Ok(filteredNews);
            else return NotFound("ERROR 404: There are no news with the given tag!");
        }
    }
}
