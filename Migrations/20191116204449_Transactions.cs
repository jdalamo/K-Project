using Microsoft.EntityFrameworkCore.Migrations;

namespace fa19projectgroup16.Migrations
{
    public partial class Transactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_IRAAccountAccountID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_StandardAccountAccountID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_StockPortfolioAccountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_IRAAccountAccountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_StandardAccountAccountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_StockPortfolioAccountID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IRAAccountAccountID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StandardAccountAccountID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StockPortfolioAccountID",
                table: "Transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IRAAccountAccountID",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StandardAccountAccountID",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockPortfolioAccountID",
                table: "Transactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IRAAccountAccountID",
                table: "Transactions",
                column: "IRAAccountAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StandardAccountAccountID",
                table: "Transactions",
                column: "StandardAccountAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StockPortfolioAccountID",
                table: "Transactions",
                column: "StockPortfolioAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_IRAAccountAccountID",
                table: "Transactions",
                column: "IRAAccountAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_StandardAccountAccountID",
                table: "Transactions",
                column: "StandardAccountAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_StockPortfolioAccountID",
                table: "Transactions",
                column: "StockPortfolioAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
