using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductivityApp.Migrations
{
    /// <inheritdoc />
    public partial class AddHabit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Frequency = table.Column<int>(type: "INTEGER", nullable: false),
                    LastCompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Streak = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habits");
        }
    }
}
