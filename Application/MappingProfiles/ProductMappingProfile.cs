using Application.Responses;
using Mapster;

namespace Application.MappingProfiles;

internal class ProductMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Entities.Product, ProductListResponse>()
            .Map(dest => dest.ImageUrl, src => src.ProductImages.FirstOrDefault(x => x.IsPrimary).Url)
            .Map(dest => dest.FromPrice, src => src.Variants.Min(x => x.Price))
            .Map(dest => dest.ToPrice, src => src.Variants.Max(x => x.Price))
            ;

        config.NewConfig<Domain.Entities.Product, ProductDetailResponse>()
            .Map(dest => dest.ImageUrl, src => src.ProductImages.FirstOrDefault(x => x.IsPrimary).Url)
            ;
        config.NewConfig<Domain.Entities.ProductVariant, ProductVariantDto>()
            ;
    }
}
