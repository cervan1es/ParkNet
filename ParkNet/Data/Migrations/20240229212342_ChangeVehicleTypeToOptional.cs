using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PARKNET.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVehicleTypeToOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                table: "ParkingSpace",
                type: "nvarchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                table: "ParkingSpace",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldNullable: true);
        }
    }
}
