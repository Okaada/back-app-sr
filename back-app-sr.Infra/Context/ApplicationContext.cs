using back_app_sr.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace back_app_sr.Infra.Context;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }

    public DbSet<DeliveryModel> Deliveries { get; set; }
    public DbSet<AdditionalModel> Additionals { get; set; }
    public DbSet<ItemModel> Items { get; set; }
    public DbSet<TabModel> Tabs { get; set; }
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<TabPayment> TabPayments { get; set; }
    public DbSet<QuickSale> QuickSales { get; set; }
    public DbSet<QuickSaleItem> QuickSaleItems { get; set; }
    public DbSet<UserModel> Users { get; set; }
}