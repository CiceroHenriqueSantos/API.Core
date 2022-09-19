using API.CoreSystem.Manager.Application.Contracts;
using API.CoreSystem.Manager.Domain.API;
using API.CoreSystem.Manager.Domain.DTO;
using API.CoreSystem.Manager.Domain.ViewModel;
using API.CoreSystem.Manager.Services.Contracts;

namespace API.CoreSystem.Manager.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonApp personApp;
        private readonly INotificationService notificationService;

        public PersonService(IPersonApp personApp, INotificationService notificationService)
        {
            this.personApp = personApp;
            this.notificationService = notificationService;
        }

        public async Task<Person> AddAsync(AddPerson vm)
        {
            var person = await personApp.GetByFederalIdAsync(vm.FederalId);
            if (person != null)
            {
                notificationService.Notification.Errors.Add("CPF já cadastrado");
                return null;
            }

            return await personApp.AddAsync(vm);
        }

        public async Task DeleteAsync(int id)
        {
            await personApp.DeleteAsync(id);
        }

        public async Task<PagedResult<Person>> GetAllPersons(int page, int pageSize)
        {
            return await personApp.GetAllPersons(page, pageSize);
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
