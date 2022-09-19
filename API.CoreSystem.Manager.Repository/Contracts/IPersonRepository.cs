using API.CoreSystem.Manager.Domain.API;
using API.CoreSystem.Manager.Domain.Entities;

namespace API.CoreSystem.Manager.Repository.Contracts
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetAsync(int id);
        Task<Person> GetByFederalIdAsync(string federalId);
        Task<PagedResult<Person>> GetAllPersons(int page, int pageSize);
    }
}
