using API.CoreSystem.Manager.Domain.Entities;
using API.CoreSystem.Manager.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.CoreSystem.Manager.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        private readonly CoreSystemContext _context;

        public Repository(CoreSystemContext context)
        {
            _context = context;
        }

        public virtual async Task<T> AddAsync(T entity, bool saveChanges = true)
        {
            var r = await _context.Set<T>().AddAsync(entity);
            if (saveChanges)
                await _context.SaveChangesAsync();
            return r.Entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity, bool saveChanges = true)
        {
            _context.Set<T>().Update(entity);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }
    }
}
