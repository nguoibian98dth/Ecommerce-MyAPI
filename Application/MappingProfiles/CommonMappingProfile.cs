using Application.Responses;
using Mapster;

namespace Application.MappingProfiles;

internal class CommonMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Entities.Category, GetCategoryListResponse>()
            .Map(dest => dest.Value, src => src.Id)
            .Map(dest => dest.Label, src => src.Name)
            ;
    }
}
