using API.CoreSystem.Manager.Domain.DTO;

namespace API.CoreSystem.Manager.Services.Contracts
{
    public interface IPersonService
    {
        Task<Person> GetAsync(int id);
        Task<IEnumerable<Person>> GetAllAsync();
    }
}
