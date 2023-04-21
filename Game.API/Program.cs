using Game.API.Data;
using Game.API.Data.IRepository;
using Game.API.Data.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext().CreateLogger();

    builder.Services.AddControllers().AddNewtonsoftJson();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);

    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog();
    
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddDbContext<GameContext>(options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("GameConnection"));
    });
    
    builder.Services.AddMediatR(typeof(Program));
}

var app = builder.Build();
{
    app.UseExceptionHandler("/api/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
