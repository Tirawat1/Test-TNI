using Test_TNT.Domain.Models;

namespace Test_TNT.Domain.Contract;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    Task<List<Product>> GetByIds(IReadOnlyCollection<int> ids);
}
