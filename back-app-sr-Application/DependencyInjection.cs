using back_app_sr_Application.Tab.Business.Interface;
using back_app_sr_Application.Tab.Business.Service;
using back_app_sr_Application.User.Business.Interface;
using back_app_sr_Application.User.Business.Service;
using Microsoft.Extensions.DependencyInjection;

namespace back_app_sr_Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITabService, TabService>();
        services.AddScoped<ITabOrderService, TabOrderService>();
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        return services;

    }
}