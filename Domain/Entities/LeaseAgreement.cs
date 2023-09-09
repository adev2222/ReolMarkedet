using Domain.Entities.Common;

namespace Domain.Entities;

public class LeaseAgreement: BaseEntity
{
    public DateTime StartDate { get; set; }

    public int RentDuration { get; set; }

    public bool IsPayed { get; set; } = false;

    public Shelf Shelf { get; set; }
    public int ShelfId { get; set; }

    public ShelfRenter ShelfRenter { get; set; }
    public int RenterId { get; set; }
    
    
}