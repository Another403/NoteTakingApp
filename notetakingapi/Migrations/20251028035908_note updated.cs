using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace notetakingapi.Migrations
{
    /// <inheritdoc />
    public partial class noteupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate", "UserId" },
                values: new object[] { "10/28/2025", "10/28/2025", "" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdate", "UserId" },
                values: new object[] { "10/28/2025", "10/28/2025", "" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdate", "UserId" },
                values: new object[] { "10/28/2025", "10/28/2025", "" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdate", "UserId" },
                values: new object[] { "10/28/2025", "10/28/2025", "" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdate", "UserId" },
                values: new object[] { "10/28/2025", "10/28/2025", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/27/2025 12:00:00 AM", "10/27/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/27/2025 12:00:00 AM", "10/27/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/27/2025 12:00:00 AM", "10/27/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/27/2025 12:00:00 AM", "10/27/2025 12:00:00 AM" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastUpdate" },
                values: new object[] { "10/27/2025 12:00:00 AM", "10/27/2025 12:00:00 AM" });
        }
    }
}
