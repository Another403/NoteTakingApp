using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace notetakingapi.Migrations
{
    /// <inheritdoc />
    public partial class notedataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "notes",
                columns: new[] { "Id", "Content", "CreatedAt", "LastUpdate" },
                values: new object[,]
                {
                    { 1, "Hello, World!", "10/22/2025 12:00:00 AM", "10/22/2025 12:00:00 AM" },
                    { 2, "Hello, Akito!", "10/22/2025 12:00:00 AM", "10/22/2025 12:00:00 AM" },
                    { 3, "Hello, Seven!", "10/22/2025 12:00:00 AM", "10/22/2025 12:00:00 AM" },
                    { 4, "Hello!", "10/22/2025 12:00:00 AM", "10/22/2025 12:00:00 AM" },
                    { 5, "Hello, just Hello!", "10/22/2025 12:00:00 AM", "10/22/2025 12:00:00 AM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "notes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "notes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "notes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "notes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "notes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
