using System;
using System.Collections.Generic;

namespace Test_TNT.Domain.Models;

public partial class Order
{
    public int Id { get; set; }

    /// <summary>
    /// ราคารวม ณ ตอนสั่งซื้อ
    /// </summary>
    public int TotalCost { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
