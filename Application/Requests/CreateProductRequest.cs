using Domain.Entities;

namespace Application.Requests;

public class CreateProductRequest
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public Guid CategoryId { get; set; }

    public List<ProductVariantCreateDto> Variants { get; set; } = [];
}

public class ProductVariantCreateDto
{
    public Guid ProductId { get; set; }

    public string SKU { get; set; }

    public decimal Price { get; set; }

    public string Attributes { get; set; } // JSON

    public int InitialStock { get; set; }
}
