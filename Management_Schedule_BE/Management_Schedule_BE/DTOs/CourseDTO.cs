using System;

namespace Management_Schedule_BE.DTOs
{
    public record CourseDTO(
        int CourseID,
        string CourseName,
        string? Description,
        decimal Price,
        string? ThumbnailUrl,
        bool IsSelling,
        bool IsComingSoon,
        bool IsPro,
        bool IsCompletable,
        byte DiscountPercent,
        int Duration,
        byte Level,
        DateTime CreatedAt,
        DateTime ModifiedAt
    );

    public record CreateCourseDTO(
        string CourseName,
        string? Description,
        decimal Price,
        string? ThumbnailUrl,
        bool IsSelling,
        bool IsComingSoon,
        bool IsPro,
        bool IsCompletable,
        byte DiscountPercent,
        int Duration,
        byte Level
    );

    public record UpdateCourseDTO(
        string CourseName,
        string? Description,
        decimal Price,
        string? ThumbnailUrl,
        bool IsSelling,
        bool IsComingSoon,
        bool IsPro,
        bool IsCompletable,
        byte DiscountPercent,
        int Duration,
        byte Level
    );

    public record UpdateCourseSellingStatusDTO(
        bool isSelling
    );
} 