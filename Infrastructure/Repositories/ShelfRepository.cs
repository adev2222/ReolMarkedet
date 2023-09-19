using Application.Common.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ShelfRepository: GenericRepository<Shelf>, IShelfRepository
{
    public ShelfRepository(ApplicationDbContext context) : base(context)
    {
        
    }
    
    public async Task<Shelf?> GetByDateTime(DateTime dateTime)
    {
        return await _context.Set<Shelf>()
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.BookingEndDate == null || q.BookingEndDate <= dateTime);
    }
}