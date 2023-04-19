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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    { new Guid("383b3d10-3f46-4c85-b91a-a4d19e028969"), "A shield crafted from the scales of a Pure Silver Dragon.", 4, "Vanguard", 3.99m, new DateTime(2023, 4, 19, 12, 32, 47, 232, DateTimeKind.Utc).AddTicks(6057), 3 },
                    { new Guid("6b40b230-c6c4-40a4-92bf-01db943d7d2c"), "A sword crafted from the talon of a Pure Silver Dragon.", 4, "Yasha", 1.99m, new DateTime(2023, 4, 19, 12, 32, 47, 232, DateTimeKind.Utc).AddTicks(6044), 1 },
                    { new Guid("e438fd4c-8a72-46ea-a5e8-3c4df850b6d9"), "A dagger crafted from the tooth of a Pure Silver Dragon.", 4, "Dagon", 0.99m, new DateTime(2023, 4, 19, 12, 32, 47, 232, DateTimeKind.Utc).AddTicks(6027), 0 },
                    { new Guid("fe149d4f-00e5-468c-8a1c-12408176ac53"), "A bow crafted from the wing of a Pure Silver Dragon.", 4, "Buriza", 2.99m, new DateTime(2023, 4, 19, 12, 32, 47, 232, DateTimeKind.Utc).AddTicks(6051), 2 }
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
