using back_app_sr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class TabPaymentConfiguration : IEntityTypeConfiguration<TabPayment>
{
    public void Configure(EntityTypeBuilder<TabPayment> builder)
    {
        // Chave primária
        builder.HasKey(tp => tp.TabPaymentId);

        // Configurações para a propriedade TabPaymentId
        builder.Property(tp => tp.TabPaymentId)
            .IsRequired();

        builder.Property(tp => tp.PaymentType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(tp => tp.IsChangeRequested)
            .IsRequired();

        builder.Property(tp => tp.Change)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(tp => tp.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
    }
}