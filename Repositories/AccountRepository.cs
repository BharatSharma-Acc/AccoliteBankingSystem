using accolite_bank_application.DBContext;
using accolite_bank_application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace accolite_bank_application.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankDBContext _dBContext;

        public AccountRepository()
        {
        }

        public AccountRepository(BankDBContext dBContext)
        {
            _dBContext = dBContext;
            if (!_dBContext.Accounts.Any())
            {
                List<Account> accounts = new List<Account>() {
                new Account() {
                    accountId = 50000,
                    accountType = "Saving",
                    balance = 100,
                    userId = 10000,
                    CreatedDate = DateTime.Now
                },
                new Account() {
                    accountId = 50001,
                    accountType = "Saving",
                    balance = 100,
                    userId = 10000,
                    CreatedDate = DateTime.Now
                }
                };
                dBContext.Accounts.AddRangeAsync(accounts);
                dBContext.SaveChangesAsync();
            }
        }

        public async Task<Account> CreateAccount(Account account)
        {
            
            await _dBContext.Accounts.AddAsync(account);
            await _dBContext.SaveChangesAsync();
            Console.WriteLine(account);
            return account;
        }

        public async Task<bool> DeleteAccount(int accountId)
        {
            var account = await _dBContext.Accounts.Where(x => x.accountId == accountId).FirstOrDefaultAsync();
            if (account != null)
            {
                _dBContext.Accounts.Remove(account);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Account> GetAccount(int accountId)
        {
            if (string.IsNullOrEmpty(accountId.ToString()))
            {
                return new Account();
            }
            var account = await _dBContext.Accounts.Where(x => x.accountId == accountId).FirstOrDefaultAsync();
            if (account != null)
            {
                return account;
            }
            return null;
        }

        public async Task<IEnumerable<Account>> GetAccounts(int userID)
        {
            var accounts = await _dBContext.Accounts.Where(x => x.userId == userID).ToListAsync();
            return accounts;
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            account.LastUpdatedDate = DateTime.Now;
            _dBContext.Accounts.Update(account);
            await _dBContext.SaveChangesAsync();
            return account;
        }
    }
}