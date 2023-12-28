using back_app_sr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Chave primária
        builder.HasKey(o => o.OrderId);

        // Configurações para a propriedade OrderId
        builder.Property(o => o.OrderId)
            .IsRequired();

        // Configurações para a propriedade ItemId
        builder.Property(o => o.ItemId)
            .IsRequired();

        // Configurações para a propriedade AdditionalId
        builder.Property(o => o.AdditionalId);

        // Configurações para a propriedade Observation
        builder.Property(o => o.Observation)
            .HasMaxLength(50);

        // Configurações para a propriedade Quantity
        builder.Property(o => o.Quantity)
            .IsRequired();
    }
}