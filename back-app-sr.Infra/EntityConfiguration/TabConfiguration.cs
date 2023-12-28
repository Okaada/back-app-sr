using back_app_sr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class TabConfiguration : IEntityTypeConfiguration<Tab>
{
    public void Configure(EntityTypeBuilder<Tab> builder)
    {
        // Chave primária
        builder.HasKey(t => t.TabId);

        // Configurações para a propriedade TabId
        builder.Property(t => t.TabId)
            .IsRequired();

        // Configurações para a propriedade TableNumber
        builder.Property(t => t.TableNumber);

        // Configurações para a propriedade Status
        builder.Property(t => t.Status)
            .IsRequired()
            .HasMaxLength(50);

        // Configurações para a propriedade Total
        builder.Property(t => t.Total)
            .IsRequired();

        // Configurações para a propriedade TabType
        builder.Property(t => t.TabType)
            .IsRequired()
            .HasMaxLength(50);

        // Configurações para a propriedade Orders
        builder.HasMany(t => t.Orders)
            .WithOne(order => order.Tab)
            .HasForeignKey(order => order.TabId);
        
        // Configurações para a propriedade TabPayment
        builder.HasMany(t => t.Payments)
            .WithOne(tp => tp.Tab)
            .HasForeignKey(tp => tp.TabId);
        
        // Configurações para a propriedade Delivery
        builder.HasOne(t => t.Delivery)
            .WithOne(d => d.Tab)
            .HasForeignKey<Delivery>(d => d.TabId);
    }
}