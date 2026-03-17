using Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts;

public interface IInventoryService
{
    Task ReserveAsync(ReserveStockRequest request);

    Task ReleaseAsync(ReleaseStockRequest request);

    Task AdjustStockAsync(AdjustStockRequest request);
}
