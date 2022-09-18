using API.CoreSystem.Manager.Domain.Entities;
using API.CoreSystem.Manager.Repository.Mapping;
using Microsoft.EntityFrameworkCore;

namespace API.CoreSystem.Manager.Repository
{
    public class CoreSystemContext : DbContext
    {
        public CoreSystemContext(DbContextOptions<CoreSystemContext> options)
      : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Person> Persons { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    var property = entityEntry.Properties.FirstOrDefault(p => p.Metadata.Name == "CreateDate");
                    if (property != null)
                        entityEntry.Property("CreateDate").CurrentValue = DateTimeOffset.UtcNow;
                    property = entityEntry.Properties.FirstOrDefault(p => p.Metadata.Name == "Deleted");
                    if (property != null)
                        entityEntry.Property("Deleted").CurrentValue = false;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    var property = entityEntry.Properties.FirstOrDefault(p => p.Metadata.Name == "LastUpdatedOn");
                    if (property != null)
                        entityEntry.Property("LastUpdatedOn").CurrentValue = DateTimeOffset.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
