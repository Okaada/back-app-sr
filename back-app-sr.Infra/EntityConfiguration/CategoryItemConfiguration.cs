using back_app_sr.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back_app_sr.Infra.EntityConfiguration
{
    public class CategoryItemConfiguration : IEntityTypeConfiguration<CategoryItemModel>
    {
        public void Configure(EntityTypeBuilder<CategoryItemModel> builder)
        {
            // Chave primária
            builder.HasKey(c => c.CategoryItemId);

            // Configurações para a propriedade CategoryItemId
            builder.Property(c => c.CategoryItemId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            // Configurações para a propriedade Name
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Configuração da relação com a tabela ItemModel
            builder.HasMany(c => c.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}