using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<ShelfRenter> Renters { get; set; }
    public DbSet<LeaseAgreements> Contracts { get; set; }
    
    
}