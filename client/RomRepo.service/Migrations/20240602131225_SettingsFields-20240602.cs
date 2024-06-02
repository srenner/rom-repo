using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RomRepo.console.Migrations
{
    /// <inheritdoc />
    public partial class SettingsFields20240602 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "SystemSetting",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "SystemSetting",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                table: "SystemSetting",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataType",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "IsRequired",
                table: "SystemSetting");
        }
    }
}
