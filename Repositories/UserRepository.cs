using accolite_bank_application.DBContext;
using accolite_bank_application.Entities;
using Microsoft.EntityFrameworkCore;


namespace accolite_bank_application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankDBContext _dBContext;

        public UserRepository()
        {
        }

        public UserRepository(BankDBContext dBContext)
        {
            _dBContext = dBContext;
            if (!_dBContext.Users.Any())
            {
                List<User> users = new List<User>() {
                new User() {
                    Id = 10000,
                    userName = "Tester1",
                    DateCreated = DateTime.Now
                    //accounts = new LinkedList<int>(){}
                },
                new User() {
                    Id = 10001,
                    userName = "Tester2",
                    DateCreated = DateTime.Now
                    //accounts = new LinkedList<int>(){}
                }
                };
                dBContext.Users.AddRangeAsync(users);
                dBContext.SaveChangesAsync();
            }
        }

        public async Task<User> CreateUser(User user)
        {
            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();
            Console.WriteLine(user);
            return user;
        }


        public async Task<User> GetUser(int userID)
        {

            if (string.IsNullOrEmpty(userID.ToString()))
            {
                return new User();
            }
            var user = await _dBContext.Users.Where(x => x.Id == userID).FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            return null;
        }





    }
}