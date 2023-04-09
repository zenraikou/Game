using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Game.API.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("0a0ab9b7-2164-47a3-b665-b3a69d544e6f"), "A dagger crafted from the tooth of a Pure Silver Dragon.", "Dagon", new DateTime(2023, 4, 9, 13, 23, 39, 45, DateTimeKind.Utc).AddTicks(6112) },
                    { new Guid("30d51435-fd1b-4d94-a2ea-b848df16b74c"), "A sword crafted from the talon of a Pure Silver Dragon.", "Yasha", new DateTime(2023, 4, 9, 13, 23, 39, 45, DateTimeKind.Utc).AddTicks(6127) },
                    { new Guid("7fcf4f3b-01c6-4b92-8a57-2739144b29a3"), "An armor crafted from the scales of a Pure Silver Dragon.", "Vanguard", new DateTime(2023, 4, 9, 13, 23, 39, 45, DateTimeKind.Utc).AddTicks(6187) },
                    { new Guid("e1fab68c-cce8-40bf-9f42-e37f9f05fe61"), "A bow crafted from the wing of a Pure Silver Dragon.", "Buriza", new DateTime(2023, 4, 9, 13, 23, 39, 45, DateTimeKind.Utc).AddTicks(6182) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
