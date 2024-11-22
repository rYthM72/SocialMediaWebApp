using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLikeAndDislikeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentDisliked",
                table: "UserPostContents");

            migrationBuilder.DropColumn(
                name: "ContentLiked",
                table: "UserPostContents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContentDisliked",
                table: "UserPostContents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContentLiked",
                table: "UserPostContents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
