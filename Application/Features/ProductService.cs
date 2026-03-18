using Application.Contracts;
using Application.Requests;
using Application.Responses;
using Application.Shared;
using Domain.Entities;
using Domain.Entities.Repository;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Domain.Exceptions;

namespace Application.Features;

internal class ProductService(

    IBaseRepository<Product, Guid> productRepository,

    IUnitOfWork unitOfWork

    ) : IProductService
{
    public async Task<Guid> CreateAsync(CreateProductRequest request)
    {
        await unitOfWork.BeginTransactionAsync();

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            CategoryId = request.CategoryId,
            CreatedAt = DateTime.UtcNow,
            Variants = new List<ProductVariant>()
        };

        foreach (var v in request.Variants)
        {
            var variantId = Guid.NewGuid();
            var variant = new ProductVariant
            {
                Id = variantId,
                SKU = v.SKU,
                Price = v.Price,
                Attributes = JsonSerializer.Serialize(v.Attributes),
                CreatedAt = DateTime.UtcNow,

                Inventory = new Inventory(variantId, v.InitialStock)
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow
                }
            };

            product.Variants.Add(variant);
        }

        await productRepository.AddAsync(product);

        await unitOfWork.CommitAsync();

        return product.Id;
    }

    public async Task<ProductDetailResponse> GetByIdAsync(Guid id)
    {
        var product = await productRepository.AsQuery(true)
            .Include(p => p.ProductImages)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
            throw new NotFoundException("Product not found");

        return product.Adapt<ProductDetailResponse>();
    }

    public async Task<PagingDataResponse<ProductListResponse>> GetListAsync(ProductListRequest query)
    {
        IQueryable<Product> q = productRepository.AsQuery()
            .Include(p => p.Variants);
        
        if (!string.IsNullOrEmpty(query.FilterKeyword))
            q = q.Where(x => x.Name.Contains(query.FilterKeyword));

        if (query.CategoryId.HasValue)
            q = q.Where(x => x.CategoryId == query.CategoryId);

        var total = await q.CountAsync();

        var data = await q
            .OrderByDescending(x => x.CreatedAt)
            .ProjectToType<ProductListResponse>()
            .Skip(query.PageNumber)
            .Take(query.PageSize)
            .ToListAsync();

        return new PagingDataResponse<ProductListResponse>
        {
            TotalRecords = total,
            Data = data,
            PageNo = query.PageNo,
            PageSize = query.PageSize
        };
    }

    public async Task UpdateAsync(Guid id, UpdateProductRequest request)
    {
        var product = await productRepository.AsQuery()
            .Include(p => p.Variants)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            throw new Exception("Product not found");

        product.Name = request.Name;
        product.Description = request.Description;
        product.UpdatedAt = DateTime.UtcNow;

        //variantRepository.DeleteRange(product.Variants);

        var newVariants = new List<ProductVariant>();

        foreach (var v in request.Variants)
        {
            var variantId = Guid.NewGuid();
            var variant = new ProductVariant
            {
                Id = variantId,
                ProductId = product.Id,
                SKU = v.SKU,
                Price = v.Price,
                Attributes = JsonSerializer.Serialize(v.Attributes),
                CreatedAt = DateTime.UtcNow,

                Inventory = new Inventory(variantId, v.InitialStock)
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow
                }
            };

            newVariants.Add(variant);
        }

        product.Variants = newVariants;

        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        product.IsDeleted = true;
        product.UpdatedAt = DateTime.UtcNow;

        productRepository.Update(product);

        await unitOfWork.SaveChangesAsync();
    }

}

