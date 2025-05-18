using System.ComponentModel.DataAnnotations;

namespace Management_Schedule_BE.DTOs.Request
{
    public class CreateTuitionRequestDTO
    {
        [Required(ErrorMessage = "Học viên không được để trống")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Khóa học không được để trống")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Số tiền không được để trống")]
        [Range(1, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Ngày thanh toán không được để trống")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Phương thức thanh toán không được để trống")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        public string Status { get; set; }

        public string Note { get; set; }
    }

    public class UpdateTuitionRequestDTO
    {
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
    }

    public class TuitionFilterRequestDTO
    {
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 