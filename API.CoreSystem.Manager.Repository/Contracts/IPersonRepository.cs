using API.CoreSystem.Manager.Domain.Entities;

namespace API.CoreSystem.Manager.Repository.Contracts
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetAsync(int id);
    }
}
