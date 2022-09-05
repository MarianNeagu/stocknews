using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StockNews.Entities
{
    public class StockNewsContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, 
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public StockNewsContext(DbContextOptions<StockNewsContext> options) : base(options) { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsTag> NewsTags { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<SavedNews> SavedNews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // face mai intai model creating de la clasa parinte (User si Role)
            base.OnModelCreating(builder);


            // Relations:
            // Users-Comments

            builder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User);

            // Users-SavedNews

            builder.Entity<User>()
                .HasMany(u => u.SavedNews)
                .WithOne(sn => sn.User);

            // News-Comments

            builder.Entity<News>()
                .HasMany(n => n.Comments)
                .WithOne(c => c.News);

            // News-SavedNews

            builder.Entity<News>()
                .HasMany(n => n.SavedNews)
                .WithOne(sn => sn.News);

            // News-Ratings

            builder.Entity<News>()
                .HasOne(n => n.Rating)
                .WithOne(r => r.News);

            // PK NewsTag 

            builder.Entity<NewsTag>().HasKey(nt => new { nt.NewsId, nt.TagId }); // PKC

            // Tag-NewsTag & News-NewsTag

            builder.Entity<NewsTag>()
                .HasOne(nt => nt.Tag)
                .WithMany(t => t.NewsTags)
                .HasForeignKey(nt => nt.TagId);

            builder.Entity<NewsTag>()
                .HasOne(nt => nt.News)
                .WithMany(n => n.NewsTags)
                .HasForeignKey(nt => nt.NewsId);

            // PK UserRating

            builder.Entity<UserRating>().HasKey(ur => new { ur.UserId, ur.RatingId }); // PKC

            // User-UserRating & Rating-UserRating

            builder.Entity<UserRating>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRatings)
                .HasForeignKey(ur => ur.UserId);

            builder.Entity<UserRating>()
                .HasOne(ur => ur.Rating)
                .WithMany(r => r.UserRatings)
                .HasForeignKey(ur => ur.RatingId);
        }
    }
}
