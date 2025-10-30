using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notetakingapi.Migrations
{
    /// <inheritdoc />
    public partial class notefavoritesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsFavorite", "LastUpdate" },
                values: new object[] { "10/30/2025", false, "10/30/2025" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsFavorite", "LastUpdate" },
                values: new object[] { "10/30/2025", false, "10/30/2025" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsFavorite", "LastUpdate" },
                values: new object[] { "10/30/2025", false, "10/30/2025" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsFavorite", "LastUpdate" },
                values: new object[] { "10/30/2025", false, "10/30/2025" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsFavorite", "LastUpdate" },
                values: new object[] { "10/30/2025", false, "10/30/2025" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Notes");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/29/2025", "10/29/2025" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/29/2025", "10/29/2025" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/29/2025", "10/29/2025" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/29/2025", "10/29/2025" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/29/2025", "10/29/2025" });
        }
    }
}
