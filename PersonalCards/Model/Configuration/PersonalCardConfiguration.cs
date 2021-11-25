using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalCards.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalCards.Model.Configuration
{
    public class PersonalCardConfiguration : IEntityTypeConfiguration<PersonalCard>
    {
        public void Configure(EntityTypeBuilder<PersonalCard> builder)
        {
            builder
                .HasKey("Id");

            builder
                .Property(p => p.Id)
                .ValueGeneratedNever()
                .HasColumnName("id")
                .HasColumnType("bigint");

            builder
                .Property(p => p.Discount)
                .HasColumnName("discount")
                .HasColumnType("real");
        }
    }
}
