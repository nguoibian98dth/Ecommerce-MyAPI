using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Application.Requests;

public class ReserveStockRequest
{
    public Guid VariantId { get; set; }

    public int Quantity { get; set; }
}
