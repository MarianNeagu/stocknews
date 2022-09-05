using Microsoft.AspNetCore.Identity;
using StockNews.Entities;
using StockNews.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenService tokenManager;
        private readonly IUserService userService;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager,
            ITokenService tokenManager, IUserService userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenManager = tokenManager;
            this.userService = userService;
        }

        public async Task Signup(SignUpUserModel signupUserModel)
        {
            
            // check if username or email exists already in database
            if (userService.GetUsersByUsername(signupUserModel.Username.ToUpper()).Count == 0 && 
                userService.GetUsersByEmail(signupUserModel.Email.ToUpper()).Count == 0)
            {
                var user = new User
                {
                    Email = signupUserModel.Email,
                    UserName = signupUserModel.Username
                };
                var result = await userManager.CreateAsync(user, signupUserModel.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, signupUserModel.RoleId);
                }
            }
            else throw new Exception("Email or username already taken." + userService.GetUsersByUsername(signupUserModel.Username));
    
            
        }

        public async Task<TokenModel> Login(LoginUserModel loginUserModel)
        {
            var user = await userManager.FindByEmailAsync(loginUserModel.Email);
            if (user != null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginUserModel.Password, false);
                if (result.Succeeded)
                {
                    //Create token
                    var token = await tokenManager.CreateToken(user); //new manager responsible with creating the token

                    return new TokenModel { Token = token };
                }
            }

            return null;
        }
    }
}
