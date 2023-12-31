using back_app_sr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class ItemConfiguration : IEntityTypeConfiguration<ItemModel>
{
    public void Configure(EntityTypeBuilder<ItemModel> builder)
    {
        // Chave primária
        builder.HasKey(i => i.ItemId);

        // Configurações para a propriedade ItemId
        builder.Property(i => i.ItemId)
            .ValueGeneratedOnAdd()
            .IsRequired();

        // Configurações para a propriedade Name
        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(i => i.Value)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        

    }
}