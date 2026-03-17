using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insfrastructure.EntityConfigurations;

internal class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.ReservedQuantity)
            .IsRequired();

        builder.Property(x => x.RowVersion)
            .IsRowVersion()
            .IsConcurrencyToken();

        // Relationship
        builder.HasOne(x => x.Variant)
            .WithOne(v => v.Inventory)
            .HasForeignKey<Inventory>(x => x.VariantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.VariantId)
            .IsUnique();
    }
}
