namespace Application.Requests;

public class ReleaseStockRequest
{
    public Guid VariantId { get; set; }

    public int Quantity { get; set; }
}
