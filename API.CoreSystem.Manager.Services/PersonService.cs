using API.CoreSystem.Manager.Application.Contracts;
using API.CoreSystem.Manager.Domain.DTO;
using API.CoreSystem.Manager.Domain.ViewModel;
using API.CoreSystem.Manager.Services.Contracts;

namespace API.CoreSystem.Manager.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonApp personApp;

        public PersonService(IPersonApp personApp)
        {
            this.personApp = personApp;
        }

        public async Task<Person> AddAsync(AddPerson vm)
        {
            return await personApp.AddAsync(vm);
        }

        public async Task DeleteAsync(int id)
        {
            await personApp.DeleteAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await personApp.GetAllAsync();
        }

        public async Task<Person> GetAsync(int id)
        {
            return await personApp.GetAsync(id);
        }

        public async Task UpdateAsync(UpPerson dto)
        {
            await personApp.UpdateAsync(dto);
        }
    }
}
