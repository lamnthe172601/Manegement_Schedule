namespace Management_Schedule_BE.DTOs.Respond
{
    public class TuitionResponseDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class TuitionDetailResponseDTO : TuitionResponseDTO
    {
        public StudentResponseDTO Student { get; set; }
        public CourseResponseDTO Course { get; set; }
    }

    public class TuitionListResponseDTO
    {
        public List<TuitionResponseDTO> Tuitions { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
} 