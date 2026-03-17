namespace Application.Requests;

public class UpdateProductRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public Guid CategoryId { get; set; }
    public List<ProductVariantCreateDto> Variants { get; set; } = [];
}
