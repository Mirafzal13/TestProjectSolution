using System.ComponentModel.DataAnnotations;

namespace TestProject.Domain.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
