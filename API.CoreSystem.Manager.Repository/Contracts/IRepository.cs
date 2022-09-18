using API.CoreSystem.Manager.Domain.Entities;

namespace API.CoreSystem.Manager.Repository.Contracts
{
    public interface IRepository<T> where T : Base
    {
        Task<T> AddAsync(T entity, bool saveChanges = true);
        Task UpdateAsync(T entity, bool saveChanges = true);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
