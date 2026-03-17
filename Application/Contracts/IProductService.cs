using Application.Requests;
using Application.Responses;
using Application.Shared;

namespace Application.Contracts;

public interface IProductService
{
    Task<Guid> CreateAsync(CreateProductRequest request);

    Task<ProductDetailResponse> GetByIdAsync(Guid id);

    Task<PagingDataResponse<ProductListResponse>> GetListAsync(ProductListRequest query);

    Task UpdateAsync(Guid id, UpdateProductRequest request);

    Task DeleteAsync(Guid id);
}
