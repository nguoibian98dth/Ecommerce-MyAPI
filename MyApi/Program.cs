using Application;
using Insfrastructure;
using MyApi.Middlewares;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

var corsPolicy = "AllowFE";

builder.Services.AddCors(option =>
{
    var corsOptions = builder.Configuration
            .GetSection(MyApi.Options.CorsOptions.SectionName)
            .Get<MyApi.Options.CorsOptions>();

    ArgumentException.ThrowIfNullOrEmpty(nameof(corsOptions), "AllowedOrigins must be provided in configuration.");

    option.AddPolicy(corsPolicy,
        p => p.WithOrigins(corsOptions!.AllowedOrigins)
              .SetIsOriginAllowed(origin =>
                    (new Uri(origin).Host == "localhost" && corsOptions.IsAllowLocalhost) ||
                    corsOptions.AllowedOrigins.Contains(origin.TrimEnd('/')))
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
    );
});

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 100,
                Window = TimeSpan.FromMinutes(1),
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                QueueLimit = 10
            }));
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

app.UseRateLimiter();

app.MapControllers();

app.Run();
