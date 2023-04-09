using accolite_bank_application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accolite_bank_application.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetUser(int userID);

        public Task<User> CreateUser(User user);

    }
}
