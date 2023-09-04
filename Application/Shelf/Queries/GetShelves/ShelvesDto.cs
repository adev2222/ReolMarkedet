using AutoMapper;
using Domain.Enums;

namespace Application.Shelf.Queries.GetShelfList;

public class ShelvesDto
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public ShelfType ShelfType { get; set; }
}