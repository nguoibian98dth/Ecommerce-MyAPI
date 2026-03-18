using Application;
using Insfrastructure;
using MyApi.Middlewares;
using MyApi.Options;

var builder = WebApplication.CreateBuilder(args);

var corsPolicy = "AllowFE";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, policy =>
    {
        var corsOptions = builder.Configuration
            .GetSection(CorsOptions.SectionName)
            .Get<CorsOptions>();

        policy
            .WithOrigins(corsOptions!.AllowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
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
