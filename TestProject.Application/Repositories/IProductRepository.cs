using TestProject.Domain.Entities;

namespace TestProject.Application.Repositories
{
    public interface IProductRepository
    {
        List<ProductEntity> GetAll();
        ProductEntity GetById(Guid id);
        void Update(ProductEntity product);
        void Create(ProductEntity product);
        void Delete(Guid id);
    }
}
