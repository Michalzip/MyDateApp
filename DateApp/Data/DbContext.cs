using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Api.Entities;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata;
using System.Reflection.Emit;

namespace App.Db
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<UserProfile>().HasKey(k => k.UserId);

            builder.Entity<UserComment>().HasKey(k => k.IdComment);

            builder.Entity<UserLike>().HasKey(k => k.UserIdLike);



            builder.Entity<UserComment>()
                .HasOne(p => p.CommentedByUser)
                .WithMany(c => c.CommentsByUsers)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<UserLike>()
               .HasOne(p => p.LikedByUser)
               .WithMany(c => c.LikedByUsers)
               .OnDelete(DeleteBehavior.Cascade);
        }


        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserLike> UserLikes { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
    }
}

