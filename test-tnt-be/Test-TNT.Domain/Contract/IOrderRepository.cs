using Test_TNT.Domain.Models;

namespace Test_TNT.Domain.Contract;

public interface IOrderRepository
{
    Task<Order> Add(Order order);
}
