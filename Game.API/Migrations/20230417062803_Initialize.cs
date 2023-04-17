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
                    Category = table.Column<int>(type: "int", nullable: false),
                    Element = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Category", "Description", "Element", "Name", "Price", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("0fe99fbe-4def-46e7-a51d-c60f55324dfe"), 0, "A dagger crafted from the tooth of a Pure Silver Dragon.", 4, "Dagon", 0.99m, new DateTime(2023, 4, 17, 6, 28, 3, 143, DateTimeKind.Utc).AddTicks(5897) },
                    { new Guid("3539245d-2b2a-4132-b5f0-8747b4ea89de"), 2, "A bow crafted from the wing of a Pure Silver Dragon.", 4, "Buriza", 2.99m, new DateTime(2023, 4, 17, 6, 28, 3, 143, DateTimeKind.Utc).AddTicks(5920) },
                    { new Guid("d3336881-b66f-444b-b185-b9e4586fb161"), 1, "A sword crafted from the talon of a Pure Silver Dragon.", 4, "Yasha", 1.99m, new DateTime(2023, 4, 17, 6, 28, 3, 143, DateTimeKind.Utc).AddTicks(5914) },
                    { new Guid("d3d1beee-2a78-4f86-9573-b2f4d65cd9db"), 3, "A shield crafted from the scales of a Pure Silver Dragon.", 4, "Vanguard", 3.99m, new DateTime(2023, 4, 17, 6, 28, 3, 143, DateTimeKind.Utc).AddTicks(5926) }
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
