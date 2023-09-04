using Application.Common.Repositories;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ShelfRepository: GenericRepository<Shelf>, IShelfRepository
{
    public ShelfRepository(ApplicationDbContext context) : base(context)
    {
    }
}