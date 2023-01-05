
namespace App.Db
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<UserProfile> UserProfiles { get; set; }
        //public DbSet<UserLike> UserLikes { get; set; }
        //public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<UserProfile>().HasKey(k => k.UserId);

            builder.Entity<UserMessage>().HasKey(k => k.IdMessage);

            //builder.Entity<UserLike>().HasKey(k => k.UserIdLike);

            
            //one user  send many messages to another user 
            builder.Entity<UserMessage>()
                .HasOne(userBy => userBy.ByUserMessage)
                .WithMany(userTo => userTo.SendedMessages)
                .OnDelete(DeleteBehavior.Restrict);

            //one user received many messages from another user
            builder.Entity<UserMessage>()
                .HasOne(userTo => userTo.ToUserMessage)
                .WithMany(userBy => userBy.ReceivedMessages)
                .OnDelete(DeleteBehavior.Restrict);
            

        }



    }
}

