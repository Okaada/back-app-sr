
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using back_app_sr.Domain.Models.Items;

namespace back_app_sr.Infra.EntityConfiguration;

public class AdditionalConfiguration : IEntityTypeConfiguration<AdditionalModel>
{
    public void Configure(EntityTypeBuilder<AdditionalModel> builder)
    {
        // Chave primária
        builder.HasKey(a => a.Id);

        // Configurações para a propriedade AdditionalId
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        // Configurações para a propriedade Name
        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(50);

        // Configurações para a propriedade Value
        builder.Property(a => a.Value)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
    }
}