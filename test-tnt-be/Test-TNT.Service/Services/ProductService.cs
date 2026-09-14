using Test_TNT.Domain.Contract;
using Test_TNT.Domain.Models;
using Test_TNT.Service.Contract;

namespace Test_TNT.Service.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Product>> GetAll()
    {
        return await _repo.GetAll();
    }
}