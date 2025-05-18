using System.ComponentModel.DataAnnotations;

namespace Management_Schedule_BE.DTOs.Request
{
    public class CreateTeacherRequestDTO
    {
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Họ tên phải từ 2 đến 100 ký tự")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Giới tính không được để trống")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Chuyên môn không được để trống")]
        [StringLength(200, ErrorMessage = "Chuyên môn không được vượt quá 200 ký tự")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        public string Status { get; set; }

        public string Address { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
    }

    public class UpdateTeacherRequestDTO
    {
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Họ tên phải từ 2 đến 100 ký tự")]
        public string FullName { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
    }

    public class TeacherFilterRequestDTO
    {
        public string SearchTerm { get; set; }
        public string Gender { get; set; }
        public string Specialization { get; set; }
        public string Status { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
} 