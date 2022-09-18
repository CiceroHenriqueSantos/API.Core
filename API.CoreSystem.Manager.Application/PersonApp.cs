using API.CoreSystem.Manager.Application.Contracts;
using API.CoreSystem.Manager.Domain.DTO;
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

        public async Task<Person> GetAsync(int id)
        {
           var data = await personRepository.GetAsync(id);
            return mapper.Map<Person>(data);
        }
    }
}
