using System.ComponentModel.DataAnnotations;

namespace Management_Schedule_BE.DTOs.Request
{
    public class CreateCourseRequestDTO
    {
        [Required(ErrorMessage = "Tên khóa học không được để trống")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên khóa học phải từ 3 đến 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Thời lượng không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Thời lượng phải lớn hơn 0")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá không được âm")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Trình độ không được để trống")]
        public string Level { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        public string Status { get; set; }
    }

    public class UpdateCourseRequestDTO
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Tên khóa học phải từ 3 đến 100 ký tự")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Thời lượng phải lớn hơn 0")]
        public int? Duration { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá không được âm")]
        public decimal? Price { get; set; }

        public string? Level { get; set; }
        public string? Status { get; set; }
    }

    public class CourseFilterRequestDTO
    {
        public string? SearchTerm { get; set; }
        public string? Level { get; set; }
        public string? Status { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 