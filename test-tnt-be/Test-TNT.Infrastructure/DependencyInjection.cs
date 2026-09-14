using Microsoft.Extensions.DependencyInjection;
using Test_TNT.Domain.Contract;
using Test_TNT.Infrastructure.Repository;

namespace Test_TNT.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
