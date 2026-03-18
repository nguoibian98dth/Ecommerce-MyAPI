using Application.Contracts;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.RegisterServices();
        services.ConfigMapster();
    }

    private static void ConfigMapster(this IServiceCollection services)
    {
        services.AddMapster();

        var config = TypeAdapterConfig.GlobalSettings;

        // scan all IRegister in assembly
        config.Scan(Assembly.GetExecutingAssembly());
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<Contracts.IProductService, Features.ProductService>();
        services.AddScoped<Contracts.IInventoryService, Features.InventoryService>();
        services.AddScoped<Contracts.ICommonService, Features.CommonService>();

    }
}
