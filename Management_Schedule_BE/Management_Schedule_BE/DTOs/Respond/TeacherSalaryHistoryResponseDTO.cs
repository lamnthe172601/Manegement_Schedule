namespace Management_Schedule_BE.DTOs.Respond
{
    public class TeacherSalaryHistoryResponseDTO
    {
        public int PaymentID { get; set; }
        public int TeacherID { get; set; }
        public int SalaryID { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
} 