using Game.API.Models;
using Game.API.Models.Enums;
using Microsoft.EntityFrameworkCore;

using Type = Game.API.Models.Enums.Type;

namespace Game.API.Persistence;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options) : base(options) { }

    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().Property(i => i.Price).HasPrecision(18, 2);

        modelBuilder.Entity<Item>().HasData(
            new Item
            {
                Name = "Dagon",
                Description = "A dagger crafted from the tooth of a Pure Silver Dragon.",
                Type = Type.Dagger,
                Element = Element.Light,
                Price = 0.99m
            },
            new Item
            {
                Name = "Yasha",
                Description = "A sword crafted from the talon of a Pure Silver Dragon.",
                Type = Type.Sword,
                Element = Element.Light,
                Price = 1.99m
            },
            new Item
            {
                Name = "Buriza",
                Description = "A bow crafted from the wing of a Pure Silver Dragon.",
                Type = Type.Bow,
                Element = Element.Light,
                Price = 2.99m
            },
            new Item
            {
                Name = "Vanguard",
                Description = "A shield crafted from the scales of a Pure Silver Dragon.",
                Type = Type.Shield,
                Element = Element.Light,
                Price = 3.99m
            });
    }
}
