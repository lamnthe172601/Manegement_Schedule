namespace Management_Schedule_BE.DTOs.Respond
{
    public class ClassResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int MaxStudents { get; set; }
        public int CurrentStudents { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class ClassDetailResponseDTO : ClassResponseDTO
    {
        public CourseResponseDTO Course { get; set; }
        public List<StudentResponseDTO> Students { get; set; }
        public List<ScheduleResponseDTO> Schedules { get; set; }
    }

    public class ClassListResponseDTO
    {
        public List<ClassResponseDTO> Classes { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
} 