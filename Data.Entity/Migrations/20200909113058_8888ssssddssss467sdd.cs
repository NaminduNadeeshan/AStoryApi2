using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Entity.Migrations
{
    public partial class _8888ssssddssss467sdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Authers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Authers");
        }
    }
}
