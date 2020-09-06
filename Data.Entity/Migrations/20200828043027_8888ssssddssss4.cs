using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Entity.Migrations
{
    public partial class _8888ssssddssss4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authers_AutherBankDetails_AutherBankDetailId",
                table: "Authers");

            migrationBuilder.DropIndex(
                name: "IX_Authers_AutherBankDetailId",
                table: "Authers");

            migrationBuilder.DropColumn(
                name: "AutherBankDetailId",
                table: "Authers");

            migrationBuilder.AddColumn<int>(
                name: "autherId",
                table: "AutherBankDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AutherBankDetails_autherId",
                table: "AutherBankDetails",
                column: "autherId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AutherBankDetails_Authers_autherId",
                table: "AutherBankDetails",
                column: "autherId",
                principalTable: "Authers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutherBankDetails_Authers_autherId",
                table: "AutherBankDetails");

            migrationBuilder.DropIndex(
                name: "IX_AutherBankDetails_autherId",
                table: "AutherBankDetails");

            migrationBuilder.DropColumn(
                name: "autherId",
                table: "AutherBankDetails");

            migrationBuilder.AddColumn<int>(
                name: "AutherBankDetailId",
                table: "Authers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Authers_AutherBankDetailId",
                table: "Authers",
                column: "AutherBankDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authers_AutherBankDetails_AutherBankDetailId",
                table: "Authers",
                column: "AutherBankDetailId",
                principalTable: "AutherBankDetails",
                principalColumn: "bankDetailsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
