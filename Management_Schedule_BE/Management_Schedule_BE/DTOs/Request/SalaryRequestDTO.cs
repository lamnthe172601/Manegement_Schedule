using System.ComponentModel.DataAnnotations;

namespace Management_Schedule_BE.DTOs.Request
{
    public class CreateSalaryRequestDTO
    {
        [Required(ErrorMessage = "Giáo viên không được để trống")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Số tiền không được để trống")]
        [Range(1, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Ngày thanh toán không được để trống")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Phương thức thanh toán không được để trống")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Tháng không được để trống")]
        [Range(1, 12, ErrorMessage = "Tháng phải từ 1 đến 12")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Năm không được để trống")]
        [Range(2000, 2100, ErrorMessage = "Năm không hợp lệ")]
        public int Year { get; set; }

        public string Note { get; set; }
    }

    public class UpdateSalaryRequestDTO
    {
        public int? TeacherId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string Note { get; set; }
    }

    public class SalaryFilterRequestDTO
    {
        public int? TeacherId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 