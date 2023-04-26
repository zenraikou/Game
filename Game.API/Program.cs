using FluentValidation;
using FluentValidation.AspNetCore;
using Game.API.Common;
using Game.API.Data;
using Game.API.Data.IRepository;
using Game.API.Data.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Services.AddMvc().AddNewtonsoftJson();
    builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
    builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
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
