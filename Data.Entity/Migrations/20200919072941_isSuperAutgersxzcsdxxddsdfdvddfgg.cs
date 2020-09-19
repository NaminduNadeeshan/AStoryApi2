using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Entity.Migrations
{
    public partial class isSuperAutgersxzcsdxxddsdfdvddfgg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bankAccountNumber",
                table: "Authers");

            migrationBuilder.DropColumn(
                name: "bankName",
                table: "Authers");

            migrationBuilder.DropColumn(
                name: "branchName",
                table: "Authers");

            migrationBuilder.CreateTable(
                name: "AutherBankDetails",
                columns: table => new
                {
                    bankDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bankName = table.Column<string>(nullable: true),
                    branchName = table.Column<string>(nullable: true),
                    bankAccountNumber = table.Column<string>(nullable: true),
                    autherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutherBankDetails", x => x.bankDetailsId);
                    table.ForeignKey(
                        name: "FK_AutherBankDetails_Authers_autherId",
                        column: x => x.autherId,
                        principalTable: "Authers",
                        principalColumn: "AutherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutherBankDetails_autherId",
                table: "AutherBankDetails",
                column: "autherId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutherBankDetails");

            migrationBuilder.AddColumn<string>(
                name: "bankAccountNumber",
                table: "Authers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bankName",
                table: "Authers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branchName",
                table: "Authers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
