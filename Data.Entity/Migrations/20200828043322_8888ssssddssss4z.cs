using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Entity.Migrations
{
    public partial class _8888ssssddssss4z : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutherBankDetails_Authers_autherId",
                table: "AutherBankDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Story_Authers_autherId",
                table: "Story");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authers",
                table: "Authers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Authers");

            migrationBuilder.AddColumn<int>(
                name: "AutherId",
                table: "Authers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authers",
                table: "Authers",
                column: "AutherId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutherBankDetails_Authers_autherId",
                table: "AutherBankDetails",
                column: "autherId",
                principalTable: "Authers",
                principalColumn: "AutherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Authers_autherId",
                table: "Story",
                column: "autherId",
                principalTable: "Authers",
                principalColumn: "AutherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutherBankDetails_Authers_autherId",
                table: "AutherBankDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Story_Authers_autherId",
                table: "Story");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authers",
                table: "Authers");

            migrationBuilder.DropColumn(
                name: "AutherId",
                table: "Authers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Authers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authers",
                table: "Authers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AutherBankDetails_Authers_autherId",
                table: "AutherBankDetails",
                column: "autherId",
                principalTable: "Authers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Authers_autherId",
                table: "Story",
                column: "autherId",
                principalTable: "Authers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
