using API.CoreSystem.Manager.Domain.DTO;
using API.CoreSystem.Manager.Domain.ViewModel;

namespace API.CoreSystem.Manager.Application.Contracts
{
    public interface IPersonApp
    {
        Task<Person> GetAsync(int id);
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person> AddAsync(AddPerson vm);
        Task UpdateAsync(UpPerson dto);
        Task DeleteAsync(int id);
    }
}
