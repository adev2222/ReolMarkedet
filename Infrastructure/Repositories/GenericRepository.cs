using Application.Common.Repositories;
using Domain.Entities.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T> : IGenericInterface<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
   
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}