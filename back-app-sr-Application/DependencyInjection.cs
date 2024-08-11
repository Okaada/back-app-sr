using back_app_sr_Application.Additional.Service.Implementation;
using back_app_sr_Application.Additional.Service.Interface;
using back_app_sr_Application.Item.Service.Implementation;
using back_app_sr_Application.Item.Service.Interface;
using back_app_sr_Application.Tab.Service.Implementation;
using back_app_sr_Application.Tab.Service.Interface;
using back_app_sr_Application.User.Service.Implementation;
using back_app_sr_Application.User.Service.Interface;
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
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IAdditionalService, AdditionalService>();
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        return services;

    }
}