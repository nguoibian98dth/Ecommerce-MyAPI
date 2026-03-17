using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.EntityConfigurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Description)
            .HasMaxLength(2000);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        // Relationships
        //builder.HasOne(x => x.Category)
        //    .WithMany(c => c.Products)
        //    .HasForeignKey(x => x.CategoryId)
        //    .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Variants)
            .WithOne(v => v.Product)
            .HasForeignKey(v => v.ProductId);

        // Index
        builder.HasIndex(x => x.CategoryId);

        // Soft delete
        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
