using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<Contracts.IProductService, Features.ProductService>();
    }
}
