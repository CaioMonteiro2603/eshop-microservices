using Discount.Grpc.Models;

namespace Discount.Grpc.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; } = default!;
    public DiscountContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = "Iphone 13", Description = "Iphone discount", Amount = 150 },
            new Coupon { Id = 2, ProductName = "Iphone X", Description = "Iphone discount", Amount = 100 }
            ); 
    }

}
