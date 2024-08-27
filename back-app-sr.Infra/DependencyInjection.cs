using back_app_sr.Infra.Context;
using back_app_sr.Infra.Repository.Interfaces;
using back_app_sr.Infra.Repository.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace back_app_sr.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IAdditionalRepository, AdditionalRepository>();
        services.AddScoped<ITabRepository, TabRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        return services;
    }
}