using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PARKNET.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserIdforCustomerEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Customer",
                newName: "CustomerEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerEmail",
                table: "Customer",
                newName: "UserID");
        }
    }
}
