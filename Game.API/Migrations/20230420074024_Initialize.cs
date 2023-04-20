using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    { new Guid("53f528af-1f82-4e37-9876-7f25cf2f7481"), "A bow crafted from the wing of a Pure Silver Dragon.", 4, "Buriza", 2.99m, new DateTime(2023, 4, 20, 7, 40, 23, 623, DateTimeKind.Utc).AddTicks(6135), 2 },
                    { new Guid("64e7c953-87cb-4ec0-9adc-a6aa145a099b"), "A dagger crafted from the tooth of a Pure Silver Dragon.", 4, "Dagon", 0.99m, new DateTime(2023, 4, 20, 7, 40, 23, 623, DateTimeKind.Utc).AddTicks(6103), 0 },
                    { new Guid("c2f90f2b-8568-4fb6-8c2c-7488a00b7681"), "A shield crafted from the scales of a Pure Silver Dragon.", 4, "Vanguard", 3.99m, new DateTime(2023, 4, 20, 7, 40, 23, 623, DateTimeKind.Utc).AddTicks(6140), 3 },
                    { new Guid("f9447fa9-2d85-4a78-bcc3-c4b4f28d1e6e"), "A sword crafted from the talon of a Pure Silver Dragon.", 4, "Yasha", 1.99m, new DateTime(2023, 4, 20, 7, 40, 23, 623, DateTimeKind.Utc).AddTicks(6127), 1 }
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
