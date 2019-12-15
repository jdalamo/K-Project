using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fa19projectgroup16.Migrations
{
    public partial class stocktransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransaction_Stocks_StockID",
                table: "StockTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransaction_Accounts_StockPortfolioAccountID",
                table: "StockTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockTransaction",
                table: "StockTransaction");

            migrationBuilder.RenameTable(
                name: "StockTransaction",
                newName: "StockTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransaction_StockPortfolioAccountID",
                table: "StockTransactions",
                newName: "IX_StockTransactions_StockPortfolioAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransaction_StockID",
                table: "StockTransactions",
                newName: "IX_StockTransactions_StockID");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "StockTransactions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockTransactions",
                table: "StockTransactions",
                column: "StockTransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactions_Stocks_StockID",
                table: "StockTransactions",
                column: "StockID",
                principalTable: "Stocks",
                principalColumn: "StockID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactions_Accounts_StockPortfolioAccountID",
                table: "StockTransactions",
                column: "StockPortfolioAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_Stocks_StockID",
                table: "StockTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_Accounts_StockPortfolioAccountID",
                table: "StockTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockTransactions",
                table: "StockTransactions");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "StockTransactions");

            migrationBuilder.RenameTable(
                name: "StockTransactions",
                newName: "StockTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransactions_StockPortfolioAccountID",
                table: "StockTransaction",
                newName: "IX_StockTransaction_StockPortfolioAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransactions_StockID",
                table: "StockTransaction",
                newName: "IX_StockTransaction_StockID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockTransaction",
                table: "StockTransaction",
                column: "StockTransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransaction_Stocks_StockID",
                table: "StockTransaction",
                column: "StockID",
                principalTable: "Stocks",
                principalColumn: "StockID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransaction_Accounts_StockPortfolioAccountID",
                table: "StockTransaction",
                column: "StockPortfolioAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
