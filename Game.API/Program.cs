using Game.API.Data;
using Game.API.Data.IRepository;
using Game.API.Data.Repository;
using Game.API.Middlewares;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<GameContext>(options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("GameConnection"));
    });
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddMediatR(typeof(Program));
    builder.Services.AddTransient<GlobalErrorHandlerMiddleware>();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Services.AddControllers().AddNewtonsoftJson();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseMiddleware<GlobalErrorHandlerMiddleware>();
    app.Run();
}
