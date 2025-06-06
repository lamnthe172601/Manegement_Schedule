using AutoMapper;
using Management_Schedule_BE.DTOs;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.Helpers.Mappings
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<CreateCourseDTO, Course>()
                .ForMember(dest => dest.ThumbnailUrl, opt => opt.Ignore());
            CreateMap<UpdateCourseDTO, Course>()
                .ForMember(dest => dest.ThumbnailUrl, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}