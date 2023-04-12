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
                    { new Guid("1ebc725c-b1ec-43a4-8be8-a700a17b769d"), 0, "A dagger crafted from the tooth of a Pure Silver Dragon.", 4, "Dagon", 0.99m, new DateTime(2023, 4, 12, 8, 22, 25, 753, DateTimeKind.Utc).AddTicks(6224) },
                    { new Guid("69739a03-4441-4e51-a2dd-a611848ffbe3"), 3, "A shield crafted from the scales of a Pure Silver Dragon.", 4, "Vanguard", 3.99m, new DateTime(2023, 4, 12, 8, 22, 25, 753, DateTimeKind.Utc).AddTicks(6307) },
                    { new Guid("9334aa54-06f3-4f0e-a708-39cdd532bbe0"), 1, "A sword crafted from the talon of a Pure Silver Dragon.", 4, "Yasha", 1.99m, new DateTime(2023, 4, 12, 8, 22, 25, 753, DateTimeKind.Utc).AddTicks(6243) },
                    { new Guid("b85f4500-d4e1-4a86-8c9a-495725d00d7d"), 2, "A bow crafted from the wing of a Pure Silver Dragon.", 4, "Buriza", 2.99m, new DateTime(2023, 4, 12, 8, 22, 25, 753, DateTimeKind.Utc).AddTicks(6302) }
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
