using Game.API.Data;
using Game.API.Data.IRepository;
using Game.API.Data.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<GameContext>(options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("GameConnection"));
    });
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Services.AddControllers().AddNewtonsoftJson();
    builder.Services.AddMediatR(typeof(Program));
}

var app = builder.Build();
{
    app.UseExceptionHandler("/api/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
