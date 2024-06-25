using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RomRepo.console.Migrations
{
    /// <inheritdoc />
    public partial class JobQueue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobQueue",
                columns: table => new
                {
                    JobQueueID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobCode = table.Column<string>(type: "TEXT", nullable: false),
                    EntityID = table.Column<int>(type: "INTEGER", nullable: true),
                    TimeLimitSeconds = table.Column<int>(type: "INTEGER", nullable: false),
                    PercentComplete = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DatePickedUp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateComplete = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobQueue", x => x.JobQueueID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobQueue");
        }
    }
}
