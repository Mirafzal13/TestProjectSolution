using Microsoft.EntityFrameworkCore;
using TestProject.Application.Abstraction.DbContext;
using TestProject.Domain.Entities;

namespace TestProject.Application.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IAppDbContext _context;
        public ProductRepository(IAppDbContext context)
        {
            _context = context;
        }
        public void Create(ProductEntity product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = _context.Products.FirstOrDefault(n => n.Id == id);
            _context.Entry(product).State = EntityState.Deleted;

            _context.SaveChanges();
        }

        public List<ProductEntity> GetAll()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public ProductEntity GetById(Guid id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public void Update(ProductEntity product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
