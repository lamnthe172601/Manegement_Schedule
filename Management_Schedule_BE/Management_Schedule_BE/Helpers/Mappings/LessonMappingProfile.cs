using AutoMapper;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Mappings
{
    public class LessonMappingProfile : Profile
    {
        public LessonMappingProfile()
        {
            CreateMap<Lesson, LessonDTO>();
            CreateMap<CreateLessonDTO, Lesson>();
            CreateMap<UpdateLessonDTO, Lesson>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}