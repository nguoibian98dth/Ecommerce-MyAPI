using Domain.BaseModel;

namespace Domain.Entities;

public class Product : BaseEntity<Guid>
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = new();

    public List<ProductVariant> Variants { get; set; } = [];

}
