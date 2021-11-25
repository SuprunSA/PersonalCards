using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalCards.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalCards.Model.Configuration
{
    class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder
                .HasKey("UserId");

            builder
                .Property(p => p.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id")
                .HasColumnType("bigint");

            builder
                .Property(p => p.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)");

            builder
                .Property(p => p.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("nvarchar(50)");

            builder
                .Property(p => p.LastName)
                .HasColumnName("last_name")
                .HasColumnType("nvarchar(50)");

            builder
                .Property(p => p.BirthDate)
                .HasColumnName("birthdate")
                .HasColumnType("date");

            builder
                .HasOne(u => u.PersonalCard)
                .WithOne(p => p.UserProfile)
                .HasForeignKey<UserProfile>(u => u.UserId);
        }
    }
}
