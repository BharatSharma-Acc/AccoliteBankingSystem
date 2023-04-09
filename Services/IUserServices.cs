using accolite_bank_application.Models;
using accolite_bank_application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accolite_bank_application.Services
{
    public  interface IUserServices
    {
        public Task<UserModel> GetUser(int userID);
        
        public Task<UserModel> CreateUser(string userName);
        
    }
}
