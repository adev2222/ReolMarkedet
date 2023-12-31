using Domain.Entities.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Shelf: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public ShelfType ShelfType { get; set; } = ShelfType.withoutGLasses;
    
    public DateTime? BookingEndDate { get; set; }

    public List<ShelfLeaseAgreement> ShelfLeaseAgreements { get; set; }

}