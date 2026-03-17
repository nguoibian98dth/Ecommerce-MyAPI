namespace Application.Requests;

public class AdjustStockRequest
{
    public Guid VariantId { get; set; }

    public int Quantity { get; set; }
}
