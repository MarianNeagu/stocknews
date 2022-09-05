using StockNews.Entities;
using StockNews.Models;
using StockNews.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public List<User> GetUsersByUsername(string username)
        {
            return userRepository.GetUsersByUsernameIQueryable(username).ToList();
        }
        public List<User> GetUsersByEmail(string email)
        {
            return userRepository.GetUsersByEmailIQueryable(email).ToList();
        }

        public void DeleteUserByUsername(string username)
        {
            var usersWithUsername = GetUsersByUsername(username);
            if(usersWithUsername.Count() == 1)
            {
                User userToDelete = usersWithUsername[0];
                userRepository.DeleteUser(userToDelete);
            }
            else
            {
                throw new Exception("No users with the given username to delete.");
            }

        }

        public void UpdateUsername(UserModel userModel)
        {
            // find the user that wants to update his username
            var usersWithEmail = GetUsersByEmail(userModel.Email);
            if(usersWithEmail.Count() == 1)
            {
                // check if the new given username is already in database
                if(GetUsersByUsername(userModel.Username).Count() == 0)
                {
                    User userToUpdate = usersWithEmail[0];
                    userToUpdate.UserName = userModel.Username;
                    userToUpdate.NormalizedUserName = userModel.Username.ToUpper();
                    userRepository.UpdateUser(userToUpdate);
                }
                else
                {
                    throw new Exception("Sorry, the given username is already taken.");
                }
            }
            else
            {
                throw new Exception("Error! Can't find user.");
            }
        }
    }
}
