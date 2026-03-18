using Application.Contracts;
using Application.Responses;
using Domain.Entities;
using Domain.Entities.Repository;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;

internal class CommonService(
    IBaseRepository<Category, Guid> categoryRepository
    ) : ICommonService
{
    public async Task<List<GetCategoryListResponse>> GetCategories(string? filterKeyword)
    {
        var items = await categoryRepository.AsQuery()
            .Where(x => string.IsNullOrWhiteSpace(filterKeyword) || x.Name.Contains(filterKeyword))
            .ProjectToType<GetCategoryListResponse>()
            .ToListAsync();

        return items;
    }
}
