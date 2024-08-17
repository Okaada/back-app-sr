using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.Deliver;
using back_app_sr.Domain.Models.Items;
using back_app_sr.Domain.Models.Payment;
using back_app_sr.Domain.Models.QuickSale;
using back_app_sr.Domain.Models.Tab;
using Microsoft.EntityFrameworkCore;

namespace back_app_sr.Infra.Context;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
    
    public DbSet<AdditionalModel> Additionals { get; set; }
    public DbSet<ItemModel> Items { get; set; }
    public DbSet<AllowedAdditionalsModel> AllowedAdditionals { get; set; }
    public DbSet<TabModel> Tab { get; set; }
    public DbSet<OrderItemsTabModel> OrdersItemsTab { get; set; }
    public DbSet<ItemOrderAdditionalModel> ItemOrderAdditional { get; set; }
    public DbSet<PaymentModel> Payments { get; set; }
    public DbSet<QuickSaleModel> QuickSales { get; set; }
    public DbSet<QuickSaleItemModel> QuickSaleItems { get; set; }
    public DbSet<DeliveryRegisterModel> DeliveryRegister { get; set; }
    public DbSet<ExternalOrderItensModel> ExternalOrderItens { get; set; }
    
    public DbSet<UserModel> Users { get; set; }
}