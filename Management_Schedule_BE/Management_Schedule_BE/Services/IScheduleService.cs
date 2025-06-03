using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<DetailedScheduleDTO>> GetAllSchedulesAsync();
        Task<ScheduleDTO?> GetScheduleByIdAsync(int id);
        Task<ScheduleDTO> CreateScheduleAsync(CreateScheduleDTO dto);
        Task<ScheduleDTO?> UpdateScheduleAsync(int id, UpdateScheduleDTO dto);
        Task<bool> DeleteScheduleAsync(int id);
        Task<bool> UpdateScheduleStatusAsync(int id, byte status);
        Task<IEnumerable<TeacherScheduleViewDTO>> GetSchedulesByTeacherIdAsync(int teacherId);
        Task<IEnumerable<TeacherScheduleViewDTO>> GetSchedulesByTeacherIdAndRangeAsync(int teacherId, DateTime? from, DateTime? to);
        Task<IEnumerable<TeacherScheduleViewDTO>> GetSchedulesByTeacherIdAndStatusAsync(int teacherId, byte status);
        Task<IEnumerable<ScheduleDTO>> GetSchedulesByDateAsync(DateTime date);
        Task<IEnumerable<StudentScheduleViewDTO>> GetSchedulesByStudentIdAsync(int studentId);
        Task<IEnumerable<StudentScheduleViewDTO>> GetSchedulesByStudentIdAndRangeAsync(int studentId, DateTime? from, DateTime? to);
        Task<IEnumerable<StudentScheduleViewDTO>> GetSchedulesByStudentIdAndStatusAsync(int studentId, byte status);
    }
} 