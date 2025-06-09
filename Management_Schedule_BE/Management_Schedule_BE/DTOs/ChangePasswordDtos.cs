namespace Management_Schedule_BE.DTOs
{
    public class ChangePasswordDtos
    {
        public string? Email { get; set; }
        public string? OldPassword { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
