
using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class AllowedAdditionalsModelConfiguration : IEntityTypeConfiguration<AllowedAdditionalsModel>
{
    public void Configure(EntityTypeBuilder<AllowedAdditionalsModel> builder)
    {
        builder.HasKey(aam => aam.Id);

        builder.HasOne(aam => aam.Item)
            .WithMany() // Se `ItemModel` não tiver uma coleção de `AllowedAdditionalsModel`
            .HasForeignKey(aam => aam.ItemId);

        builder.HasOne(aam => aam.AdditionalModel)
            .WithMany()
            .HasForeignKey(aam => aam.AdditionalId);
    }
}