using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Management_Schedule_BE.DTOs
{
    public record UserDTO(
    int UserID,
    string? Email,
    string? PasswordHash,
    byte Role,
    string? FullName,
    
    DateTime? DateOfBirth,
    string? Address,
    string? Phone,
    string? Introduction,
    string? AvatarUrl,
    byte Status,
    DateTime CreatedAt,
    DateTime ModifiedAt,
    string? Gender = "M");

    public record UserCreateDTO(
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    string Email,
    string PasswordHash,
    string? FullName,
    [MaxLength(1)]
    DateTime? DateOfBirth,
    string? Address,
    string? Phone,
    string? Introduction,
    string? Gender = "M",
    IFormFile? AvatarUrl = null
    );
    public record UserUpdateDTO(
    byte Role,
    string? FullName,
    
    DateTime? DateOfBirth,
    string? Address,
    string? Phone,
    string? Introduction,
    byte Status,
    string? Gender = "M",
    IFormFile? AvatarUrl = null
    );
    public record UserLogin(string Email, string PasswordHash);
    public record TeachStudentProfile(
        string? Email,
        string? FullName,
        string? Address,
        string? Phone,
        DateTime? DateOfBirth,
        string? Gender = "M",
        IFormFile? AvatarUrl = null
    );
}
