using API.CoreSystem.Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.CoreSystem.Manager.Repository.Mapping
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", "Manager");
            builder.HasKey(p => p.Id)
                .HasName("PK_Person");

            builder.Property(p => p.Id)
                .HasColumnType("INT")
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnType("VARCHAR(150)")
                .IsRequired();

            builder.Property(p => p.LastName)
               .HasColumnType("VARCHAR(150)")
               .IsRequired();

            builder.Property(p => p.Nationality)
               .HasColumnType("VARCHAR(100)")
               .IsRequired();

            builder.Property(p => p.ZipCode)
               .HasColumnType("VARCHAR(10)")
               .IsRequired();

            builder.Property(p => p.State)
               .HasColumnType("VARCHAR(100)")
               .IsRequired();

            builder.Property(p => p.City)
               .HasColumnType("VARCHAR(150)")
               .IsRequired();

            builder.Property(p => p.Address)
              .HasColumnType("VARCHAR(200)")
              .IsRequired();

            builder.Property(p => p.Email)
              .HasColumnType("VARCHAR(100)")
              .IsRequired();

            builder.Property(p => p.Phone)
              .HasColumnType("VARCHAR(100)")
              .IsRequired();

            builder.Property(p => p.CreateDate)
              .HasDefaultValueSql("GETUTCDATE()")
              .IsRequired();

            builder.Property(p => p.LastUpdatedOn).IsRequired(false);
            builder.Property(p => p.Deleted).IsRequired(true).HasDefaultValue(false);
        }
    }
}
