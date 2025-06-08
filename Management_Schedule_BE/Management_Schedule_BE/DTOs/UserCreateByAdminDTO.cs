using Microsoft.AspNetCore.Http;

namespace Management_Schedule_BE.DTOs
{
    public class UserCreateByAdminDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte Role { get; set; }
        public string? Phone { get; set; }
        public string Gender { get; set; } 
    }
} 