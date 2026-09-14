
namespace TNTTest.Service;

using Microsoft.Extensions.DependencyInjection;
using Test_TNT.Service.Contract;
using Test_TNT.Service.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICheckoutService, CheckoutService>();

        return services;
    }
}
