using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet_Ricardo.Campos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeColumnonParkingSpaceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "ParkingSpace",
                type: "nvarchar(1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ParkingSpace");
        }
    }
}
