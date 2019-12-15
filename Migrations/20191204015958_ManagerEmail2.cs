using Microsoft.EntityFrameworkCore.Migrations;

namespace fa19projectgroup16.Migrations
{
    public partial class ManagerEmail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerEmail",
                table: "Disputes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerEmail",
                table: "Disputes");
        }
    }
}
