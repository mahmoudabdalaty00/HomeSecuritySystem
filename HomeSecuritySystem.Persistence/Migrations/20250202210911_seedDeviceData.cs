using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeSecuritySystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedDeviceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "devices",
                columns: new[] { "Id", "DeviceType", "Model", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, "Sensor", "Model A", true, "User1" },
                    { 2, "Camera", "Model B", false, "User2" },
                    { 3, "Alarm", "Model C", true, "User3" },
                    { 4, "Sensor", "Model D", true, "User4" },
                    { 5, "Camera", "Model E", false, "User5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "devices",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
