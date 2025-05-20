using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface ILessonService
    {
        Task<IEnumerable<LessonDTO>> GetAllLessonsAsync();
        Task<LessonDTO?> GetLessonByIdAsync(int id);
        Task<LessonDTO> CreateLessonAsync(CreateLessonDTO lessonDto);
        Task<LessonDTO?> UpdateLessonAsync(int id, UpdateLessonDTO lessonDto);
        Task<bool> DeleteLessonAsync(int id);
    }
} 