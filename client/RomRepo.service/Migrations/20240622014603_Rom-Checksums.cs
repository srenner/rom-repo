using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RomRepo.console.Migrations
{
    /// <inheritdoc />
    public partial class RomChecksums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CRC",
                table: "Rom",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CRCVerified",
                table: "Rom",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MD5",
                table: "Rom",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MD5Verified",
                table: "Rom",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SHA1",
                table: "Rom",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SHA1Verified",
                table: "Rom",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SHA256",
                table: "Rom",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SHA256Verified",
                table: "Rom",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CRC",
                table: "Rom");

            migrationBuilder.DropColumn(
                name: "CRCVerified",
                table: "Rom");

            migrationBuilder.DropColumn(
                name: "MD5",
                table: "Rom");

            migrationBuilder.DropColumn(
                name: "MD5Verified",
                table: "Rom");

            migrationBuilder.DropColumn(
                name: "SHA1",
                table: "Rom");

            migrationBuilder.DropColumn(
                name: "SHA1Verified",
                table: "Rom");

            migrationBuilder.DropColumn(
                name: "SHA256",
                table: "Rom");

            migrationBuilder.DropColumn(
                name: "SHA256Verified",
                table: "Rom");
        }
    }
}
