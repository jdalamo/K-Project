using Microsoft.EntityFrameworkCore.Migrations;

namespace fa19projectgroup16.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_AppUserId1",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_StandardAccount_AppUserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_StockPortfolio_AppUserId",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
