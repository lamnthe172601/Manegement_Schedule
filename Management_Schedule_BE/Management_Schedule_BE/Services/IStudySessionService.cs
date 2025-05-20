using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IStudySessionService
    {
        Task<IEnumerable<StudySessionDTO>> GetAllStudySessionsAsync();
        Task<StudySessionDTO?> GetStudySessionByIdAsync(int id);
        Task<StudySessionDTO> CreateStudySessionAsync(CreateStudySessionDTO dto);
        Task<StudySessionDTO?> UpdateStudySessionAsync(int id, UpdateStudySessionDTO dto);
        Task<bool> DeleteStudySessionAsync(int id);
    }
} 