using Application.Common.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ShelfRenterRepository : GenericRepository<ShelfRenter>, IShelfRenterRepository
{
    public ShelfRenterRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<ShelfRenter> FindByEmailOrCreate(string email)
    {
        var shelfRenter = await _context.Set<ShelfRenter>()
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Email.Equals(email));

        if (shelfRenter != null)
        {
            return shelfRenter;
        }
        

        shelfRenter = new ShelfRenter
        {
            Email = email,
        };

        await _context.AddAsync(shelfRenter);
        await _context.SaveChangesAsync(); // Use SaveChangesAsync to persist changes

        return shelfRenter;

    }
}

