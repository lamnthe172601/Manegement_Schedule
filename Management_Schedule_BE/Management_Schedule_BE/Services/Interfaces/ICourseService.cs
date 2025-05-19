using Management_Schedule_BE.DTOs.Request;
using Management_Schedule_BE.DTOs.Respond;
using Management_Schedule_BE.Models;
using System.Threading.Tasks;

namespace Management_Schedule_BE.Services.Interfaces
{
    public interface ICourseService : IBaseService<Course>
    {
        Task<CourseListResponseDTO> GetAllAsync(CourseFilterRequestDTO filter);
        Task<CourseDetailResponseDTO> GetByIdAsync(int id);
        Task<CourseResponseDTO> CreateAsync(CreateCourseRequestDTO courseDto);
        Task<CourseResponseDTO> UpdateAsync(int id, UpdateCourseRequestDTO courseDto);
    }
} 