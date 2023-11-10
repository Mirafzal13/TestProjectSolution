using TestProject.Common.Enums;
using TestProject.Domain.Entities.Base;

namespace TestProject.Domain.Entities
{
    public class AccountEntity : BaseEntity
    {
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; } = string.Empty;

        public AccountType AccountType { get; set; }
    }
}
