using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockNews.Models;
using StockNews.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "User")]
    public class SavedNewsController : Controller
    {
        private readonly ISavedNewsService savedNewsService;
        public SavedNewsController(ISavedNewsService savedNewsService)
        {
            this.savedNewsService = savedNewsService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetSavedNews([FromRoute] string username)
        {

            var savedNews = savedNewsService.GetSavedNews(username);

            return Ok(savedNews);

            // TODO: numai userul isi poate vedea propriile Saved News
            string actualUsernameOfUser = User.Identity.Name; // nu merge
            if (actualUsernameOfUser == username)
            {

            }
            else
            {
                return BadRequest("You can't acces data of other users!");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddSavedNews([FromBody] SavedNewsModel savedNewsModel)
        {
            try
            {
                savedNewsService.SaveNews(savedNewsModel);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}
