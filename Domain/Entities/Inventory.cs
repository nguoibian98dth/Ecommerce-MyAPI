using Domain.BaseModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Inventory : BaseEntity<Guid>
{
    public ProductVariant Variant { get; set; } = new();

    [Timestamp]
    public byte[] RowVersion { get; set; } = default!;

    public Guid VariantId { get; private set; }

    public int Quantity { get; private set; }

    public int ReservedQuantity { get; private set; }

    private Inventory() { }

    public Inventory(Guid variantId, int initialStock)
    {
        Id = Guid.NewGuid();
        VariantId = variantId;
        Quantity = initialStock;
        ReservedQuantity = 0;
    }

    public void Reserve(int quantity)
    {
        if (Quantity - ReservedQuantity < quantity)
            throw new Exception("Insufficient stock");

        ReservedQuantity += quantity;
    }

    public void Release(int quantity)
    {
        ReservedQuantity -= quantity;
        if (ReservedQuantity < 0)
            ReservedQuantity = 0;
    }

    public void Adjust(int quantity)
    {
        if (Quantity + quantity < 0)
            throw new Exception("Stock cannot be negative");

        Quantity += quantity;
    }
}
