namespace Management_Schedule_BE.DTOs
{
    public record TeacherScheduleReportDTO
    {
        public int TeacherID { get; init; }
        public string TeacherName { get; init; }
        public int TotalSessions { get; init; }
        public int CompletedSessions { get; init; }
        public int CancelledSessions { get; init; }
        public List<ScheduleDTO> Schedules { get; init; }
    }

    public record ClassScheduleReportDTO
    {
        public int ClassID { get; init; }
        public string ClassName { get; init; }
        public int TotalSessions { get; init; }
        public int CompletedSessions { get; init; }
        public int CancelledSessions { get; init; }
        public List<ScheduleDTO> Schedules { get; init; }
    }

    public record RoomScheduleReportDTO
    {
        public string Room { get; init; }
        public int TotalSessions { get; init; }
        public int CompletedSessions { get; init; }
        public int CancelledSessions { get; init; }
        public List<ScheduleDTO> Schedules { get; init; }
    }

    public record DailyScheduleReportDTO
    {
        public int TotalSessions { get; init; }
        public int CompletedSessions { get; init; }
        public int CancelledSessions { get; init; }
        public List<ScheduleDTO> Schedules { get; init; }
    }

    public record TeacherStatisticsDTO
    {
        public int TeacherID { get; init; }
        public string TeacherName { get; init; }
        public int TotalTeachingHours { get; init; }
        public int TotalClasses { get; init; }
        public Dictionary<string, int> RoomUsage { get; init; }
        public Dictionary<DayOfWeek, int> DayDistribution { get; init; }
    }

    public record RoomStatisticsDTO
    {
        public string Room { get; init; }
        public int TotalSessions { get; init; }
        public int TotalTeachingHours { get; init; }
        public Dictionary<int?, int>? TeacherDistribution { get; init; }
        public Dictionary<DayOfWeek, int> DayDistribution { get; init; }
    }

    public record DashboardAdminDTO
    {
        public int TotalUsers { get; init; }
        public int TotalTeachers { get; init; }
        public int TotalStudents { get; init; }
        public int TotalClasses { get; init; }
        public int TotalCourses { get; init; }
        public int TotalSchedules { get; init; }
        public int TotalActiveClasses { get; init; }
        public int TotalActiveStudents { get; init; }
        public int TotalActiveTeachers { get; init; }
    }

    public record StatisticsByMonthDTO
    {
        public int Month { get; init; }
        public int TotalUsers { get; init; }
        public int TotalTeachers { get; init; }
        public int TotalStudents { get; init; }
        public int TotalClasses { get; init; }
    }

    public record ScheduleStatusStatisticsDTO
    {
        public int TotalSchedules { get; init; }
        public int CompletedSchedules { get; init; }
        public int CancelledSchedules { get; init; }
        public int PendingSchedules { get; init; }
    }

    public record TopTeacherDTO
    {
        public int TeacherID { get; init; }
        public string TeacherName { get; init; }
        public int TotalSessions { get; init; }
    }

    public record StudentDistributionByClassDTO
    {
        public int ClassID { get; init; }
        public string ClassName { get; init; }
        public int StudentCount { get; init; }
    }
} 