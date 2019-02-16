using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyTracker.Infrastructure.Migrations
{
    public partial class AddedDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "PurchaseItems",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "PurchaseItems");
        }
    }
}
