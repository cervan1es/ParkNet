using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet_Ricardo.Campos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPArkLayoutEntityToFloorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Layout",
                table: "Floor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "BankCard",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Layout",
                table: "Floor");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "BankCard",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
