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
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /*[Authorize(Policy = "Admin")]*/
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUserByUsername([FromRoute] string username)
        {
            try
            {
                userService.DeleteUserByUsername(username);
                return Ok("User deleted!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // id passed in user model can be whatever
        /*[Authorize(Policy = "User")]*/
        [HttpPut]
        public async Task<IActionResult> UpdateUsername([FromBody] UserModel userModel)
        {
            try
            {
                userService.UpdateUsername(userModel);
                return Ok("Username changed!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
