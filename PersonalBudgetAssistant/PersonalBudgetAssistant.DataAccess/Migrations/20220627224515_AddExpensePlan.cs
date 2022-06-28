using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBudgetAssistant.DataAccess.Migrations
{
    public partial class AddExpensePlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpensePlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensePlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensePlans_ExpenseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpensePlans_CategoryId",
                table: "ExpensePlans",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpensePlans");
        }
    }
}
