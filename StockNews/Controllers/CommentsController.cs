using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Mvc;
using StockNews.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }
        
        [HttpGet("{newsId}")]
        public async Task<IActionResult> GetCommentsByNewsId([FromRoute] string newsId)
        {
            var comments = commentsService.GetCommentsByNewsId(newsId);
            return Ok(comments);
        }
    }
}
