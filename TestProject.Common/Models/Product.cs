namespace TestProject.Common.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
