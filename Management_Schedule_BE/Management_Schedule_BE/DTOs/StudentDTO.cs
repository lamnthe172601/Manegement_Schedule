using System;

namespace Management_Schedule_BE.DTOs
{
    public record StudentInClassDTO(
        int StudentID,
        string FullName,
        string? AvatarUrl,
        string Email,
        string? PhoneNumber,
        DateTime EnrollmentDate,
        byte Level,
        byte Status
    );
} 