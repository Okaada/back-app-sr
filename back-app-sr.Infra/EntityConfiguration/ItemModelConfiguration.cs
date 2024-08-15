using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class ItemModelConfiguration : IEntityTypeConfiguration<ItemModel>
{
    public void Configure(EntityTypeBuilder<ItemModel> builder)
    {
        // Chave primária
        builder.HasKey(i => i.Id);

        // Configurações para a propriedade ItemId
        builder.Property(i => i.Id)
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