using API.CoreSystem.Manager.Application.Contracts;
using API.CoreSystem.Manager.Domain.DTO;
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

        public Task<Person> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
