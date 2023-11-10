using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestProject.Application.Abstraction.DbContext;
using TestProject.Domain.Entities;

namespace TestProject.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductAuditEntity>  ProductAudits { get; set; }

        public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        {

            var entry = base.Entry(entity);


            return entry;
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}
