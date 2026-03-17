using Domain.Entities.Repository;
using Insfrastructure.DbContexts;
using Insfrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Insfrastructure;

public static class InsfrastructureRegistration
{
    public static void AddInsfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureEFCore(services, configuration);

        //DI repos
        services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static void ConfigureEFCore(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<ApplicationDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("Default")));
    }

}
