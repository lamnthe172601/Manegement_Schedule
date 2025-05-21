using AutoMapper;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Mappings
{
    public class StudySessionMappingProfile : Profile
    {
        public StudySessionMappingProfile()
        {
            CreateMap<StudySession, StudySessionDTO>();
            CreateMap<CreateStudySessionDTO, StudySession>();
            CreateMap<UpdateStudySessionDTO, StudySession>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}