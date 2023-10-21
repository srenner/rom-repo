using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RomRepo.console.Migrations
{
    /// <inheritdoc />
    public partial class Rom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rom",
                columns: table => new
                {
                    RomID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoreID = table.Column<int>(type: "INTEGER", nullable: true),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    IsFavorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    StarRating = table.Column<int>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsHack = table.Column<bool>(type: "INTEGER", nullable: false),
                    ParentRomID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rom", x => x.RomID);
                    table.ForeignKey(
                        name: "FK_Rom_Core_CoreID",
                        column: x => x.CoreID,
                        principalTable: "Core",
                        principalColumn: "CoreID");
                    table.ForeignKey(
                        name: "FK_Rom_Rom_ParentRomID",
                        column: x => x.ParentRomID,
                        principalTable: "Rom",
                        principalColumn: "RomID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rom_CoreID",
                table: "Rom",
                column: "CoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Rom_ParentRomID",
                table: "Rom",
                column: "ParentRomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rom");
        }
    }
}
