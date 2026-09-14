
namespace TNTTest.Service;

using Microsoft.Extensions.DependencyInjection;
using Test_TNT.Service.Contract;
using Test_TNT.Service.Services;

// Service layer ประกาศ service ของตัวเอง — เพิ่ม service ใหม่ แก้ที่นี่ ไม่ต้องไปแตะ Program.cs
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICheckoutService, CheckoutService>();

        return services;
    }
}
