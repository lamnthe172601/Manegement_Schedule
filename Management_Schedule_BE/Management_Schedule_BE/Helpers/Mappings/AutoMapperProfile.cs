using AutoMapper;
using Management_Schedule_BE.Models;
using Management_Schedule_BE.DTOs.Respond;

namespace Management_Schedule_BE.Helpers.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Course
            CreateMap<Course, CourseResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CourseID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CourseName))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.IsPro ? "Pro" : "Basic"))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsSelling ? "Active" : "Inactive"))
                .ReverseMap();

            CreateMap<Course, CourseDetailResponseDTO>()
                .IncludeBase<Course, CourseResponseDTO>()
                .ForMember(dest => dest.Classes, opt => opt.MapFrom(src => src.Classes))
                .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Lessons))
                .ReverseMap();

            // Class
            CreateMap<Class, ClassResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClassID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ClassName))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                .ReverseMap();

            // Lesson
            CreateMap<Lesson, LessonResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LessonID))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.LessonName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseID))
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsPublished ? "Published" : "Draft"))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.ModifiedAt))
                .ReverseMap();

            // Mapping từ CreateCourseRequestDTO sang Course
            CreateMap<Management_Schedule_BE.DTOs.Request.CreateCourseRequestDTO, Course>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.IsPro, opt => opt.MapFrom(src => src.Level == "Pro"))
                .ForMember(dest => dest.IsSelling, opt => opt.MapFrom(src => src.Status == "Active"))
                .ForMember(dest => dest.IsComingSoon, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.IsCompletable, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.DiscountPercent, opt => opt.MapFrom(src => (byte)0));
        }
    }
} 