using AutoMapper;
using Domain.Enums;

namespace Application.Shelf.Queries.GetShelfList;

public class ShelvesDto
{
    public string Location { get; set; } = string.Empty;
    public ShelfType ShelfType { get; set; }


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ShelvesDto, Domain.Entities.Shelf>();
        }
    }
}