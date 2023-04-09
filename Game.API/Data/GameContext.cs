using Game.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Game.API.Data;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options) : base(options) { }

    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(
            new Item()
            {
                Name = "Dagon",
                Description = "A dagger crafted from the tooth of a Pure Silver Dragon."
            },
            new Item()
            {
                Name = "Yasha",
                Description = "A sword crafted from the talon of a Pure Silver Dragon."
            },
            new Item()
            {
                Name = "Buriza",
                Description = "A bow crafted from the wing of a Pure Silver Dragon."
            },
            new Item()
            {
                Name = "Vanguard",
                Description = "An armor crafted from the scales of a Pure Silver Dragon."
            });
    }
}