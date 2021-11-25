using Microsoft.EntityFrameworkCore;
using PersonalCards.Connection;
using PersonalCards.Model.Configuration;
using PersonalCards.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalCards
{
    public class PersonalConsumersCardsContext : DbContext
    {
        public PersonalConsumersCardsContext() : base() { }
        public PersonalConsumersCardsContext(DbContextOptions options) : base(options) { }

        public DbSet<PersonalCard> PersonalCards { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(new ConnectionStringConfig().ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalCardConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
        }
    }
}
