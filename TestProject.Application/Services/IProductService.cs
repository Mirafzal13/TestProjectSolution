using TestProject.Common.Models;

namespace TestProject.Application.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(Guid id);
        Guid AddNew(Product newProduct);
        bool Update(Product product);
        bool Delete(Guid id);
    }
}
