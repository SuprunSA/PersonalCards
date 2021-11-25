using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalCards.Migrations
{
    public partial class OneToManyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchase_personal_card_id",
                table: "purchase");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_card_id",
                table: "purchase",
                column: "card_id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_personal_card_card_id",
                table: "purchase",
                column: "card_id",
                principalTable: "personal_card",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchase_personal_card_card_id",
                table: "purchase");

            migrationBuilder.DropIndex(
                name: "IX_purchase_card_id",
                table: "purchase");

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_personal_card_id",
                table: "purchase",
                column: "id",
                principalTable: "personal_card",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
