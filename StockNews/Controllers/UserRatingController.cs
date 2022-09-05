using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockNews.Models;
using StockNews.Services;
using Microsoft.AspNetCore.Authorization;

namespace StockNews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "User")]
    public class UserRatingController : Controller
    {
        public readonly IUserRatingService userRatingService;
        public UserRatingController(IUserRatingService userRatingService )
        {
            this.userRatingService = userRatingService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserRating([FromBody] UserRatingModel userRatingModel)
        {
            try
            {
                userRatingService.SaveUserRating(userRatingModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
