using accolite_bank_application.Models;
using accolite_bank_application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accolite_bank_application.Services
{
    public  interface IAccountServices
    {
        public Task<AccountModel> GetAccount(int accountId);
        public Task<IEnumerable<AccountModel>> GetAccounts(int userID);
        public Task<AccountModel> CreateAccount(int userID);
        public Task<bool> DeleteAccount(int accountId);
        public Task<TransactionModel> UpdateAccount(int accountId, decimal amount, string transType);

    }
}
