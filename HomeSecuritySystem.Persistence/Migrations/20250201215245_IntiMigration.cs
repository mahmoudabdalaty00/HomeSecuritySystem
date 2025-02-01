using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeSecuritySystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IntiMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_devices_houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "houses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "houses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "houses",
                columns: new[] { "Id", "Address", "City", "Country", "Name", "PostalCode", "Region" },
                values: new object[,]
                {
                    { 1, "1234 Main St", "City", "Country", "House 1", 12345, "Region" },
                    { 2, "1234 Main St", "City", "Country", "House 2", 12345, "Region" },
                    { 3, "1234 Main St", "City", "Country", "House 3", 12345, "Region" },
                    { 4, "1234 Main St", "City", "Country", "House 4", 12345, "Region" },
                    { 5, "1234 Main St", "City", "Country", "House 5", 12345, "Region" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_devices_HouseId",
                table: "devices",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_User_HouseId",
                table: "User",
                column: "HouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "houses");
        }
    }
}
