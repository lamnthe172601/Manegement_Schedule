namespace Management_Schedule_BE.DTOs.Respond
{
    public class ScheduleResponseDTO
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Room { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class ScheduleDetailResponseDTO : ScheduleResponseDTO
    {
        public ClassResponseDTO Class { get; set; }
        public TeacherResponseDTO Teacher { get; set; }
        public List<StudentResponseDTO> Students { get; set; }
    }

    public class ScheduleListResponseDTO
    {
        public List<ScheduleResponseDTO> Schedules { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
} 