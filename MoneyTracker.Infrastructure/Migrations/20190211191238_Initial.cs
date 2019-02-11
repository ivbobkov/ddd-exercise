using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyTracker.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    SpentAt = table.Column<DateTime>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SalaryId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    ReceivedAt = table.Column<DateTime>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.SalaryId);
                    table.ForeignKey(
                        name: "FK_Salaries_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CurrencyCode",
                table: "Purchases",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_CurrencyCode",
                table: "Salaries",
                column: "CurrencyCode");

            migrationBuilder.InsertData("Currencies", "Code", "USD");
            migrationBuilder.InsertData("Currencies", "Code", "BYN");
            migrationBuilder.InsertData("Currencies", "Code", "EUR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
