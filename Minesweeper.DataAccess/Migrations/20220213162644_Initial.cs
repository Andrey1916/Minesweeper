using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minesweeper.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    Time = table.Column<long>(type: "INTEGER", nullable: false),
                    AreaWidth = table.Column<uint>(type: "INTEGER", nullable: false),
                    AreaHeight = table.Column<uint>(type: "INTEGER", nullable: false),
                    Mines = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResults", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GameResults",
                columns: new[] { "Id", "AreaHeight", "AreaWidth", "Mines", "Name", "Time" },
                values: new object[] { new Guid("445c99bb-7088-4243-8c39-d79effae2691"), 50u, 50u, 0u, "User 4", 1644769604L });

            migrationBuilder.InsertData(
                table: "GameResults",
                columns: new[] { "Id", "AreaHeight", "AreaWidth", "Mines", "Name", "Time" },
                values: new object[] { new Guid("8a397d8e-bb08-4610-b656-48901bbb835b"), 10u, 10u, 0u, "User 1", 1644769604L });

            migrationBuilder.InsertData(
                table: "GameResults",
                columns: new[] { "Id", "AreaHeight", "AreaWidth", "Mines", "Name", "Time" },
                values: new object[] { new Guid("b11b82af-1d7a-4082-b8f5-ceb980090546"), 100u, 100u, 0u, "User 5", 1644769604L });

            migrationBuilder.InsertData(
                table: "GameResults",
                columns: new[] { "Id", "AreaHeight", "AreaWidth", "Mines", "Name", "Time" },
                values: new object[] { new Guid("bac3b92f-a181-4b0a-9ac8-ba5aaf8ce236"), 50u, 25u, 0u, "User 3", 1644769604L });

            migrationBuilder.InsertData(
                table: "GameResults",
                columns: new[] { "Id", "AreaHeight", "AreaWidth", "Mines", "Name", "Time" },
                values: new object[] { new Guid("df725458-0c8c-4988-90d0-ef24460bbdf2"), 20u, 20u, 0u, "User 2", 1644769604L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameResults");
        }
    }
}
