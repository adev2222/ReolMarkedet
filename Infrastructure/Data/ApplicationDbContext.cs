using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<Renter> Renters { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    
    
}