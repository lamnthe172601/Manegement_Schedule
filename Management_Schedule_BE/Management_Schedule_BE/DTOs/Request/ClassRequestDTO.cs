using System.ComponentModel.DataAnnotations;

namespace Management_Schedule_BE.DTOs.Request
{
    public class CreateClassRequestDTO
    {
        [Required(ErrorMessage = "Tên lớp không được để trống")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên lớp phải từ 3 đến 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Khóa học không được để trống")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Số học viên tối đa không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số học viên tối đa phải lớn hơn 0")]
        public int MaxStudents { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        public string Status { get; set; }
    }

    public class UpdateClassRequestDTO
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên lớp phải từ 3 đến 100 ký tự")]
        public string Name { get; set; }

        public int? CourseId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số học viên tối đa phải lớn hơn 0")]
        public int? MaxStudents { get; set; }

        public string Status { get; set; }
    }

    public class ClassFilterRequestDTO
    {
        public string SearchTerm { get; set; }
        public int? CourseId { get; set; }
        public string Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 