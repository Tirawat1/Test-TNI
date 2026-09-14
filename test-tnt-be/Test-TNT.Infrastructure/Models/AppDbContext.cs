using Microsoft.EntityFrameworkCore;
using Test_TNT.Domain.Models;

namespace Test_TNT.Infrastructure.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveConversion<UtcDateTimeConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Order_pkey");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TotalCost)
                .HasDefaultValue(0)
                .HasComment("ราคารวม ณ ตอนสั่งซื้อ")
                .HasColumnName("total_cost");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Order_item_pkey");

            entity.ToTable("Order_item");

            entity.HasIndex(e => e.OrderId, "idx_order_item_order_id");

            entity.HasIndex(e => e.ProductId, "idx_order_item_product_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CostPerItem)
                .HasDefaultValue(0)
                .HasComment("ราคาต่อชิ้น ณ ตอนสั่งซื้อ (snapshot)")
                .HasColumnName("cost_per_item");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity)
                .HasDefaultValue(1)
                .HasComment("จำนวนที่สั่งซื้อ")
                .HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Order_item_order_id_fkey");


        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Product_pkey");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(8)
                .HasColumnName("code");
            entity.Property(e => e.CostPerItem)
                .HasDefaultValue(0)
                .HasComment("ราคาสินค้าต่อชิ้น")
                .HasColumnName("cost_per_item");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ProductNameEn)
                .HasMaxLength(255)
                .HasColumnName("product_name_en");
            entity.Property(e => e.ProductNameTh)
                .HasMaxLength(255)
                .HasColumnName("product_name_th");
            entity.Property(e => e.Stock)
                .HasDefaultValue(0)
                .HasComment("จำนวนคงเหลือ")
                .HasColumnName("stock");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
