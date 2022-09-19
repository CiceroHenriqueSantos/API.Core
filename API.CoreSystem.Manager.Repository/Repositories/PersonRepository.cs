using API.CoreSystem.Manager.Domain.API;
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

        public async Task<PagedResult<Person>> GetAllPersons(int page, int pageSize)
        {
            var query = context.Persons.Where(p => !p.Deleted)
                                             .AsQueryable();

            var count = query.Count();
            var data = await query.Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();

            return new PagedResult<Person>(count, page, pageSize, data);
        }

        public async Task<Person> GetAsync(int id)
        {
            var data = await context.Persons.Where(p => p.Id == id && !p.Deleted)
                                            .FirstOrDefaultAsync();
            return data;
        }

        public async Task<Person> GetByFederalIdAsync(string federalId)
        {
            var data = await context.Persons.Where(p => p.FederalId == federalId && !p.Deleted)
                                           .FirstOrDefaultAsync();
            return data;
        }
    }
}
