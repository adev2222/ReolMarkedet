using Domain.Entities.Common;

namespace Domain.Entities;

public class Contract: BaseEntity
{
    public DateTime StartDate { get; set; }

    public int RentDuration { get; set; }

    public bool IsPayed { get; set; } = false;

    public Shelf Shelf { get; set; }
    public int ShelfId { get; set; }

    public Renter Renter { get; set; }
    public int RenterId { get; set; }
    
    
}