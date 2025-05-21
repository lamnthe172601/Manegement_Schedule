using AutoMapper;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Mappings
{
    public class ScheduleMappingProfile : Profile
    {
        public ScheduleMappingProfile()
        {
            CreateMap<Schedule, ScheduleDTO>();
            CreateMap<CreateScheduleDTO, Schedule>();
            CreateMap<UpdateScheduleDTO, Schedule>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}