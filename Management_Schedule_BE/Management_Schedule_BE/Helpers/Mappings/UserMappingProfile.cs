using AutoMapper;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserCreateDTO, User>();
            CreateMap<UserUpdateDTO, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
           
            CreateMap<TeachStudentProfile, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            
            CreateMap<User, TeachStudentProfile>();
        }
        
    }
}
