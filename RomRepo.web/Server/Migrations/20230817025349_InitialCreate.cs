using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RomRepo.web.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cores",
                columns: table => new
                {
                    CoreID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ZipAsRom = table.Column<bool>(type: "INTEGER", nullable: false),
                    SevenZipAsRom = table.Column<bool>(type: "INTEGER", nullable: false),
                    FolderAsRom = table.Column<bool>(type: "INTEGER", nullable: false),
                    FileExtensions = table.Column<string>(type: "TEXT", nullable: true),
                    IsFavorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cores", x => x.CoreID);
                });

            migrationBuilder.CreateTable(
                name: "Roms",
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
                    table.PrimaryKey("PK_Roms", x => x.RomID);
                    table.ForeignKey(
                        name: "FK_Roms_Cores_CoreID",
                        column: x => x.CoreID,
                        principalTable: "Cores",
                        principalColumn: "CoreID");
                    table.ForeignKey(
                        name: "FK_Roms_Roms_ParentRomID",
                        column: x => x.ParentRomID,
                        principalTable: "Roms",
                        principalColumn: "RomID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roms_CoreID",
                table: "Roms",
                column: "CoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Roms_ParentRomID",
                table: "Roms",
                column: "ParentRomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roms");

            migrationBuilder.DropTable(
                name: "Cores");
        }
    }
}
