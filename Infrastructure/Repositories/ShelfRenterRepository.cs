using Application.Common.Repositories;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ShelfRenterRepository: GenericRepository<ShelfRenter>, IShelfRenterRepository
{
    public ShelfRenterRepository(ApplicationDbContext context) : base(context)
    {
    }
}