using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedSomeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentComment_UserPostContents_UserPostContentContentId",
                table: "ContentComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentComment",
                table: "ContentComment");

            migrationBuilder.RenameTable(
                name: "ContentComment",
                newName: "ContentComments");

            migrationBuilder.RenameIndex(
                name: "IX_ContentComment_UserPostContentContentId",
                table: "ContentComments",
                newName: "IX_ContentComments_UserPostContentContentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserPostContents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentComments",
                table: "ContentComments",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentComments_UserPostContents_UserPostContentContentId",
                table: "ContentComments",
                column: "UserPostContentContentId",
                principalTable: "UserPostContents",
                principalColumn: "ContentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentComments_UserPostContents_UserPostContentContentId",
                table: "ContentComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentComments",
                table: "ContentComments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserPostContents");

            migrationBuilder.RenameTable(
                name: "ContentComments",
                newName: "ContentComment");

            migrationBuilder.RenameIndex(
                name: "IX_ContentComments_UserPostContentContentId",
                table: "ContentComment",
                newName: "IX_ContentComment_UserPostContentContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentComment",
                table: "ContentComment",
                column: "ContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentComment_UserPostContents_UserPostContentContentId",
                table: "ContentComment",
                column: "UserPostContentContentId",
                principalTable: "UserPostContents",
                principalColumn: "ContentId");
        }
    }
}
