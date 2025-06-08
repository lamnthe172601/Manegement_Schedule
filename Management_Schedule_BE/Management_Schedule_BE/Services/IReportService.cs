using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IReportService
    {
        Task<DashboardAdminDTO> GetDashboardAdminAsync();
        Task<ScheduleStatusStatisticsDTO> GetScheduleStatusStatisticsAsync();
        Task<List<TopTeacherDTO>> GetTopTeachersAsync(int top = 5);
        Task<List<StudentDistributionByClassDTO>> GetStudentDistributionByClassAsync();
    }
} 