using back_app_sr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class AdditionalConfiguration : IEntityTypeConfiguration<AdditionalModel>
{
    public void Configure(EntityTypeBuilder<AdditionalModel> builder)
    {
        // Chave primária
        builder.HasKey(a => a.AdditionalId);

        // Configurações para a propriedade AdditionalId
        builder.Property(a => a.AdditionalId)
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