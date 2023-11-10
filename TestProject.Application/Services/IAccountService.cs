using TestProject.Common.Models;

namespace TestProject.Application.Services
{
    public interface IAccountService
    {
        Account GetByUserName(string userName, string passwordHash);

        bool Register(Account account);
    }
}
