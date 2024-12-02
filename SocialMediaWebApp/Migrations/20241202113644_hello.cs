using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialMediaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class hello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d24ae465-4a1c-4254-a816-a3c2e18fa26f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f48403b1-3485-4f7b-9edd-428989c994e3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "483ea669-35bb-4bd3-8446-6f6f86d138ab", null, "Admin", "ADMIN" },
                    { "f68d4a3f-4dc6-4713-9749-0524191acd10", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "483ea669-35bb-4bd3-8446-6f6f86d138ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f68d4a3f-4dc6-4713-9749-0524191acd10");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d24ae465-4a1c-4254-a816-a3c2e18fa26f", null, "Admin", "ADMIN" },
                    { "f48403b1-3485-4f7b-9edd-428989c994e3", null, "User", "USER" }
                });
        }
    }
}
