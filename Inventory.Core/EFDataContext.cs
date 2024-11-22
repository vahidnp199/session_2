using Inventory.Core.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDD.Infrastructure.Persistence
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

    public class PersonMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> _)
        {
            _.ToTable("Products");
            _.Property(_ => _.Logo).IsRequired();
        }
    }
}
