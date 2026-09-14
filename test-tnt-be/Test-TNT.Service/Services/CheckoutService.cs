using Test_TNT.Domain.Contract;
using Test_TNT.Domain.Dto;
using Test_TNT.Domain.Models;
using Test_TNT.Service.Contract;

namespace Test_TNT.Service.Services;

public class CheckoutService : ICheckoutService
{
    private readonly IProductRepository _productRepo;
    private readonly IOrderRepository _orderRepo;

    public CheckoutService(IProductRepository productRepo, IOrderRepository orderRepo)
    {
        _productRepo = productRepo;
        _orderRepo = orderRepo;
    }

    public async Task<CheckoutResult> Checkout(CheckoutRequestDto request)
    {
        if (request.Items.Count == 0)
            return CheckoutResult.Fail("EMPTY_CART", "ตะกร้าสินค้าว่างเปล่า");

        var productIds = request.Items.Select(i => i.ProductId).Distinct().ToList();
        var products = await _productRepo.GetByIds(productIds);
        var productMap = products.ToDictionary(p => p.Id);

        foreach (var item in request.Items)
        {
            if (!productMap.TryGetValue(item.ProductId, out var product))
                return CheckoutResult.Fail("PRODUCT_NOT_FOUND", $"ไม่พบสินค้ารหัส {item.ProductId}");

            if (product.Stock < item.Quantity)
                return CheckoutResult.Fail(
                    "OUT_OF_STOCK",
                    $"สินค้า '{product.ProductNameTh}' คงเหลือไม่พอ (คงเหลือ {product.Stock}, ต้องการ {item.Quantity})");
        }

        var order = new Order { CreatedAt = DateTime.UtcNow };

        foreach (var item in request.Items)
        {
            var product = productMap[item.ProductId];
            product.Stock -= item.Quantity;

            order.OrderItems.Add(new OrderItem
            {
                ProductId = product.Id,
                Quantity = item.Quantity,
                CostPerItem = product.CostPerItem,
                CreatedAt = DateTime.UtcNow,
            });
        }

        var saved = await _orderRepo.Add(order);
        var totalCost = saved.OrderItems.Sum(oi => oi.Quantity * oi.CostPerItem);

        return CheckoutResult.Ok(new CheckoutResponseDto
        {
            OrderId = saved.Id,
            TotalCost = totalCost,
            CreatedAt = saved.CreatedAt,
        });
    }
}
