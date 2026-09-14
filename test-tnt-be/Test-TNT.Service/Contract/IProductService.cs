using Test_TNT.Domain.Models;

namespace Test_TNT.Service.Contract;

public interface IProductService
{
    Task<List<Product>> GetAll();

}
