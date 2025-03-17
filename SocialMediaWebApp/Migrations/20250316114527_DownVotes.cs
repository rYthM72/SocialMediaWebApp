using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialMediaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class DownVotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f864505-e3f4-4c02-a9e5-fb20d874bd1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebd7a7a2-1964-4d35-9e13-024baf9df17c");

            migrationBuilder.CreateTable(
                name: "PostDownVotes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostDownVotes", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostDownVotes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostDownVotes_UserPostContents_PostId",
                        column: x => x.PostId,
                        principalTable: "UserPostContents",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "465aeedd-20ca-4d7c-ad17-c32bd733a7d2", null, "Admin", "ADMIN" },
                    { "69d26eb7-826c-4b98-953f-40552e36c638", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostDownVotes_UserId",
                table: "PostDownVotes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostDownVotes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "465aeedd-20ca-4d7c-ad17-c32bd733a7d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69d26eb7-826c-4b98-953f-40552e36c638");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9f864505-e3f4-4c02-a9e5-fb20d874bd1d", null, "User", "USER" },
                    { "ebd7a7a2-1964-4d35-9e13-024baf9df17c", null, "Admin", "ADMIN" }
                });
        }
    }
}
