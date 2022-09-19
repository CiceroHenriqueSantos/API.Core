using API.CoreSystem.Manager.Application.Contracts;
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

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            var data = await personRepository.GetAllAsync();
            if (data == null)
                return Enumerable.Empty<Person>();

            var result = data.Where(x => !x.Deleted);
            return mapper.Map<IEnumerable<Person>>(result);
        }

        public async Task<Person> GetAsync(int id)
        {
            var data = await personRepository.GetAsync(id);
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
