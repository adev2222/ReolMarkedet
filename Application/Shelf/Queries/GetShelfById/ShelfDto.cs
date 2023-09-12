using Application.Shelf.Queries.GetShelfList;
using AutoMapper;
using Domain.Enums;

namespace Application.Shelf.Queries.GetShelfById;

public class ShelfDto
{
    public string Location { get; set; } = string.Empty;
    public ShelfType ShelfType { get; set; } = ShelfType.withoutGLasses;
}