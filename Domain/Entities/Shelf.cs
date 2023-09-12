using Domain.Entities.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Shelf: BaseEntity
{
    public string Location { get; set; } = string.Empty;
    public ShelfType ShelfType { get; set; } = ShelfType.withoutGLasses;

    public List<LeaseAgreement>? LeaseAgreements { get; set; } = new();
}