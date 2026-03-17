using Domain.BaseModel;

namespace Domain.Entities;

public class ProductVariant : BaseEntity<Guid>
{
    public Guid ProductId { get; set; }

    public Product Product { get; set; }

    public string SKU { get; set; }

    public decimal Price { get; set; }

    public string Attributes { get; set; } // JSON

    public Inventory Inventory { get; set; }
}
