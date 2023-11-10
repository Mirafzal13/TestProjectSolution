using TestProject.Application.Abstraction.DbContext;
using TestProject.Domain.Entities;

namespace TestProject.Application.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IAppDbContext _context;
        public AccountRepository(IAppDbContext context)
        {
            _context = context;
        }

        public void AddNew(AccountEntity account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public AccountEntity GetByUserName(string userName)
        {
            var account = _context.Accounts.FirstOrDefault(n => n.UserName == userName);
            return account;
        }
    }
}
