using AutoMapper;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Mappings
{
    public class ClassMappingProfile : Profile
    {
        public ClassMappingProfile()
        {
            CreateMap<Class, ClassDTO>();
            CreateMap<CreateClassDTO, Class>();
            CreateMap<UpdateClassDTO, Class>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}