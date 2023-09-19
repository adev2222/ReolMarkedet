using Domain.Entities;

namespace Application.Common.Repositories;

public interface IShelfRepository: IGenericInterface<Domain.Entities.Shelf>
{
    Task<Domain.Entities.Shelf> GetByDateTime(DateTime dateTime);
}