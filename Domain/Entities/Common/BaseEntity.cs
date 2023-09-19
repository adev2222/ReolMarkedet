using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Common;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}