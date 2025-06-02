using System;

namespace Management_Schedule_BE.DTOs
{
    public class TeacherDTO
    {
        public int TeacherID { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? GoogleUrl { get; set; }
        public string? YouTubeUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public class TeacherDetailDTO
    {
        public int TeacherID { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? GoogleUrl { get; set; }
        public string? YouTubeUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        
        // Thông tin từ bảng User
        
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
    }

    public class CreateTeacherDTO
    {
        public string? ProfileImageUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? GoogleUrl { get; set; }
        public string? YouTubeUrl { get; set; }
    }

    public class UpdateTeacherDTO
    {
        public string? ProfileImageUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? GoogleUrl { get; set; }
        public string? YouTubeUrl { get; set; }
    }
} 