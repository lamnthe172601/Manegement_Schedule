using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

    public record UserCreateDTO(string Email,
    string PasswordHash,
    string? FullName,
    string? Gender,
    DateTime? DateOfBirth,
    string? Address,
    string? Phone,
    string? Introduction,
    string? AvatarUrl);
    public record UserUpdateDTO(
    string Email,
    string PasswordHash,
    byte Role,
    string? FullName,
    string? Gender,
    DateTime? DateOfBirth,
    string? Address,
    string? Phone,
    string? Introduction,
    string? AvatarUrl,
    byte Status,
    DateTime ModifiedAt
    );
    public record UserLogin(string Email, string PasswordHash);
}
