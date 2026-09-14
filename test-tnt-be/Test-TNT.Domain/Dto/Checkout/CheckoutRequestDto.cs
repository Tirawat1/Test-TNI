namespace Test_TNT.Domain.Dto;

public class CheckoutRequestItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class CheckoutRequestDto
{
    public List<CheckoutRequestItemDto> Items { get; set; } = new();
}
