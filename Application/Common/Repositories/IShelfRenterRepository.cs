using Domain.Entities;

namespace Application.Common.Repositories;

public interface IShelfRenterRepository: IGenericInterface<Domain.Entities.ShelfRenter>
{
    Task<Domain.Entities.ShelfRenter> FindByEmailOrCreate(string email);
}