using API.CoreSystem.Manager.Application.Contracts;
using API.CoreSystem.Manager.Domain.API;
using API.CoreSystem.Manager.Domain.DTO;
using API.CoreSystem.Manager.Domain.ViewModel;
using API.CoreSystem.Manager.Repository.Contracts;
using AutoMapper;

namespace API.CoreSystem.Manager.Application
{
    public class PersonApp : IPersonApp
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonApp(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<Person> AddAsync(AddPerson vm)
        {
            var entity = mapper.Map<Domain.Entities.Person>(vm);
            entity = await personRepository.AddAsync(entity);

            return mapper.Map<Person>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var person = await personRepository.GetAsync(id);
            if (person != null)
            {
                person.Deleted = true;
                await personRepository.UpdateAsync(person);
            }
        }

        public async Task<PagedResult<Person>> GetAllPersons(int page, int pageSize)
        {
            var data = await personRepository.GetAllPersons(page, pageSize);

            if (data.Data?.Count == 0)
                return data.As(new List<Person>());

            var purchasedata = mapper.Map<List<Person>>(data.Data);
            return data.As(purchasedata);
        }

        public async Task<Person> GetAsync(int id)
        {
            var data = await personRepository.GetAsync(id);
            return mapper.Map<Person>(data);
        }

        public async Task<Person> GetByFederalIdAsync(string federalId)
        {
            var data = await personRepository.GetByFederalIdAsync(federalId);
            return mapper.Map<Person>(data);
        }

        public async Task UpdateAsync(UpPerson dto)
        {
            var data = await personRepository.GetAsync(dto.Id);
            if (data == null)
                return;

            var entity = mapper.Map(dto, data);
            await personRepository.UpdateAsync(entity);
        }
    }
}
