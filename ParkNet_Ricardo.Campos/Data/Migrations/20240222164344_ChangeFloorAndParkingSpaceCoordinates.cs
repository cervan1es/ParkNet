using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet_Ricardo.Campos.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFloorAndParkingSpaceCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Layout",
                table: "Floor");

            migrationBuilder.RenameColumn(
                name: "Coordenate",
                table: "ParkingSpace",
                newName: "Row");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                table: "ParkingSpace",
                type: "nvarchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Column",
                table: "ParkingSpace",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Column",
                table: "ParkingSpace");

            migrationBuilder.RenameColumn(
                name: "Row",
                table: "ParkingSpace",
                newName: "Coordenate");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                table: "ParkingSpace",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Layout",
                table: "Floor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
