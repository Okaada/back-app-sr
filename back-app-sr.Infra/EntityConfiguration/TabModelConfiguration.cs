using back_app_sr.Domain.Models;
using back_app_sr.Domain.Models.Tab;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class TabModelConfiguration
{
    public void Configure(EntityTypeBuilder<TabModel> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.TableNumber)
            .IsRequired();
        
        builder.Property(t => t.Name)
            .IsRequired();

        builder.Property(t => t.Status)
            .IsRequired()
            .HasConversion(
                v => v, // Convert enum para inteiro
                v => v // Convert inteiro para enum
            )
            .IsRequired();

        builder.Property(t => t.Total)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasMany(t => t.Payments)
            .WithOne()
            .HasForeignKey("RegisterId"); // Supondo que PaymentModel tenha uma FK para TabId
    }

}