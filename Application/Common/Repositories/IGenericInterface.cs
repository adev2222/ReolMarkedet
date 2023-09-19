using Domain.Entities.Common;

namespace Application.Common.Repositories;

public interface IGenericInterface<T> where T : class
{
    Task<IReadOnlyList<T>> GetAsync();
    Task<T?> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    
    Task DeleteAsync(T entity);
}