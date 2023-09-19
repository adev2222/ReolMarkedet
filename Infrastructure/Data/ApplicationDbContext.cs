using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<ShelfRenter> ShelfRenter { get; set; }
    public DbSet<LeaseAgreement> LeaseAgreement { get; set; }
    public DbSet<ShelfLeaseAgreement> ShelfLeaseAgreements { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add default shelves here
        for (int i = 1; i <= 100; i++)
        {
            modelBuilder.Entity<Shelf>().HasData(
                new Shelf {Id = i, Name = $"Shelf {i}" }
            );
        }

        modelBuilder.Entity<ShelfLeaseAgreement>()
            .HasOne(sl => sl.Shelf)
            .WithMany(s => s.ShelfLeaseAgreements)
            .HasForeignKey(sl => sl.ShelfId);
        modelBuilder.Entity<ShelfLeaseAgreement>()
            .HasOne(sl => sl.LeaseAgreement)
            .WithMany(s => s.ShelfLeaseAgreements)
            .HasForeignKey(sl => sl.LeaseAgreementId);
    }
}