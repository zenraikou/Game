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
                    Type = table.Column<int>(type: "int", nullable: false),
                    Element = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Element", "Name", "Price", "Timestamp", "Type" },
                values: new object[,]
                {
                    { new Guid("7b7c7de0-9d9e-4027-acf8-78e27f766ed4"), "A bow crafted from the wing of a Pure Silver Dragon.", 4, "Buriza", 2.99m, new DateTime(2023, 4, 27, 8, 3, 36, 909, DateTimeKind.Utc).AddTicks(2069), 2 },
                    { new Guid("86f6123a-2597-4a40-8e03-7f6c34c9a372"), "A sword crafted from the talon of a Pure Silver Dragon.", 4, "Yasha", 1.99m, new DateTime(2023, 4, 27, 8, 3, 36, 909, DateTimeKind.Utc).AddTicks(2060), 1 },
                    { new Guid("8cbd15b2-85b6-4acb-9d19-7ad7e3730a06"), "A shield crafted from the scales of a Pure Silver Dragon.", 4, "Vanguard", 3.99m, new DateTime(2023, 4, 27, 8, 3, 36, 909, DateTimeKind.Utc).AddTicks(2076), 3 },
                    { new Guid("ae7150c1-98f9-4c16-8100-bd1de8259302"), "A dagger crafted from the tooth of a Pure Silver Dragon.", 4, "Dagon", 0.99m, new DateTime(2023, 4, 27, 8, 3, 36, 909, DateTimeKind.Utc).AddTicks(2031), 0 }
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
