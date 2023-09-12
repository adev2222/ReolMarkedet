using Domain.Entities.Common;

namespace Domain.Entities;

public class ShelfRenter: BaseEntity
{
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;
    
}