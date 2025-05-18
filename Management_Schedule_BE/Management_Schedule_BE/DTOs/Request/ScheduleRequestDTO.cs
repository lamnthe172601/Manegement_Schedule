using System.ComponentModel.DataAnnotations;

namespace Management_Schedule_BE.DTOs.Request
{
    public class CreateScheduleRequestDTO
    {
        [Required(ErrorMessage = "Lớp học không được để trống")]
        public int ClassId { get; set; }

        [Required(ErrorMessage = "Giáo viên không được để trống")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Thời gian bắt đầu không được để trống")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Thời gian kết thúc không được để trống")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Phòng học không được để trống")]
        [StringLength(50, ErrorMessage = "Tên phòng học không được vượt quá 50 ký tự")]
        public string Room { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        public string Status { get; set; }
    }

    public class UpdateScheduleRequestDTO
    {
        public int? ClassId { get; set; }
        public int? TeacherId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Room { get; set; }
        public string Status { get; set; }
    }

    public class ScheduleFilterRequestDTO
    {
        public int? ClassId { get; set; }
        public int? TeacherId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 