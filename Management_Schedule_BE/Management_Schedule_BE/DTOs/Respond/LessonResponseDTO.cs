namespace Management_Schedule_BE.DTOs.Respond
{
    public class LessonResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int OrderNumber { get; set; }
        public int Duration { get; set; }
        public string Status { get; set; }
        public string Content { get; set; }
        public string Materials { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class LessonDetailResponseDTO : LessonResponseDTO
    {
        public CourseResponseDTO Course { get; set; }
        public List<ScheduleResponseDTO> Schedules { get; set; }
    }

    public class LessonListResponseDTO
    {
        public List<LessonResponseDTO> Lessons { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
} 