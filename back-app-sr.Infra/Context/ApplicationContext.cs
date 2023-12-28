using back_app_sr.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace back_app_sr.Infra.Context;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }

    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Additional> Additionals { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Tab> Tabs { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<TabPayment> TabPayments { get; set; }
    public DbSet<QuickSale> QuickSales { get; set; }
    public DbSet<QuickSaleItem> QuickSaleItems { get; set; }
    public DbSet<UserModel> Users { get; set; }
}