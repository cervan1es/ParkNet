using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet_Ricardo.Campos.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCusmoterWallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerWallet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerWallet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankCardExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriversLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriversLicenseExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerWallet", x => x.ID);
                });
        }
    }
}
