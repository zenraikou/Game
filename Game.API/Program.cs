using Game.API.Data;
using Game.API.Data.IRepository;
using Game.API.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers().AddNewtonsoftJson();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Services.AddScoped<IItemRepository, ItemRepository>();
    builder.Services.AddDbContext<GameContext>(options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("GameConnection"));
    });
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
