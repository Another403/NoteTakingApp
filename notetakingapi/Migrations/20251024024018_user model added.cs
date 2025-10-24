using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notetakingapi.Migrations
{
    /// <inheritdoc />
    public partial class usermodeladded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_notes",
                table: "notes");

            migrationBuilder.RenameTable(
                name: "notes",
                newName: "Notes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/24/2025 12:00:00 AM", "10/24/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/24/2025 12:00:00 AM", "10/24/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/24/2025 12:00:00 AM", "10/24/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/24/2025 12:00:00 AM", "10/24/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/24/2025 12:00:00 AM", "10/24/2025 12:00:00 AM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "notes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notes",
                table: "notes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/22/2025 12:00:00 AM", "10/22/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "notes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/22/2025 12:00:00 AM", "10/22/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "notes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/22/2025 12:00:00 AM", "10/22/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "notes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/22/2025 12:00:00 AM", "10/22/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "notes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/22/2025 12:00:00 AM", "10/22/2025 12:00:00 AM" });
        }
    }
}
