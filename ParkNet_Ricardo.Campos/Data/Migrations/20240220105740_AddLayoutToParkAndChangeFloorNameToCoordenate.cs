using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet_Ricardo.Campos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLayoutToParkAndChangeFloorNameToCoordenate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ParkingSpace",
                newName: "VehicleType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ParkingSpace",
                newName: "Coordenate");

            migrationBuilder.AddColumn<string>(
                name: "Layout",
                table: "Park",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Layout",
                table: "Park");

            migrationBuilder.RenameColumn(
                name: "VehicleType",
                table: "ParkingSpace",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Coordenate",
                table: "ParkingSpace",
                newName: "Name");
        }
    }
}
