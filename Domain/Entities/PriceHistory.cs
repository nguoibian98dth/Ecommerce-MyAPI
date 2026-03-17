using Domain.BaseModel;

namespace Domain.Entities;

public class PriceHistory : BaseEntity<Guid>
{
    public Guid VariantId { get; set; }

    public ProductVariant Variant { get; set; }

    public decimal Price { get; set; }

    public DateTime EffectiveFrom { get; set; }
}
