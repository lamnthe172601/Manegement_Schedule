namespace Management_Schedule_BE.DTOs.Respond
{
    public class SalaryResponseDTO
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class SalaryDetailResponseDTO : SalaryResponseDTO
    {
        public TeacherResponseDTO Teacher { get; set; }
    }

    public class SalaryListResponseDTO
    {
        public List<SalaryResponseDTO> Salaries { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
} 