using System.ComponentModel.DataAnnotations;

namespace Management_Schedule_BE.DTOs
{
    public class SendOtpRequestDto
    {
        [Required(ErrorMessage = "Địa chỉ email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng.")]
        public string Email { get; set; } = string.Empty;
    }
}
