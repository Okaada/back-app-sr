using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.QuickSale;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class QuickSaleConfiguration : IEntityTypeConfiguration<QuickSaleModel>
{
    public void Configure(EntityTypeBuilder<QuickSaleModel> builder)
    {
        // Chave primária
        builder.HasKey(qs => qs.QuickSaleId);

        // Configurações para a propriedade QuickSaleId
        builder.Property(qs => qs.QuickSaleId)
            .IsRequired();

        // Configurações para a propriedade Total
        builder.Property(qs => qs.Total)
            .IsRequired();

        // Configurações para a propriedade QuickSaleItems
        builder.HasMany(qs => qs.QuickSaleItems)
            .WithOne(qsi => qsi.QuickSaleModel)
            .HasForeignKey(qsi => qsi.QuickSaleId);
    }
}