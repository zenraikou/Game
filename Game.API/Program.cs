using FluentValidation;
using Game.API.Contracts.Item;
using Game.API.Data;
using Game.API.Data.IRepository;
using Game.API.Data.Repository;
using Game.API.Validators;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers().AddNewtonsoftJson();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);

    builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
    builder.Services.AddMediatR(typeof(Program));

    builder.Services.AddScoped<IValidator<PostItemRequest>, PostItemRequestValidator>();
    builder.Services.AddScoped<IValidator<UpdateItemRequest>, UpdateItemRequestValidator>();
    
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
