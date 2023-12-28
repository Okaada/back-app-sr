using back_app_sr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        // Chave primária
        builder.HasKey(u => u.UserId);

        // Configurações para a propriedade UserId
        builder.Property(u => u.UserId)
            .IsRequired();

        // Configurações para a propriedade Name
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        // Configurações para a propriedade Email
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        // Configurações para a propriedade Password
        builder.Property(u => u.Password)
            .IsRequired();

        // Configurações para a propriedade Role
        builder.Property(u => u.Role)
            .HasMaxLength(50);

    }
}