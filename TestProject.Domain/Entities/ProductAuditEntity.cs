using TestProject.Common.Enums;
using TestProject.Domain.Entities.Base;

namespace TestProject.Domain.Entities
{
    public class ProductAuditEntity : BaseEntity
    {
        public Guid AccountId { get; set; }
        public AccountEntity Account { get; set; }

        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }

        public AccessType AccessType { get; set; }
    }
}
