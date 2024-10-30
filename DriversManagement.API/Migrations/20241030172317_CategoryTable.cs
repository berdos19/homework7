using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriversManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Mass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CategoryId",
                table: "Drivers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_VehicleCategory_CategoryId",
                table: "Drivers",
                column: "CategoryId",
                principalTable: "VehicleCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_VehicleCategory_CategoryId",
                table: "Drivers");

            migrationBuilder.DropTable(
                name: "VehicleCategory");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_CategoryId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Drivers");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
