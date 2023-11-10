using TestProject.Domain.Entities;

namespace TestProject.Application.Repositories
{
    public interface IAccountRepository
    {
        AccountEntity GetByUserName(string userName);

        void AddNew(AccountEntity account);
    }
}
