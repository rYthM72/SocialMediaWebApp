using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentUrl",
                table: "UserPostContents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentUrl",
                table: "UserPostContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
