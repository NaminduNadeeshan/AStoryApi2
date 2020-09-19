using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Entity.Migrations
{
    public partial class isSuperAutgersxzcsdxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authers",
                columns: table => new
                {
                    AutherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ProfilePictureUrl = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SuperAuther = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authers", x => x.AutherId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ProfileImageUrl = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true),
                    UserAppId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

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

            migrationBuilder.CreateTable(
                name: "Story",
                columns: table => new
                {
                    storyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storyName = table.Column<string>(nullable: true),
                    storyShortDescription = table.Column<string>(nullable: true),
                    coverImageUrl = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    autherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Story", x => x.storyId);
                    table.ForeignKey(
                        name: "FK_Story_Authers_autherId",
                        column: x => x.autherId,
                        principalTable: "Authers",
                        principalColumn: "AutherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    subscriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    userId = table.Column<int>(nullable: false),
                    storyId = table.Column<int>(nullable: false),
                    episodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.subscriptionId);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    episodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    episodeName = table.Column<string>(nullable: true),
                    episodeShortDescription = table.Column<string>(nullable: true),
                    episodeCoverImageUrl = table.Column<string>(nullable: true),
                    episodeContent = table.Column<string>(nullable: true),
                    storyId = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.episodeId);
                    table.ForeignKey(
                        name: "FK_Episode_Story_storyId",
                        column: x => x.storyId,
                        principalTable: "Story",
                        principalColumn: "storyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutherBankDetails_autherId",
                table: "AutherBankDetails",
                column: "autherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Episode_storyId",
                table: "Episode",
                column: "storyId");

            migrationBuilder.CreateIndex(
                name: "IX_Story_autherId",
                table: "Story",
                column: "autherId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_userId",
                table: "Subscriptions",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutherBankDetails");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Story");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authers");
        }
    }
}
