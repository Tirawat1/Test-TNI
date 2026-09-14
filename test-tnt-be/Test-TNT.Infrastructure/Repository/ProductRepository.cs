using Microsoft.EntityFrameworkCore;
using Test_TNT.Domain.Contract;
using Test_TNT.Domain.Models;
using Test_TNT.Infrastructure.Models;

namespace Test_TNT.Infrastructure.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Product>> GetAll() => _context.Products.ToListAsync();

    public Task<List<Product>> GetByIds(IReadOnlyCollection<int> ids) =>
        _context.Products.Where(p => ids.Contains(p.Id)).OrderBy(p => p.Id).ToListAsync();
}
