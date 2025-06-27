using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialMediaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class asdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c6d1aeb-189f-4afe-af00-265804cfbb59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "309c30ae-1ff7-4916-8277-5f895c90598d");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "678f40ed-156b-42ae-82a6-596d59d2da67", null, "Admin", "ADMIN" },
                    { "9571aa77-c90b-4da3-ad21-d0f890f64ade", null, "SocialMediaUser", "SOCIALMEDIAUSER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "678f40ed-156b-42ae-82a6-596d59d2da67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9571aa77-c90b-4da3-ad21-d0f890f64ade");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c6d1aeb-189f-4afe-af00-265804cfbb59", null, "SocialMediaUser", "SOCIALMEDIAUSER" },
                    { "309c30ae-1ff7-4916-8277-5f895c90598d", null, "Admin", "ADMIN" }
                });
        }
    }
}
