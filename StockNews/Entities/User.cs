using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockNews.Entities
{
    public class User : IdentityUser
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<SavedNews> SavedNews { get; set; }
        public ICollection<UserRating> UserRatings { get; set; }
    }
}
