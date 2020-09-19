using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Data.Entity
{
    public class AStoryDatabaseContext : DbContext
    {
        public AStoryDatabaseContext(DbContextOptions<AStoryDatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Story> Story { get; set; }

        public DbSet<Episode> Episode { get; set; }

        public DbSet<Auther> Authers { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<AutherBankDetails> AutherBankDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Subscription>()
                .HasOne(subscription => subscription.user)
                .WithMany(user => user.SubscribedStories)
                .HasForeignKey(subscription => subscription.userId);

            modelBuilder.Entity<Episode>()
                .HasOne(episode => episode.story)
                .WithMany(story => story.episodes)
                .HasForeignKey(episode => episode.storyId);

            modelBuilder.Entity<AutherBankDetails>()
                .HasOne(bank => bank.auther)
                .WithOne(auther => auther.BankDetails)
                .HasForeignKey<AutherBankDetails>(bank => bank.autherId);

            modelBuilder.Entity<Story>()
                .HasOne(story => story.auther)
                .WithMany(auther => auther.stories)
                .HasForeignKey(story => story.autherId);
              


        }

    }

    public class AStoryContextFactory : IDesignTimeDbContextFactory<AStoryDatabaseContext>
    {
        public AStoryDatabaseContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<AStoryDatabaseContext>();
            optionBuilder.UseSqlServer("Data Source=astorydb.database.windows.net;Initial Catalog=astorydb;User ID=astroyapi;Password=Microbiology01!");

            return new AStoryDatabaseContext(optionBuilder.Options);
        }
    }
}


