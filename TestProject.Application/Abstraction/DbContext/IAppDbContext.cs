using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestProject.Domain.Entities;

namespace TestProject.Application.Abstraction.DbContext
{
    public interface IAppDbContext
    {
        DbSet<AccountEntity> Accounts { get; set; }
        DbSet<ProductEntity> Products { get; set; }
        DbSet<ProductAuditEntity> ProductAudits { get; set; }
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}
