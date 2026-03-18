using Domain.Entities;

namespace Application.Responses;

public class ProductDetailResponse
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public List<ProductVariantDto> Variants { get; set; }

    public decimal? FromPrice => Variants?.Min(v => v.Price);

    public decimal? ToPrice => Variants?.Max(v => v.Price);
}

public class ProductVariantDto
{
    public Guid Id { get; set; }

    public string? SKU { get; set; }

    public decimal? Price { get; set; }

    public string? Attributes { get; set; }

    public int Stock { get; set; }
}
