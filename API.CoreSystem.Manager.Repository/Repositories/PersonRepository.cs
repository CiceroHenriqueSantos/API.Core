using API.CoreSystem.Manager.Domain.Entities;
using API.CoreSystem.Manager.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.CoreSystem.Manager.Repository.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly CoreSystemContext context;

        public PersonRepository(CoreSystemContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Person> GetAsync(int id)
        {
            var data = await context.Persons.Where(p => p.Id == id)
                                            .FirstOrDefaultAsync();
            return data;
        }
    }
}
