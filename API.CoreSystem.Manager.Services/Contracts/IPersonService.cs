using API.CoreSystem.Manager.Domain.API;
using API.CoreSystem.Manager.Domain.DTO;
using API.CoreSystem.Manager.Domain.ViewModel;

namespace API.CoreSystem.Manager.Services.Contracts
{
    public interface IPersonService
    {
        Task<Person> GetAsync(int id);
        Task<PagedResult<Person>> GetAllPersons(int page, int pageSize);
        Task<Person> AddAsync(AddPerson vm);
        Task UpdateAsync(UpPerson dto);
        Task DeleteAsync(int id);
    }
}
