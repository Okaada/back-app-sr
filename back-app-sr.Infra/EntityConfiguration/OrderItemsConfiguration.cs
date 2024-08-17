using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.Tab;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class OrderItemsConfiguration
{
    public void Configure(EntityTypeBuilder<OrderItemsTabModel> builder)
    {
        builder.HasKey(oit => oit.Id);

        builder.Property(oit => oit.Quantity)
            .IsRequired();

        builder.HasOne<OrderItemsTabModel>() // Presume que há um relacionamento com OrderTabModel
            .WithMany() // Se `OrderTabModel` não tiver uma coleção de `OrderItemsTabModel`
            .HasForeignKey(oit => oit.TabId)
            .IsRequired();
    }
}