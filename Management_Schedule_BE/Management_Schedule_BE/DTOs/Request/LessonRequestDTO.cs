using System.ComponentModel.DataAnnotations;

namespace Management_Schedule_BE.DTOs.Request
{
    public class CreateLessonRequestDTO
    {
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Tiêu đề phải từ 3 đến 200 ký tự")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [StringLength(1000, ErrorMessage = "Mô tả không được vượt quá 1000 ký tự")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Khóa học không được để trống")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Thứ tự bài học không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Thứ tự bài học phải lớn hơn 0")]
        public int OrderNumber { get; set; }

        [Required(ErrorMessage = "Thời lượng không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Thời lượng phải lớn hơn 0")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        public string Status { get; set; }

        public string Content { get; set; }
        public string Materials { get; set; }
    }

    public class UpdateLessonRequestDTO
    {
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Tiêu đề phải từ 3 đến 200 ký tự")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "Mô tả không được vượt quá 1000 ký tự")]
        public string Description { get; set; }

        public int? CourseId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Thứ tự bài học phải lớn hơn 0")]
        public int? OrderNumber { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Thời lượng phải lớn hơn 0")]
        public int? Duration { get; set; }

        public string Status { get; set; }
        public string Content { get; set; }
        public string Materials { get; set; }
    }

    public class LessonFilterRequestDTO
    {
        public string SearchTerm { get; set; }
        public int? CourseId { get; set; }
        public string Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 