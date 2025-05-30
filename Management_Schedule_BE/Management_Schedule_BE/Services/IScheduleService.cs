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
    }
} 