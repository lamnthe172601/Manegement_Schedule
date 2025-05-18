using System.ComponentModel.DataAnnotations;
using Management_Schedule_BE.Models;

namespace Management_Schedule_BE.DTOs.Request
{
    public class CreateSessionCodeRequestDTO
    {
        [Required(ErrorMessage = "Mã phiên không được để trống")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Mã phiên phải từ 6 đến 10 ký tự")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Lịch học không được để trống")]
        public Guid ScheduleId { get; set; }

        [Required(ErrorMessage = "Thời gian hết hạn không được để trống")]
        public DateTime ExpiryTime { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        public SessionCodeStatus Status { get; set; }
    }

    public class UpdateSessionCodeRequestDTO
    {
        public string? Code { get; set; }
        public Guid? ScheduleId { get; set; }
        public DateTime? ExpiryTime { get; set; }
        public SessionCodeStatus? Status { get; set; }
    }

    public class SessionCodeFilterRequestDTO
    {
        public string? Code { get; set; }
        public Guid? ScheduleId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public SessionCodeStatus? Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 