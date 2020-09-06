using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Entity.Migrations
{
    public partial class autherbank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutherBankDetails",
                columns: table => new
                {
                    bankDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bankName = table.Column<string>(nullable: true),
                    branchName = table.Column<string>(nullable: true),
                    bankAccountNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutherBankDetails", x => x.bankDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Auther",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ProfilePictureUrl = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AutherBankDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auther", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auther_AutherBankDetails_AutherBankDetailId",
                        column: x => x.AutherBankDetailId,
                        principalTable: "AutherBankDetails",
                        principalColumn: "bankDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auther_AutherBankDetailId",
                table: "Auther",
                column: "AutherBankDetailId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auther");

            migrationBuilder.DropTable(
                name: "AutherBankDetails");
        }
    }
}
