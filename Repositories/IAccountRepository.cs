using accolite_bank_application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accolite_bank_application.Repositories
{
    public interface IAccountRepository
    {
        public Task<Account> GetAccount(int accountId);
        public Task<IEnumerable<Account>> GetAccounts(int userID);
        public Task<Account> CreateAccount(Account account);
        public Task<bool> DeleteAccount(int accountId);
        public Task<Account> UpdateAccount(Account account);



    }
}
