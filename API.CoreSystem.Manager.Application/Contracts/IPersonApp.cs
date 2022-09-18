using API.CoreSystem.Manager.Domain.DTO;

namespace API.CoreSystem.Manager.Application.Contracts
{
    public interface IPersonApp
    {
        Task<Person> GetAsync(int id);
        Task<IEnumerable<Person>> GetAllAsync();
    }
}
