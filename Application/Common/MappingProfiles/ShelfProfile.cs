using Application.Shelf.Commands.CreateShelf;
using Application.Shelf.Commands.UpdateShelf;
using Application.Shelf.Queries.GetShelfById;
using Application.Shelf.Queries.GetShelfList;
using AutoMapper;

namespace Application.Common.MappingProfiles;

public class ShelfProfile: Profile
{
    public ShelfProfile()
    {
        CreateMap<ShelfDto, Domain.Entities.Shelf>().ReverseMap();
        CreateMap<Domain.Entities.Shelf, ShelvesDto>();
        CreateMap<CreateShelfCommand, Domain.Entities.Shelf>();
        CreateMap<UpdateShelfCommand, Domain.Entities.Shelf>();
    }
}