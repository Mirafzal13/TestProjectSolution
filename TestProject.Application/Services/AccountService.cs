using TestProject.Application.Repositories;
using TestProject.Common.Models;
using TestProject.Common.Utility;
using TestProject.Domain.Entities;

namespace TestProject.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool Register(Account account)
        {
            if(account != null)
            {
                var passwordHash = PasswordHasher.Hash(account.Password);
                var item = new AccountEntity()
                {
                    Id = passwordHash.Salt,
                    UserName = account.UserName,
                    PasswordHash = passwordHash.Hash,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    AccountType = account.AccountType
                };

                _accountRepository.AddNew(item);
                return true;
            }
            return false;
        }

        public Account GetByUserName(string userName, string password)
        {
            var account = _accountRepository.GetByUserName(userName);
            if (account == null || !PasswordHasher.Verify(password, account.PasswordHash, account.Id))
                return null;
            var result = new Account()
            {
                Id = account.Id,
                UserName = account.UserName,
                FirstName = account.FirstName,
                LastName = account.LastName
            };

            return result;
        }
    }
}
