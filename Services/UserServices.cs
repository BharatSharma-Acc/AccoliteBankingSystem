using AutoMapper;
using accolite_bank_application.Models;
using accolite_bank_application.Entities;
using accolite_bank_application.Repositories;
using System.Security.Principal;

namespace accolite_bank_application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<UserModel> CreateUser(string userName)
        {
            UserModel user = new UserModel();
            user.userName = userName;
            var entity = _mapper.Map<User>(user);
            var userEntity = await _userRepository.CreateUser(entity);
            var result = _mapper.Map<UserModel>(userEntity);
            return result;
        }


        public async Task<UserModel> GetUser(int userID)
        {
            var user = await _userRepository.GetUser(userID);
            if (user == null) {
                return null;
            }
            var result = _mapper.Map<UserModel>(user);
            return result;
        }


    }
}