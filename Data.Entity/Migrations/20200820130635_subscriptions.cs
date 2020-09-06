using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Entity.Migrations
{
    public partial class subscriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "coverImageUrl",
                table: "Story",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Story",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    episodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    episodeName = table.Column<string>(nullable: true),
                    episodeShortDescription = table.Column<string>(nullable: true),
                    episodeCoverImageUrl = table.Column<string>(nullable: true),
                    storyId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Subscription",
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
                    table.PrimaryKey("PK_Subscription", x => x.subscriptionId);
                    table.ForeignKey(
                        name: "FK_Subscription_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episode_storyId",
                table: "Episode",
                column: "storyId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_userId",
                table: "Subscription",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "coverImageUrl",
                table: "Story");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Story");
        }
    }
}
