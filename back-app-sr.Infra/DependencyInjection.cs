using back_app_sr.Infra.Context;
using back_app_sr.Infra.Repository.Interfaces;
using back_app_sr.Infra.Repository.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace back_app_sr.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra (this IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql("Host=localhost;Port=5432;Database=RESTfood;Username=postgres;Password=root;"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}