using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IReportService
    {
        // Báo cáo lịch dạy của giáo viên
        Task<TeacherScheduleReportDTO> GetTeacherScheduleReportAsync(int teacherId, DateTime startDate, DateTime endDate);
        
        // Báo cáo lịch học của lớp
        Task<ClassScheduleReportDTO> GetClassScheduleReportAsync(int classId, DateTime startDate, DateTime endDate);
        
        // Báo cáo sử dụng phòng học
        Task<RoomScheduleReportDTO> GetRoomScheduleReportAsync(string room, DateTime startDate, DateTime endDate);
        
        // Báo cáo lịch dạy theo ngày
        Task<DailyScheduleReportDTO> GetDailyScheduleReportAsync(DateTime date);
        
        // Thống kê giáo viên
        Task<TeacherStatisticsDTO> GetTeacherStatisticsAsync(int teacherId, DateTime startDate, DateTime endDate);
        
        // Thống kê phòng học
        Task<RoomStatisticsDTO> GetRoomStatisticsAsync(string room, DateTime startDate, DateTime endDate);
    }
} 