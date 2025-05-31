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
    string? Gender,
    DateTime? DateOfBirth,
    string? Address,
    string? Phone,
    string? Introduction,
    string? AvatarUrl,
    byte Status,
    DateTime CreatedAt,
    DateTime ModifiedAt);

    public record UserCreateDTO(
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    string Email,
    string PasswordHash,
    string? FullName,
    [MaxLength(1)]
    string? Gender,
    DateTime? DateOfBirth,
    string? Address,
    string? Phone,
    string? Introduction,
    string? AvatarUrl);
    public record UserUpdateDTO(
    byte Role,
    string? FullName,
    string? Gender,
    DateTime? DateOfBirth,
    string? Address,
    string? Phone,
    string? Introduction,
    string? AvatarUrl,
    byte Status
    );
    public record UserLogin(string Email, string PasswordHash);
    public record TeachStudentProfile(
        string? Email,
        string? FullName,
        string? Address,
        string? Phone,
        string? AvatarUrl,
        DateTime? DateOfBirth,
        string? Gender
    );
}
