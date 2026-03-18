using Application.Responses;

namespace Application.Contracts;

public interface ICommonService
{
    Task<List<GetCategoryListResponse>> GetCategories(string? filterKeyword);
}
