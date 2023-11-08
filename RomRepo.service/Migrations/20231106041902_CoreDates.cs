using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RomRepo.console.Migrations
{
    /// <inheritdoc />
    public partial class CoreDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Core",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Core",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Core_Path",
                table: "Core",
                column: "Path",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Core_Path",
                table: "Core");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Core");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Core");
        }
    }
}
