namespace Test_TNT.Domain.Dto;

public class CheckoutResponseDto
{
    public int OrderId { get; set; }
    public int TotalCost { get; set; }
    public DateTime CreatedAt { get; set; }
}
