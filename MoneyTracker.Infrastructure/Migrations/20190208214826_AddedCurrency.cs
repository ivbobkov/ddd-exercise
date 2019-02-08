using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyTracker.Infrastructure.Migrations
{
    public partial class AddedCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Salaries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Code);
                });

            migrationBuilder.Sql(@"
                INSERT INTO Currencies
                SELECT Purchases.CurrencyCode AS Code FROM Purchases
                UNION
                SELECT Salaries.CurrencyCode AS Code FROM Salaries");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_CurrencyCode",
                table: "Salaries",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CurrencyCode",
                table: "Purchases",
                column: "CurrencyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Currencies_CurrencyCode",
                table: "Purchases",
                column: "CurrencyCode",
                principalTable: "Currencies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Currencies_CurrencyCode",
                table: "Salaries",
                column: "CurrencyCode",
                principalTable: "Currencies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Currencies_CurrencyCode",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Currencies_CurrencyCode",
                table: "Salaries");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_CurrencyCode",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_CurrencyCode",
                table: "Purchases");

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Salaries",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Purchases",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
