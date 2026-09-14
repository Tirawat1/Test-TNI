namespace Test_TNT.Domain.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? ProductNameTh { get; set; }

    public string? ProductNameEn { get; set; }

    /// <summary>
    /// จำนวนคงเหลือ
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// ราคาสินค้าต่อชิ้น
    /// </summary>
    public int CostPerItem { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

}
