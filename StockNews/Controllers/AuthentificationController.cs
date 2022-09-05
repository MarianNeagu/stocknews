using Microsoft.AspNetCore.Mvc;
using StockNews.Models;
using StockNews.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService AuthenticationService;

        public AuthenticationController(IAuthenticationService AuthenticationService)
        {
            this.AuthenticationService = AuthenticationService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpUserModel model)
        {
            try
            {
                await AuthenticationService.Signup(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserModel model)
        {
            try
            {
                var tokens = await AuthenticationService.Login(model);

                if (tokens != null)
                    return Ok(tokens);
                else
                {
                    return BadRequest("Something failed when creating the login session.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
