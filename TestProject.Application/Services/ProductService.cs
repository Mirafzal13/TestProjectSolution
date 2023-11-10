using TestProject.Application.Repositories;
using TestProject.Common.Models;
using TestProject.Domain.Entities;

namespace TestProject.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Guid AddNew(Product newProduct)
        {
            var item = new ProductEntity()
            {
                Id = Guid.NewGuid(),
                Title = newProduct.Title,
                Quantity = newProduct.Quantity,
                Price = newProduct.Price
            };

            _productRepository.Create(item);

            return item.Id;
        }

        public bool Delete(Guid id)
        {
            _productRepository.Delete(id);
            return true;
        }

        public List<Product> GetAll()
        {
            var products = _productRepository.GetAll();
            var result = new List<Product>();

            foreach (var product in products)
            {
                var item = new Product()
                {
                    Id = product.Id,
                    Title = product.Title,
                    Quantity = product.Quantity,
                    Price = product.Price
                };
                result.Add(item);
            }

            return result;
        }

        public Product GetById(Guid id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                return null;

            var result = new Product()
            {
                Id = product.Id,
                Title = product.Title,
                Quantity = product.Quantity,
                Price = product.Price
            };
            return result;
        }

        public bool Update(Product product)
        {
            var item = new ProductEntity()
            {
                Id = product.Id,
                Title = product.Title,
                Quantity = product.Quantity,
                Price = product.Price
            };
            _productRepository.Update(item);
            return true;
        }
    }
}
