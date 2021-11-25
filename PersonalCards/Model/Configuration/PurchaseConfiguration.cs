using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalCards.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalCards.Model.Configuration
{
    class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder
                .HasKey("Id");

            builder
                .Property(p => p.Id)
                .ValueGeneratedNever()
                .HasColumnName("id")
                .HasColumnType("bigint");

            builder
                .Property(p => p.CardId)
                .HasColumnName("card_id")
                .HasColumnType("bigint");

            builder
                .Property(p => p.PurchaseSum)
                .HasColumnName("purchase_sum")
                .HasColumnType("decimal(18, 0)");

            builder
                .HasOne(p => p.PersonalCard)
                .WithMany(p => p.Purchases)
                .HasForeignKey("CardId");
        }
    }
}
