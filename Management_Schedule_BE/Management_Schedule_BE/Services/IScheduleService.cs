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
        Task<bool> UpdateScheduleStatusAsync(int id, byte status,string notes);
        Task<IEnumerable<TeacherScheduleViewDTO>> GetSchedulesByTeacherIdAsync(int teacherId);
     
        Task<IEnumerable<ScheduleDTO>> GetSchedulesByDateAsync(DateTime date);
        Task<IEnumerable<StudentScheduleViewDTO>> GetSchedulesByStudentIdAsync(int studentId);
      
        Task AutoGenerateSchedulesAsync(AutoGenerateScheduleDTO dto);
        Task AssignTeacherToClassAsync(int classId, int teacherId);
        Task AssignTeacherToScheduleAsync(int scheduleId, int teacherId,string notes);
    }
} 