using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeSecuritySystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class hideUserfromhouses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_devices_houses_HouseId",
                table: "devices");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_devices_HouseId",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "devices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HouseId",
                table: "devices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_devices_HouseId",
                table: "devices",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_User_HouseId",
                table: "User",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_devices_houses_HouseId",
                table: "devices",
                column: "HouseId",
                principalTable: "houses",
                principalColumn: "Id");
        }
    }
}
