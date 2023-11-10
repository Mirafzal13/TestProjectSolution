using TestProject.Domain.Entities.Base;

namespace TestProject.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Title { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
