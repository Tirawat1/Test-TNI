using Test_TNT.Domain.Contract;
using Test_TNT.Domain.Models;
using Test_TNT.Infrastructure.Models;

namespace Test_TNT.Infrastructure.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order> Add(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }
}
