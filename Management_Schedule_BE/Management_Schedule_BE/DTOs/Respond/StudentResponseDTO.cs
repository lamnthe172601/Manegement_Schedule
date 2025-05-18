namespace Management_Schedule_BE.DTOs.Respond
{
    public class StudentResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string ParentName { get; set; }
        public string ParentPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class StudentDetailResponseDTO : StudentResponseDTO
    {
        public List<ClassResponseDTO> Classes { get; set; }
        public List<StudentTuitionHistoryResponseDTO> TuitionHistory { get; set; }
    }

    public class StudentListResponseDTO
    {
        public List<StudentResponseDTO> Students { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
} 