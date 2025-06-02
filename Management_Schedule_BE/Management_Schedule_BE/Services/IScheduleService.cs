using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleDTO>> GetAllSchedulesAsync();
        Task<ScheduleDTO?> GetScheduleByIdAsync(int id);
        Task<ScheduleDTO> CreateScheduleAsync(CreateScheduleDTO dto);
        Task<ScheduleDTO?> UpdateScheduleAsync(int id, UpdateScheduleDTO dto);
        Task<bool> DeleteScheduleAsync(int id);
        Task<bool> UpdateScheduleStatusAsync(int id, byte status);
        Task<IEnumerable<ScheduleDTO>> GetSchedulesByTeacherIdAsync(int teacherId);
        Task<IEnumerable<ScheduleDTO>> GetSchedulesByTeacherIdAndRangeAsync(int teacherId, DateTime? from, DateTime? to);
        Task<IEnumerable<ScheduleDTO>> GetSchedulesByTeacherIdAndStatusAsync(int teacherId, byte status);
        Task<IEnumerable<ScheduleDTO>> GetSchedulesByDateAsync(DateTime date);
    }
} 