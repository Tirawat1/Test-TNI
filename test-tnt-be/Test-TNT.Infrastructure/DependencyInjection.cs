using Microsoft.Extensions.DependencyInjection;
using Test_TNT.Domain.Contract;
using Test_TNT.Infrastructure.Repository;

namespace Test_TNT.Infrastructure;

// Infrastructure layer ประกาศ repository ของตัวเอง — เพิ่ม repository ใหม่ แก้ที่นี่ ไม่ต้องไปแตะ Program.cs
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
