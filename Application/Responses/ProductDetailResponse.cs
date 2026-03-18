namespace Application.Responses;

public class ProductDetailResponse
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }
}
