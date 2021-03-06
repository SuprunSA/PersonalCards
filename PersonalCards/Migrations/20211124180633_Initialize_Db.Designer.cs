// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalCards;

namespace PersonalCards.Migrations
{
    [DbContext(typeof(PersonalConsumersCardsContext))]
    [Migration("20211124180633_Initialize_Db")]
    partial class Initialize_Db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalCards.Model.DTO.PersonalCard", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<float?>("Discount")
                        .HasColumnType("real")
                        .HasColumnName("discount");

                    b.HasKey("Id");

                    b.ToTable("personal_card");
                });

            modelBuilder.Entity("PersonalCards.Model.DTO.Purchase", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<long?>("CardId")
                        .HasColumnType("bigint")
                        .HasColumnName("card_id");

                    b.Property<decimal?>("PurchaseSum")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("purchase_sum");

                    b.HasKey("Id");

                    b.ToTable("purchase");
                });

            modelBuilder.Entity("PersonalCards.Model.DTO.UserProfile", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.HasKey("UserId");

                    b.ToTable("user_profile");
                });

            modelBuilder.Entity("PersonalCards.Model.DTO.Purchase", b =>
                {
                    b.HasOne("PersonalCards.Model.DTO.PersonalCard", "PersonalCard")
                        .WithMany("Purchases")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalCard");
                });

            modelBuilder.Entity("PersonalCards.Model.DTO.UserProfile", b =>
                {
                    b.HasOne("PersonalCards.Model.DTO.PersonalCard", "PersonalCard")
                        .WithOne("UserProfile")
                        .HasForeignKey("PersonalCards.Model.DTO.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalCard");
                });

            modelBuilder.Entity("PersonalCards.Model.DTO.PersonalCard", b =>
                {
                    b.Navigation("Purchases");

                    b.Navigation("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
