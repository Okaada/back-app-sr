using back_app_sr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class DeliveryConfiguration : IEntityTypeConfiguration<DeliveryModel>
{
    public void Configure(EntityTypeBuilder<DeliveryModel> builder)
    {
        // Chave primária
        builder.HasKey(d => d.DeliveryId);

        // Configurações para a propriedade DeliveryId
        builder.Property(d => d.DeliveryId)
            .IsRequired();

        // Configurações para a propriedade Address
        builder.Property(d => d.Address)
            .IsRequired()
            .HasMaxLength(300);
        
        builder.Property(d => d.Telephone)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(300);
    }
}