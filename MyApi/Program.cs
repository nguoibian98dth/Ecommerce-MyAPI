using Application;
using Insfrastructure;
using Mapster;
using Microsoft.AspNetCore.Cors.Infrastructure;
using MyApi.Middlewares;
using MyApi.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var corsPolicy = "AllowFE";

builder.Services.AddCors(option =>
{
    var corsOptions = builder.Configuration
            .GetSection(MyApi.Options.CorsOptions.SectionName)
            .Get<MyApi.Options.CorsOptions>();

    option.AddPolicy(corsPolicy,
        p => p.WithOrigins(corsOptions.AllowedOrigins)
              .SetIsOriginAllowed(origin =>
                    (new Uri(origin).Host == "localhost" && corsOptions.IsAllowLocalhost) ||
                    corsOptions.AllowedOrigins.Contains(origin.TrimEnd('/')))
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
    );
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInsfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddExceptionHandler<ExceptionHandlingMiddleware>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
