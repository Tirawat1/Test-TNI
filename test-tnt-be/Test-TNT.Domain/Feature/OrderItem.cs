namespace Test_TNT.Domain.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    /// <summary>
    /// จำนวนที่สั่งซื้อ
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// ราคาต่อชิ้น ณ ตอนสั่งซื้อ (snapshot)
    /// </summary>
    public int CostPerItem { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
