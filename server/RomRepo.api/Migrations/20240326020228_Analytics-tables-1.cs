using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RomRepo.api.Migrations
{
    /// <inheritdoc />
    public partial class Analyticstables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameFavorite",
                columns: table => new
                {
                    GameFavoriteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApiKeyID = table.Column<int>(type: "INTEGER", nullable: false),
                    GameID = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameFavorite", x => x.GameFavoriteID);
                    table.ForeignKey(
                        name: "FK_GameFavorite_ApiKey_ApiKeyID",
                        column: x => x.ApiKeyID,
                        principalTable: "ApiKey",
                        principalColumn: "ApiKeyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameFavorite_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameInstallation",
                columns: table => new
                {
                    GameInstallationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameID = table.Column<int>(type: "INTEGER", nullable: false),
                    ApiKeyID = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInstallation", x => x.GameInstallationID);
                    table.ForeignKey(
                        name: "FK_GameInstallation_ApiKey_ApiKeyID",
                        column: x => x.ApiKeyID,
                        principalTable: "ApiKey",
                        principalColumn: "ApiKeyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameInstallation_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameSystemFavorite",
                columns: table => new
                {
                    GameSystemFavoriteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApiKeyID = table.Column<int>(type: "INTEGER", nullable: false),
                    GameSystemID = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSystemFavorite", x => x.GameSystemFavoriteID);
                    table.ForeignKey(
                        name: "FK_GameSystemFavorite_ApiKey_ApiKeyID",
                        column: x => x.ApiKeyID,
                        principalTable: "ApiKey",
                        principalColumn: "ApiKeyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameSystemFavorite_GameSystem_GameSystemID",
                        column: x => x.GameSystemID,
                        principalTable: "GameSystem",
                        principalColumn: "GameSystemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameFavorite_ApiKeyID",
                table: "GameFavorite",
                column: "ApiKeyID");

            migrationBuilder.CreateIndex(
                name: "IX_GameFavorite_GameID",
                table: "GameFavorite",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_GameInstallation_ApiKeyID",
                table: "GameInstallation",
                column: "ApiKeyID");

            migrationBuilder.CreateIndex(
                name: "IX_GameInstallation_GameID",
                table: "GameInstallation",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_GameSystemFavorite_ApiKeyID",
                table: "GameSystemFavorite",
                column: "ApiKeyID");

            migrationBuilder.CreateIndex(
                name: "IX_GameSystemFavorite_GameSystemID",
                table: "GameSystemFavorite",
                column: "GameSystemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameFavorite");

            migrationBuilder.DropTable(
                name: "GameInstallation");

            migrationBuilder.DropTable(
                name: "GameSystemFavorite");
        }
    }
}
