using AutoMapper;
using accolite_bank_application.Models;
using accolite_bank_application.Entities;
using accolite_bank_application.Constants;

namespace accolite_bank_application.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserModel, User>()
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(x => x.userName, opt => opt.MapFrom(x => x.userName));

            CreateMap<User, UserModel>()
                .ForMember(x => x.DateCreated, opt => opt.MapFrom(x => x.DateCreated))
                .ForMember(x => x.userName, opt => opt.MapFrom(x => x.userName))
                .ForMember(x => x.userID, opt => opt.MapFrom(x => x.Id));

            CreateMap<AccountModel, Account>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(x => x.accountType, opt => opt.MapFrom(x => "Saving"))
                .ForMember(x => x.userId, opt => opt.MapFrom(x=> x.userId))
                .ForMember(x => x.balance, opt => opt.MapFrom(x => 0));

            CreateMap<Account, AccountModel>()
                .ForMember(x => x.CreatedDate, opt => opt.MapFrom(x => x.CreatedDate))
                .ForMember(x => x.accountType, opt => opt.MapFrom(x => x.accountType))
                .ForMember(x => x.balance, opt => opt.MapFrom(x => x.balance))
                .ForMember(x => x.userId, opt => opt.MapFrom(x => x.userId))
                .ForMember(x => x.accountId, opt => opt.MapFrom(x => x.accountId));
//                .ForMember(x => x.message, opt => opt.MapFrom(x => x.message));
        }

    }
}
