using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RomRepo.api.Migrations
{
    /// <inheritdoc />
    public partial class KeyStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ApiKey",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ApiKey",
                newName: "IsActive");
        }
    }
}
