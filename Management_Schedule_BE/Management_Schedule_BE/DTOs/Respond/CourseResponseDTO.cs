namespace Management_Schedule_BE.DTOs.Respond
{
    public class CourseResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public string Level { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CourseDetailResponseDTO : CourseResponseDTO
    {
        public List<ClassResponseDTO> Classes { get; set; }
        public List<LessonResponseDTO> Lessons { get; set; }
    }

    public class CourseListResponseDTO
    {
        public List<CourseResponseDTO> Courses { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
} 