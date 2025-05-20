using System;

namespace Management_Schedule_BE.DTOs
{
    public record LessonDTO(
        int LessonID,
        string LessonName,
        string? Description,
        string ContentUrl,
        string? ThumbnailUrl,
        int CourseID,
        int Position,
        bool IsPublished,
        int Duration,
        byte Type,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );

    public record CreateLessonDTO(
        string LessonName,
        string? Description,
        string ContentUrl,
        string? ThumbnailUrl,
        int CourseID,
        int Position,
        bool IsPublished,
        int Duration,
        byte Type
    );

    public record UpdateLessonDTO(
        string LessonName,
        string? Description,
        string ContentUrl,
        string? ThumbnailUrl,
        int Position,
        bool IsPublished,
        int Duration,
        byte Type
    );
} 