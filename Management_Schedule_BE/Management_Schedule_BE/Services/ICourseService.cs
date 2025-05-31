using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO?> GetCourseByIdAsync(int id);
        Task<CourseDTO> CreateCourseAsync(CreateCourseDTO courseDto);
        Task<CourseDTO?> UpdateCourseAsync(int id, UpdateCourseDTO courseDto);
        Task<bool> DeleteCourseAsync(int id);
        Task<bool> UpdateCourseSellingStatusAsync(int id, bool isSelling);
    }
} 