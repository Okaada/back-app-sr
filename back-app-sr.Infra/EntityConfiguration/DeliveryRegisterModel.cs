using back_app_sr.Domain.Models.Deliver;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class DeliveryRegisterModelConfiguration : IEntityTypeConfiguration<DeliveryRegisterModel>
{
    public void Configure(EntityTypeBuilder<DeliveryRegisterModel> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Address)
            .IsRequired();

        builder.Property(t => t.Name)
            .IsRequired();

        builder.Property(t => t.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasMany(t => t.Payments)
            .WithOne()
            .HasForeignKey("RegisterId"); // Supondo que PaymentModel tenha uma FK para TabId
    }
}