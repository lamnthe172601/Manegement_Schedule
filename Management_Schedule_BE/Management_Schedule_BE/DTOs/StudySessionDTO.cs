using System;

namespace Management_Schedule_BE.DTOs
{
    public record StudySessionDTO(
        int StudySessionId,
        string DisplayName,
        string StartTime,
        string EndTime,
        string? Description,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );

    public record CreateStudySessionDTO(
        string DisplayName,
        string StartTime,
        string EndTime,
        string? Description
    );

    public record UpdateStudySessionDTO(
        string DisplayName,
        string StartTime,
        string EndTime,
        string? Description
    );
} 