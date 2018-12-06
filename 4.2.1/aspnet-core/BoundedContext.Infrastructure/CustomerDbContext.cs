using Abp.EntityFrameworkCore;
using BoundedContext.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace BoundedContext.Infrastructure
{
    public class CustomerDbContext : AbpDbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : 
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().OwnsOne(x => x.Name, e =>
            {
                e.Property("StringValue").HasColumnName("Name")
                    .IsUnicode(true).IsRequired();
                e.Ignore("CurrentCultureText");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
