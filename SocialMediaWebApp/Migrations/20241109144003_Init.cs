using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPostContents",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentLiked = table.Column<int>(type: "int", nullable: false),
                    ContentDisliked = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPostContents", x => x.ContentId);
                });

            migrationBuilder.CreateTable(
                name: "ContentComment",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserPostContentContentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentComment", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_ContentComment_UserPostContents_UserPostContentContentId",
                        column: x => x.UserPostContentContentId,
                        principalTable: "UserPostContents",
                        principalColumn: "ContentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentComment_UserPostContentContentId",
                table: "ContentComment",
                column: "UserPostContentContentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentComment");

            migrationBuilder.DropTable(
                name: "UserPostContents");
        }
    }
}
