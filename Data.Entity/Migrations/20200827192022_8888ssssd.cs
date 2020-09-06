using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Entity.Migrations
{
    public partial class _8888ssssd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auther_AutherBankDetails_AutherBankDetailId",
                table: "Auther");

            migrationBuilder.DropForeignKey(
                name: "FK_Story_Users_userId",
                table: "Story");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Users_userId",
                table: "Subscription");

            migrationBuilder.DropIndex(
                name: "IX_Story_userId",
                table: "Story");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auther",
                table: "Auther");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Story");

            migrationBuilder.RenameTable(
                name: "Subscription",
                newName: "Subscriptions");

            migrationBuilder.RenameTable(
                name: "Auther",
                newName: "Authers");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_userId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Auther_AutherBankDetailId",
                table: "Authers",
                newName: "IX_Authers_AutherBankDetailId");

            migrationBuilder.AddColumn<int>(
                name: "autherId",
                table: "Story",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                column: "subscriptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authers",
                table: "Authers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Story_autherId",
                table: "Story",
                column: "autherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authers_AutherBankDetails_AutherBankDetailId",
                table: "Authers",
                column: "AutherBankDetailId",
                principalTable: "AutherBankDetails",
                principalColumn: "bankDetailsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Authers_autherId",
                table: "Story",
                column: "autherId",
                principalTable: "Authers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Users_userId",
                table: "Subscriptions",
                column: "userId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authers_AutherBankDetails_AutherBankDetailId",
                table: "Authers");

            migrationBuilder.DropForeignKey(
                name: "FK_Story_Authers_autherId",
                table: "Story");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Users_userId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Story_autherId",
                table: "Story");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authers",
                table: "Authers");

            migrationBuilder.DropColumn(
                name: "autherId",
                table: "Story");

            migrationBuilder.RenameTable(
                name: "Subscriptions",
                newName: "Subscription");

            migrationBuilder.RenameTable(
                name: "Authers",
                newName: "Auther");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_userId",
                table: "Subscription",
                newName: "IX_Subscription_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Authers_AutherBankDetailId",
                table: "Auther",
                newName: "IX_Auther_AutherBankDetailId");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Story",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription",
                column: "subscriptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auther",
                table: "Auther",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Story_userId",
                table: "Story",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auther_AutherBankDetails_AutherBankDetailId",
                table: "Auther",
                column: "AutherBankDetailId",
                principalTable: "AutherBankDetails",
                principalColumn: "bankDetailsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Users_userId",
                table: "Story",
                column: "userId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Users_userId",
                table: "Subscription",
                column: "userId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
