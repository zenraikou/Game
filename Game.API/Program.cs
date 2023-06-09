using FluentValidation;
using Game.API.Common;
using Game.API.Persistence;
using Game.API.Persistence.IRepository;
using Game.API.Persistence.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddMvc().AddNewtonsoftJson();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
    builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
    builder.Services.AddMediatR(typeof(Program));
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddDbContext<GameContext>(options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("GameConnection"));
    });
}

var app = builder.Build();
{
    app.UseExceptionHandler("/api/error");
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
