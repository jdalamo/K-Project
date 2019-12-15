using Microsoft.EntityFrameworkCore.Migrations;

namespace fa19projectgroup16.Migrations
{
    public partial class IRAStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ContributionAmount",
                table: "Accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContributionAmount",
                table: "Accounts");
        }
    }
}
