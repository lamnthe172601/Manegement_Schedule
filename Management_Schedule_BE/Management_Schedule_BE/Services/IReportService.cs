using Management_Schedule_BE.DTOs;

namespace Management_Schedule_BE.Services
{
    public interface IReportService
    {
        // Báo cáo lịch dạy của giáo viên
        Task<TeacherScheduleReportDTO> GetTeacherScheduleReportAsync(int teacherId);
        
        // Báo cáo lịch học của lớp
        Task<ClassScheduleReportDTO> GetClassScheduleReportAsync(int classId);
        
        // Báo cáo sử dụng phòng học
        Task<RoomScheduleReportDTO> GetRoomScheduleReportAsync(string room);
        
        // Báo cáo lịch dạy theo ngày
        Task<DailyScheduleReportDTO> GetDailyScheduleReportAsync();
        
        // Thống kê giáo viên
        Task<TeacherStatisticsDTO> GetTeacherStatisticsAsync(int teacherId);
        
        // Thống kê phòng học
        Task<RoomStatisticsDTO> GetRoomStatisticsAsync(string room);
    }
} 