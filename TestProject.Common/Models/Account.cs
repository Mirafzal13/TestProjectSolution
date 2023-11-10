using TestProject.Common.Enums;

namespace TestProject.Common.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AccountType AccountType { get; set; }
    }
}
