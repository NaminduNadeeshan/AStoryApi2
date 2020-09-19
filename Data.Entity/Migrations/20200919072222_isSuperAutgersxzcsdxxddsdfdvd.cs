using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Entity.Migrations
{
    public partial class isSuperAutgersxzcsdxxddsdfdvd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutherBankDetails");

            migrationBuilder.AddColumn<string>(
                name: "bankAccountNumber",
                table: "Authers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bankName",
                table: "Authers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branchName",
                table: "Authers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    bankDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    autherId = table.Column<int>(type: "int", nullable: false),
                    bankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
