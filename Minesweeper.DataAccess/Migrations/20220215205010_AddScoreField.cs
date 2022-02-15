using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Minesweeper.DataAccess.Migrations
{
    public partial class AddScoreField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameResults",
                keyColumn: "Id",
                keyValue: new Guid("445c99bb-7088-4243-8c39-d79effae2691"));

            migrationBuilder.DeleteData(
                table: "GameResults",
                keyColumn: "Id",
                keyValue: new Guid("8a397d8e-bb08-4610-b656-48901bbb835b"));

            migrationBuilder.DeleteData(
                table: "GameResults",
                keyColumn: "Id",
                keyValue: new Guid("b11b82af-1d7a-4082-b8f5-ceb980090546"));

            migrationBuilder.DeleteData(
                table: "GameResults",
                keyColumn: "Id",
                keyValue: new Guid("bac3b92f-a181-4b0a-9ac8-ba5aaf8ce236"));

            migrationBuilder.DeleteData(
                table: "GameResults",
                keyColumn: "Id",
                keyValue: new Guid("df725458-0c8c-4988-90d0-ef24460bbdf2"));

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "GameResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "GameResults",
                columns: new[] { "Id", "AreaHeight", "AreaWidth", "Mines", "Name", "Score", "Time" },
                values: new object[] { new Guid("4fb20731-278c-4873-bed7-b8e26c5cb1f9"), 10u, 10u, 10u, "User 1", 15, 1644958210L });

            migrationBuilder.InsertData(
                table: "GameResults",
                columns: new[] { "Id", "AreaHeight", "AreaWidth", "Mines", "Name", "Score", "Time" },
                values: new object[] { new Guid("b1359b33-8aec-4028-bb8e-e8fa8ae8b194"), 100u, 100u, 10u, "User 5", 10, 1644958210L });

            migrationBuilder.InsertData(
                table: "GameResults",
                columns: new[] { "Id", "AreaHeight", "AreaWidth", "Mines", "Name", "Score", "Time" },
                values: new object[] { new Guid("c35d2567-a5f6-4230-95d4-0695581e5cc8"), 50u, 50u, 10u, "User 4", 11, 1644958210L });

            migrationBuilder.InsertData(
                table: "GameResults",
                columns: new[] { "Id", "AreaHeight", "AreaWidth", "Mines", "Name", "Score", "Time" },
                values: new object[] { new Guid("d2904665-2213-4a9f-bfec-45fe31f7abb5"), 20u, 20u, 10u, "User 2", 12, 1644958210L });

            migrationBuilder.InsertData(
                table: "GameResults",
                columns: new[] { "Id", "AreaHeight", "AreaWidth", "Mines", "Name", "Score", "Time" },
                values: new object[] { new Guid("dbc5805f-9157-4bc3-86f8-d645459eaf23"), 50u, 25u, 10u, "User 3", 12, 1644958210L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameResults",
                keyColumn: "Id",
                keyValue: new Guid("4fb20731-278c-4873-bed7-b8e26c5cb1f9"));

            migrationBuilder.DeleteData(
                table: "GameResults",
                keyColumn: "Id",
                keyValue: new Guid("b1359b33-8aec-4028-bb8e-e8fa8ae8b194"));

            migrationBuilder.DeleteData(
                table: "GameResults",
                keyColumn: "Id",
                keyValue: new Guid("c35d2567-a5f6-4230-95d4-0695581e5cc8"));

            migrationBuilder.DeleteData(
                table: "GameResults",
                keyColumn: "Id",
                keyValue: new Guid("d2904665-2213-4a9f-bfec-45fe31f7abb5"));

            migrationBuilder.DeleteData(
                table: "GameResults",
                keyColumn: "Id",
                keyValue: new Guid("dbc5805f-9157-4bc3-86f8-d645459eaf23"));

            migrationBuilder.DropColumn(
                name: "Score",
                table: "GameResults");

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
    }
}
