namespace Management_Schedule_BE.DTOs
{
    public class UpdatePasswordDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
