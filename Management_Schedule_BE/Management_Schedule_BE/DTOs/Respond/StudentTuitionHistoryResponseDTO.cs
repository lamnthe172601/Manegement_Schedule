namespace Management_Schedule_BE.DTOs.Respond
{
    public class StudentTuitionHistoryResponseDTO
    {
        public int PaymentID { get; set; }
        public int StudentID { get; set; }
        public int TuitionID { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
} 