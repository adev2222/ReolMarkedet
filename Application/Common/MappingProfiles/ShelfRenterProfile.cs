using Application.ShelfRenter.Queries;
using Application.ShelfRenter.Queries.GetShelfRenterById;
using AutoMapper;

namespace Application.Common.MappingProfiles;

public class ShelfRenterProfile: Profile
{
    public ShelfRenterProfile()
    {
        CreateMap<Domain.Entities.ShelfRenter, ShelfRenterByIdDto>();
        CreateMap<Domain.Entities.ShelfRenter, ShelfRentersListDto>();
    }
}