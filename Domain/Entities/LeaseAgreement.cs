using Domain.Entities.Common;

namespace Domain.Entities;

public class LeaseAgreement: BaseEntity
{

    public DateTime StartDate { get; set; }

    public int RentDuration { get; set; }

    public bool IsPayed { get; set; } = false;

    public double Price { get; set; }
    
    public ShelfRenter ShelfRenter { get; set; }
    public int ShelfRenterId { get; set; }
    
    public List<ShelfLeaseAgreement> ShelfLeaseAgreements { get; set; }
    
}