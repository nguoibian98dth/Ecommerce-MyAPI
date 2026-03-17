using Application.Contracts;
using Application.Requests;
using Domain.Entities;
using Domain.Entities.Repository;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;

internal class InventoryService(

    IBaseRepository<Inventory, Guid> inventoryRepository,

    IUnitOfWork unitOfWork

    ) : IInventoryService
{
    public async Task ReserveAsync(ReserveStockRequest request)
    {
        await unitOfWork.BeginTransactionAsync();

        try
        {
            var inventory = await inventoryRepository.AsQuery()
                .FirstOrDefaultAsync(x => x.VariantId == request.VariantId);

            if (inventory is null)
                throw new Exception("Inventory not found");

            // Domain logic
            inventory.Reserve(request.Quantity);

            inventoryRepository.Update(inventory);

            await unitOfWork.CommitAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            await unitOfWork.RollbackAsync();
            throw new Exception("Concurrency conflict - retry");
        }
        catch
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task ReleaseAsync(ReleaseStockRequest request)
    {
        var inventory = await inventoryRepository.AsQuery()
            .FirstOrDefaultAsync(x => x.VariantId == request.VariantId);

        if (inventory == null)
            throw new Exception("Inventory not found");

        inventory.Release(request.Quantity);

        inventoryRepository.Update(inventory);

        await unitOfWork.SaveChangesAsync();
    }

    public async Task AdjustStockAsync(AdjustStockRequest request)
    {
        var inventory = await inventoryRepository.AsQuery()
            .FirstOrDefaultAsync(x => x.VariantId == request.VariantId);

        if (inventory is null)
            throw new Exception("Inventory not found");

        inventory.Adjust(request.Quantity);

        inventoryRepository.Update(inventory);
        await unitOfWork.SaveChangesAsync();
    }
}
