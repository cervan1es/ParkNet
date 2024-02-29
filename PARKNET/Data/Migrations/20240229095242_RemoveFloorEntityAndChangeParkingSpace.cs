using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PARKNET.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFloorEntityAndChangeParkingSpace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropColumn(
                name: "FloorID",
                table: "ParkingSpace");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "ParkingSpace");

            migrationBuilder.RenameColumn(
                name: "Column",
                table: "ParkingSpace",
                newName: "ParkId");

            migrationBuilder.AddColumn<string>(
                name: "Coordenate",
                table: "ParkingSpace",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordenate",
                table: "ParkingSpace");

            migrationBuilder.RenameColumn(
                name: "ParkId",
                table: "ParkingSpace",
                newName: "Column");

            migrationBuilder.AddColumn<Guid>(
                name: "FloorID",
                table: "ParkingSpace",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Row",
                table: "ParkingSpace",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    FloorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ParkID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.FloorID);
                });
        }
    }
}
