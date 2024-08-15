using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class ItemOrderAdditionalModelConfiguration : IEntityTypeConfiguration<ItemOrderAdditionalModel>
{
    public void Configure(EntityTypeBuilder<ItemOrderAdditionalModel> builder)
    {
        builder.HasKey(ioam => ioam.Id);

        builder.HasOne(ioam => ioam.Item)
            .WithMany() // Se `ItemModel` não tiver uma coleção de `ItemOrderAdditionalModel`
            .HasForeignKey(ioam => ioam.ItemId);

        builder.HasOne(ioam => ioam.AdditionalModel)
            .WithMany()
            .HasForeignKey(ioam => ioam.AdditionalId);

        builder.Property(ioam => ioam.Quantity)
            .IsRequired();
    }
}
