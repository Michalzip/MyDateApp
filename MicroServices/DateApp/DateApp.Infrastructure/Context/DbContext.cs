
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Db
{
    internal class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserLike> UserLikes { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<UserVipPayment> UserVipPayments { get; set; }
        public DbSet<UserTransaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserProfile>().HasKey(k => k.Id);
            builder.Entity<UserLike>().HasKey(K => K.Id);
            builder.Entity<UserMessage>().HasKey(k => k.Id);
            builder.Entity<UserVipPayment>().HasKey(k => k.Id);
            builder.Entity<UserTransaction>().HasKey(k => k.Id);

            builder.Entity<UserTransaction>()
               .HasOne(userBy => userBy.ByUser)
               .WithMany(payment => payment.UserTransactions)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserLike>()
                .HasOne(userBy => userBy.ByUser)
                .WithMany(userTo => userTo.SendedLikes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserLike>()
               .HasOne(userBy => userBy.ToUser)
               .WithMany(userTo => userTo.ReceivedLikes)
               .OnDelete(DeleteBehavior.Restrict);

            //one user  send many messages to another user 
            builder.Entity<UserMessage>()
                .HasOne(userBy => userBy.ByUser)
                .WithMany(userTo => userTo.SendedMessages)
                .OnDelete(DeleteBehavior.Restrict);

            //one user received many messages from another user
            builder.Entity<UserMessage>()
                .HasOne(userBy => userBy.ToUser)
                .WithMany(userTo => userTo.ReceivedMessages)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

