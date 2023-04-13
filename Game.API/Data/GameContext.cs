using Game.API.Models;
using Game.API.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Game.API.Data;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options) : base(options) 
    { 
    }

    public DbSet<Item> Items => Set<Item>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item()
            {
                Name = "Dagon",
                Description = "A dagger crafted from the tooth of a Pure Silver Dragon.",
                Category = Category.Dagger,
                Element = Element.Light,
                Price = 0.99m
            },
            new Item()
            {
                Name = "Yasha",
                Description = "A sword crafted from the talon of a Pure Silver Dragon.",
                Category = Category.Sword,
                Element = Element.Light,
                Price = 1.99m
            },
            new Item()
            {
                Name = "Buriza",
                Description = "A bow crafted from the wing of a Pure Silver Dragon.",
                Category = Category.Bow,
                Element = Element.Light,
                Price = 2.99m
            },
            new Item()
            {
                Name = "Vanguard",
                Description = "A shield crafted from the scales of a Pure Silver Dragon.",
                Category = Category.Shield,
                Element = Element.Light,
                Price = 3.99m
            });
    }
}
