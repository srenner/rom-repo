using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RomRepo.api.Migrations
{
    /// <inheritdoc />
    public partial class DatEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameSystem",
                columns: table => new
                {
                    GameSystemID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoIntroGameSystemID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Version = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    Homepage = table.Column<string>(type: "TEXT", nullable: true),
                    URL = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSystem", x => x.GameSystemID);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoIntroGameID = table.Column<int>(type: "INTEGER", nullable: true),
                    ParentGameID = table.Column<int>(type: "INTEGER", nullable: true),
                    ParentNoIntroID = table.Column<int>(type: "INTEGER", nullable: true),
                    GameSystemID = table.Column<int>(type: "INTEGER", nullable: true),
                    NoIntroGameSystemID = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Game_GameSystem_GameSystemID",
                        column: x => x.GameSystemID,
                        principalTable: "GameSystem",
                        principalColumn: "GameSystemID");
                    table.ForeignKey(
                        name: "FK_Game_Game_ParentGameID",
                        column: x => x.ParentGameID,
                        principalTable: "Game",
                        principalColumn: "GameID");
                });

            migrationBuilder.CreateTable(
                name: "Rom",
                columns: table => new
                {
                    RomID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameID = table.Column<int>(type: "INTEGER", nullable: true),
                    NoIntroGameID = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<int>(type: "INTEGER", nullable: true),
                    CRC = table.Column<string>(type: "TEXT", nullable: true),
                    MD5 = table.Column<string>(type: "TEXT", nullable: true),
                    SHA1 = table.Column<string>(type: "TEXT", nullable: true),
                    SHA256 = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Serial = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rom", x => x.RomID);
                    table.ForeignKey(
                        name: "FK_Rom_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_GameSystemID",
                table: "Game",
                column: "GameSystemID");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ParentGameID",
                table: "Game",
                column: "ParentGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Rom_GameID",
                table: "Rom",
                column: "GameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rom");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "GameSystem");
        }
    }
}
