using Microsoft.EntityFrameworkCore.Migrations;

namespace fa19projectgroup16.Migrations
{
    public partial class updateDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AspNetUsers_AppUserId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransaction_Account_StockPortfolioAccountID",
                table: "StockTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Account_AccountID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Account_StockPortfolioAccountID",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Account_AppUserId",
                table: "Accounts",
                newName: "IX_Accounts_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "IRAAccountAccountID",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StandardAccountAccountID",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmpType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StandardAccount_AppUserId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockPortfolio_AppUserId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IRAAccountAccountID",
                table: "Transactions",
                column: "IRAAccountAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StandardAccountAccountID",
                table: "Transactions",
                column: "StandardAccountAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AppUserId1",
                table: "Accounts",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_StandardAccount_AppUserId",
                table: "Accounts",
                column: "StandardAccount_AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_StockPortfolio_AppUserId",
                table: "Accounts",
                column: "StockPortfolio_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_AppUserId1",
                table: "Accounts",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_AppUserId",
                table: "Accounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_StandardAccount_AppUserId",
                table: "Accounts",
                column: "StandardAccount_AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_StockPortfolio_AppUserId",
                table: "Accounts",
                column: "StockPortfolio_AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransaction_Accounts_StockPortfolioAccountID",
                table: "StockTransaction",
                column: "StockPortfolioAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountID",
                table: "Transactions",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_AppUserId1",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_AppUserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_StandardAccount_AppUserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_StockPortfolio_AppUserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransaction_Accounts_StockPortfolioAccountID",
                table: "StockTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountID",
                table: "Transactions");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AppUserId1",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_StandardAccount_AppUserId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_StockPortfolio_AppUserId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IRAAccountAccountID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StandardAccountAccountID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmpType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SSN",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "StandardAccount_AppUserId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "StockPortfolio_AppUserId",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_AppUserId",
                table: "Account",
                newName: "IX_Account_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AspNetUsers_AppUserId",
                table: "Account",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransaction_Account_StockPortfolioAccountID",
                table: "StockTransaction",
                column: "StockPortfolioAccountID",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Account_AccountID",
                table: "Transactions",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Account_StockPortfolioAccountID",
                table: "Transactions",
                column: "StockPortfolioAccountID",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
