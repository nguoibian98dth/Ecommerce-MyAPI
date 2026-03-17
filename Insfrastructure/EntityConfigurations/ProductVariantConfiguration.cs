using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastructure.EntityConfigurations
{
    internal class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SKU)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // JSON (SQL Server: NVARCHAR(MAX), PostgreSQL: jsonb)
            builder.Property(x => x.Attributes)
                .HasColumnType("nvarchar(max)");

            // Relationships
            builder.HasOne(x => x.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Inventory)
                .WithOne(i => i.Variant)
                .HasForeignKey<Inventory>(i => i.VariantId);

            // Indexes
            builder.HasIndex(x => x.SKU)
                .IsUnique();

            builder.HasIndex(x => x.ProductId);

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
