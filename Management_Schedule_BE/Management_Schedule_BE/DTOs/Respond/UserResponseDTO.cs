namespace Management_Schedule_BE.DTOs.Respond
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public UserResponseDTO User { get; set; }
    }

    public class UserListResponseDTO
    {
        public List<UserResponseDTO> Users { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
} 