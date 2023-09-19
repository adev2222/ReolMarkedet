
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;
[PrimaryKey(nameof(LeaseAgreementId), nameof(ShelfId))]
public class ShelfLeaseAgreement
{

    public int LeaseAgreementId { get; set; }
    public int ShelfId { get; set; }
    public LeaseAgreement LeaseAgreement { get; set; } = null;
    public Shelf Shelf { get; set; } = null;
}