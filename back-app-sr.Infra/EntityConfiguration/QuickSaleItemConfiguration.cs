using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.QuickSale;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class QuickSaleItemConfiguration: IEntityTypeConfiguration<QuickSaleItemModel>
{
    public void Configure(EntityTypeBuilder<QuickSaleItemModel> builder)
    {
        // Chave primária
        builder.HasKey(qsi => qsi.QuickSaleItemId);

        // Configurações para a propriedade QuickSaleItemId
        builder.Property(qsi => qsi.QuickSaleItemId)
            .IsRequired();

        // Configurações para a propriedade ItemId
        builder.Property(qsi => qsi.ItemId)
            .IsRequired();

        // Configurações para a propriedade QuickSaleId
        builder.Property(qsi => qsi.QuickSaleId)
            .IsRequired();

        // Configurações para a propriedade QuickSale
        builder.HasOne(qsi => qsi.QuickSaleModel)
            .WithMany(qs => qs.QuickSaleItems)
            .HasForeignKey(qsi => qsi.QuickSaleId);
        
    }
}